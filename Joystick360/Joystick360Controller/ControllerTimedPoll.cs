using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Joystick360Controller.Driver;
using Joystick360Controller.Structs;

namespace Joystick360Controller
{
    public class ControllerTimedPoll : IControllerTimedPoll
    {
        private readonly ConcurrentDictionary<int, IController> _collection;

        private IInput _input;
        private Thread _pollingThread;
        private bool _abortPollingThread;
        private int _millisecondsInterval;
        private IControllerFactory _factory;
        
        public Func<IController, int, bool> OnPollError { get; set; }

        public ControllerTimedPoll()
        {
            _abortPollingThread = false;
            _collection = new ConcurrentDictionary<int, IController>();
        }

        public bool Start(IControllerFactory factory, IInput input, int millisecondsInterval)
        {
            _input = input;
            _factory = factory;
            _millisecondsInterval = millisecondsInterval;
            
            if (_pollingThread != null)
                return false;

            _pollingThread = new Thread(PollThreadMethod);
            _pollingThread.Start();
            return true;
        }

        public IController CreateOrGet(int key)
        {
            return _collection.GetOrAdd(key, _factory.Create);
        }

        public IEnumerable<IController> GetAll()
        {
            return _collection.Values;
        }

        public bool Remove(int key)
        {
            var ret = _collection.TryRemove(key, out _);
            
            if (!_collection.Any())
                Dispose();

            return ret;
        }

        public void Dispose()
        {
            if (_pollingThread == null)
                return;
            
            _abortPollingThread = true;
            
            try
            {
                if(_pollingThread?.ThreadState == ThreadState.Running &&
                   _pollingThread?.Join(_millisecondsInterval * 10) == false)
                    _pollingThread?.Abort();
            }
            finally
            {
                _pollingThread = null;
            }
        }
        
        private void PollThreadMethod()
        {
            _abortPollingThread = false;
            var currentState = new InputState();
            while(!_abortPollingThread)
            {
                foreach (var controller in _collection.Values)
                {
                    var result = _input.GetState(controller.Index, ref currentState);
                    if (result != 0 && OnPollError != null)
                    {
                        if(OnPollError(controller, result))
                            Remove(controller.Index);
                    }
                    else
                    {
                        controller.Poll(currentState);
                    }
                }
                Thread.Sleep(_millisecondsInterval);
            }
        }

        public int Vibrate(int index, InputVibration vibration)
        {
            return _input.SetState(index, ref vibration);
        }
    }
}

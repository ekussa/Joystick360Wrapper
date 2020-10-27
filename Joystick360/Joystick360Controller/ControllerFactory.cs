namespace Joystick360Controller
{
    public class ControllerFactory : IControllerFactory
    {
        private static readonly ControllerFactoryArguments DefaultControllerFactoryArguments = new ControllerFactoryArguments(); 
        
        private IControllerFactoryArguments _arguments = DefaultControllerFactoryArguments;
        
        public void Setup(IControllerFactoryArguments arguments)
        {
            _arguments = arguments;
        }

        public IController Create(int index)
        {
            return new Controller(index, _arguments.ControllerTimedPoll);
        }
    }
}

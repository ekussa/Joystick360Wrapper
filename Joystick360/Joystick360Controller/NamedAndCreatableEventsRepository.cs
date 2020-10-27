using System.Collections.Generic;

namespace Joystick360Controller
{
    public class NamedAndCreatableEventsRepository : NamedEventsRepository, IEventsRepositoryCreation<string, ICreatableEvents>
    {
        public NamedAndCreatableEventsRepository()
        {
        }
        
        public NamedAndCreatableEventsRepository(IDictionary<string, IControllerEvents> repository)
            : base(repository)
        {
        }

        public bool Create(string key, ICreatableEvents creatableEvents)
        {
            return Collection.TryAdd(key, creatableEvents.DumpEvents());
        }
    }
}

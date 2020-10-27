using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Joystick360Controller
{
    public class NamedEventsRepository : INamedEventsRepository
    {
        protected readonly IDictionary<string, IControllerEvents> Collection;

        public NamedEventsRepository()
        {
            Collection = new ConcurrentDictionary<string, IControllerEvents>();
        }

        public NamedEventsRepository(IDictionary<string, IControllerEvents> repository)
        {
            Collection = repository;
        }

        public bool Create(string key, IControllerEvents events)
        {
            return Collection.TryAdd(key, events);
        }

        public IControllerEvents Get(string key)
        {
            var found = Collection.TryGetValue(key, out var ret);
            return found ? ret : null;
        }

        public IEnumerable<IControllerEvents> Get(IList<string> keys)
        {
            return Collection
                .Where(_ => keys.Contains(_.Key))
                .Select(_ => _.Value);
        }

        public IEnumerable<IControllerEvents> GetAll()
        {
            return Collection.Values;
        }
    }
}

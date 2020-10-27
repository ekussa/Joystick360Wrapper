using System.Collections.Generic;

namespace Joystick360Controller
{
    public interface IEventsRepository<TKey, TObj> : IEventsRepositoryCreation<TKey, TObj>
    {
        TObj Get(TKey key);
        IEnumerable<TObj> Get(IList<TKey> keys);
        IEnumerable<TObj> GetAll();
    }
}

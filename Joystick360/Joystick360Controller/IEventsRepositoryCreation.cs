namespace Joystick360Controller
{
    public interface IEventsRepositoryCreation<in TKey, in TObj>
    {
        bool Create(TKey key, TObj events);
    }
}
namespace Joystick360Controller
{
    public interface IControllerFactory
    {
        void Setup(IControllerFactoryArguments setupArguments);
        
        IController Create(int key);
    }
}
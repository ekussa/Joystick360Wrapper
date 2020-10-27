namespace Joystick360Controller.UnitTests
{
    public class UnitTestsCreatableEvents : ICreatableEvents
    {
        public IControllerEvents DumpEvents()
        {
            var ret = new ConcreteControllerEvents();
            ret.AChanged += RetOnAChanged;
            return ret;
        }

        private static void RetOnAChanged(object sender, bool e)
        {
            throw new System.NotImplementedException();
        }
    }
}
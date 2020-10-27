namespace HumanPointer
{
    public interface IPointerMover
    {
        void Move(int x, int y);
        void LeftClickDown();
        void LeftClickUp();
        void RightClickDown();
        void RightClickUp();
    }
}
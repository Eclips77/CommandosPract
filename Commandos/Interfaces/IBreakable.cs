namespace Commandos.Interfaces
{
    public interface IBreakable
    {
        bool IsBroken { get; }
        void Hit();
    }
}

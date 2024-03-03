namespace OnTrack.Factory
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}
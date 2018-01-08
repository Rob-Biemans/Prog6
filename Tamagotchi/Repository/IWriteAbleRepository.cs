namespace Tamagotchi.Domein.Repository
{
    public interface IWriteableRepository<T> : IReadableRepository<T> where T : class
    {
        void Add(T obj);
        void Remove(T obj);
        void Update(T obj);
    }
}

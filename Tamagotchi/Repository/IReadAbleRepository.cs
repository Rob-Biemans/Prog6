using System.Collections.Generic;

namespace Tamagotchi.Domein.Repository
{
    public interface IReadableRepository<T> where T : class
    {
        List<T> GetAll();
    }
}

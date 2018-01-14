using System.Collections.Generic;
using Tamagotchi.Models;

namespace Tamagotchi.Domein.Repository
{
    public interface ITamagotchiRepository : IWriteableRepository<Tamagochi>
    {
        Tamagochi GetById(int? ID);
        bool ForceRefresh();
        List<Tamagochi> GetAvailable();
    }
}

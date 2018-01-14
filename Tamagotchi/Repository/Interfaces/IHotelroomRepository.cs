using System.Collections.Generic;
using Tamagotchi.Models;

namespace Tamagotchi.Domein.Repository
{
    public interface IHotelroomRepository : IWriteableRepository<Hotelroom>
    {
        Hotelroom GetById(int? ID);
        bool ForceRefresh();
        List<Hotelroom> GetAvailable();
    }
}

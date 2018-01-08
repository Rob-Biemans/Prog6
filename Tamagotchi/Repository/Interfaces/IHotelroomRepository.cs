using Tamagotchi.Domein.Models;

namespace Tamagotchi.Domein.Repository
{
    public interface IHotelroomRepository : IWriteableRepository<Hotelroom>
    {
        Hotelroom GetById(int? ID);
        bool ForceRefresh();
    }
}

using Tamagotchi.Models;

namespace Tamagotchi.Domein.Repository
{
    public interface IBookingRepository : IWriteableRepository<Booking>
    {
        Booking GetById(int? ID);
        bool ForceRefresh();
    }
}

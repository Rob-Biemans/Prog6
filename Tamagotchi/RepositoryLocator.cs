using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Tamagotchi.Models;
using Tamagotchi.Domein.Repository;
using Tamagotchi.Models;

namespace Tamagotchi.Domein
{
    public class RepositoryLocator
    {
        private static Lazy<RepositoryLocator> _repositories = new Lazy<RepositoryLocator>(() => new RepositoryLocator());
        private static Mode CURRENT_MODE = Mode.DATABASE;
        private IKernel _kernel;
        private TamagotchiEntities _db;

        public static RepositoryLocator Repositories
        {
            get
            {
                return _repositories.Value;
            }
        }

        public TamagotchiEntities Database
        {
            get
            {
                return _db;
            }
        }

        private enum Mode
        {
            DUMMY,
            DATABASE
        }

        private RepositoryLocator()
        {
            _kernel = new StandardKernel();

            if (CURRENT_MODE == Mode.DATABASE)
            {
                _db = new TamagotchiEntities();
                _kernel.Bind<ITamagotchiRepository>().To<TamagotchiDatabaseRepository>().InSingletonScope().WithConstructorArgument("db", _db);
                _kernel.Bind<IHotelroomRepository>().To<HotelroomDatabaseRepository>().InSingletonScope().WithConstructorArgument("db", _db);
                _kernel.Bind<IBookingRepository>().To<BookingDatabaseRepository>().InSingletonScope().WithConstructorArgument("db", _db);
                //_kernel.Bind<IUserRepository>().To<UserDatabaseRepository>().InSingletonScope().WithConstructorArgument("db", _db);
            }
            else if (CURRENT_MODE == Mode.DUMMY)
            {
                _kernel.Bind<ITamagotchiRepository>().To<TamagotchiDummyRepository>().InSingletonScope();
                _kernel.Bind<IHotelroomRepository>().To<HotelroomDummyRepository>().InSingletonScope();
                _kernel.Bind<IBookingRepository>().To<BookingDummyRepository>().InSingletonScope();
                //_kernel.Bind<IUserRepository>().To<UserDummyRepository>().InSingletonScope();
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        //public IUserRepository UserRepository
        //{
        //    get
        //    {
        //        return _kernel.Get<IUserRepository>();
        //    }
        //}

        public ITamagotchiRepository TamagotchiRepository
        {
            get
            {
                return _kernel.Get<ITamagotchiRepository>();
            }
        }

        public IHotelroomRepository HotelroomRepository
        {
            get
            {
                return _kernel.Get<IHotelroomRepository>();
            }
        }

        public IBookingRepository BookingRepository
        {
            get
            {
                return _kernel.Get<IBookingRepository>();
            }
        }
    }
}

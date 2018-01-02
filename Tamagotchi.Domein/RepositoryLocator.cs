using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Tamagotchi.Domein
{
    public class RepositoryLocator
    {
        private static Lazy<RepositoryLocator> _repositories = new Lazy<RepositoryLocator>(() => new RepositoryLocator());

        public static RepositoryLocator Repositories
        {
            get
            {
                return _repositories.Value;
            }
        }

        //public Database Database
        //{
        //    get
        //    {
        //        return _db;
        //    }
        //}

        private enum Mode
        {
            DUMMY,
            DATABASE
        }

        private static Mode CURRENT_MODE = Mode.DATABASE;

        private IKernel _kernel;

        //TODO Model/db toevoegen aan Domein
        //private Database _db;

        private RepositoryLocator()
        {
            _kernel = new StandardKernel();

            //if (CURRENT_MODE == Mode.Database)
            //{
            //  _db = new Database();
            //  _kernel.Bind<IUserRepository>().To<UserDatabaseRepository>().InSingletonScope().WithConstructorArgument("db", _db);
            //}
            //else if (CURRENT_MODE == Mode.DUMMY)
            //{
            //  _kernel.Bind<IUserRepository>().To<UserDummyRepository>().InSingletonScope();
            //}
        }

        //public IUserRepository UserRepository
        //{
        //    get
        //    {
        //        return _kernel.Get<IUserRepository>();
        //    }
        //}
    }
}

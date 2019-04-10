using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ParserTestApps
{
    public interface IRepository
    {

        #region Cars

        IQueryable<Cars> Carss { get; }

        bool CreateCar(Cars instance);

        bool UpdateCar(Cars instance);

        bool RemoveCar(int idCar);

        #endregion


        #region CarModels

        IQueryable<CarModels> CarModelss { get; }

        bool CreateCarModel(CarModels instance);

        bool UpdateCarModel(CarModels instance);

        bool RemoveCarModel(int idCarModel);

        #endregion

    }
}

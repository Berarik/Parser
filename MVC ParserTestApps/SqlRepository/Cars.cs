using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ParserTestApps
{
    public partial class SqlRepository
    {
        
        public IQueryable<Cars> Carss
        {
            get
            {
                return Db.Cars;
            }
        }

        public bool CreateCar(Cars instance)
        {
            if (instance.Id == 0)
            {
                instance.Year = DateTime.Now;
                instance.Description = Cars.GetActivateUrl();
                Db.Cars.InsertOnSubmit(instance);
                Db.Cars.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateCar(Cars instance)
        {
            Cars cache = Db.Cars.Where(p => p.Id == instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Cars
                Db.Cars.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveCar(int idCars)
        {
            Cars instance = Db.Cars.Where(p => p.Id == idCars).FirstOrDefault();
            if (instance != null)
            {
                Db.Cars.DeleteOnSubmit(instance);
                Db.Cars.Context.SubmitChanges();
                return true;
            }

            return false;
        }


    }
}
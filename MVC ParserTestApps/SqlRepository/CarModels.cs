using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ParserTestApps
{
    public partial class SqlRepository
    {


        public IQueryable<CarModels> CarModelss
        {
            get
            {
                return Db.CarModels;
            }
        }

        public bool CreateCarModel(CarModels instance)
        {
            if (instance.ModelId == 0)
            {
                Db.CarModels.InsertOnSubmit(instance);
                Db.CarModels.Context.SubmitChanges();
                return true;
            }

            return false;
        }
       


        public bool UpdateCarModel(CarModels instance)
        {
            CarModels cache = Db.CarModels.Where(p => p.ModelId == instance.ModelId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for CarModel
                Db.CarModels.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveCarModel(int idCarModel)
        {
            CarModels instance = Db.CarModels.Where(p => p.ModelId == idCarModel).FirstOrDefault();
            if (instance != null)
            {
                Db.CarModels.DeleteOnSubmit(instance);
                Db.CarModels.Context.SubmitChanges();
                return true;
            }

            return false;
        }


    }
}
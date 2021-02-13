using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContex context = new CarRentalContex())
            {
                var result = filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();

                return result;
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var result = contex.Set<Car>().SingleOrDefault(filter);
                return result;
            }
        }

        public void Add(Car entity)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var addedEntity = contex.Entry(entity);
                addedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}

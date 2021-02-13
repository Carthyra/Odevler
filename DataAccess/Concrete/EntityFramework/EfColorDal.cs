using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarRentalContex context = new CarRentalContex())
            {
                var result = filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();

                return result;
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var result = contex.Set<Color>().SingleOrDefault(filter);
                return result;
            }
        }

        public void Add(Color entity)
        {
            using (CarRentalContex context = new CarRentalContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public void Update(Color entity)
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

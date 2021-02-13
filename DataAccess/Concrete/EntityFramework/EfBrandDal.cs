using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var result = filter == null
                    ? contex.Set<Brand>().ToList()
                    : contex.Set<Brand>().Where(filter).ToList();

                return result;
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var result = contex.Set<Brand>().SingleOrDefault(filter);

                return result;
            }
        }

        public void Add(Brand entity)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var addedEntity = contex.Entry(entity);
                addedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public void Update(Brand entity)
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

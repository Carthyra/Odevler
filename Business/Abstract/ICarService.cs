using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByColorId(int colorId);
        List<Car> GetByBrandId(int brandId);
        Car GetById(int carId);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}

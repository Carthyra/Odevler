using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            var allcars = _carDal.GetAll();
            return allcars;
        }

        public List<Car> GetByColorId(int colorId)
        {
            var colorcars = _carDal.GetAll(c => c.ColorId == colorId);
            return colorcars;
        }

        public List<Car> GetByBrandId(int brandId)
        {
            var brandcars = _carDal.GetAll(c => c.BrandId == brandId);
            return brandcars;
        }

        public Car GetById(int carId)
        {
            var car = _carDal.Get(c => c.CarId == carId);
            return car;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

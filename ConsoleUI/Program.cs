using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carmanager = new CarManager(new EfCarDal());

            // carmanager.Add(new Car{CarId = 22,ColorId = 8,BrandId = 10,DailyPrice = 10000,ModelYear = 2100,Description = "Ankara"});

            // carmanager.Update(new Car{CarId = 22,ColorId = 18}); update nasıl çalışıyor

            Console.WriteLine(carmanager.GetById(22).DailyPrice);
        }
    }
}

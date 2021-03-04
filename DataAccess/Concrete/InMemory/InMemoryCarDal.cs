using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {

                new Car{ Id=1, BrandId=3, CarName="coursa", ColorId=1, ModelYear=2020, DailyPrice=220, Description="Opel  3.5 Önden Çekişli"},
                new Car{ Id=2, BrandId=4, CarName="01", ColorId=3, ModelYear=2018, DailyPrice=600, Description="BMW  2.0 Düz Vites"},
                new Car{ Id=3, BrandId=8, CarName="Megan", ColorId=5, ModelYear=2021, DailyPrice=100, Description="Renault  1.5 Manuel"},
                new Car{ Id=4, BrandId=6, CarName="midi", ColorId=4, ModelYear=2006, DailyPrice=460, Description="Mini Couper 1.5 Düz Vites"},
                new Car{ Id=5, BrandId=1, CarName="A3", ColorId=2, ModelYear=2018, DailyPrice=440, Description="Audi  2.6 Arkadan Çekişli"}
           
            };
        }
        public void Add(Car car)
        {
            {
                _cars.Add(car);
            }
         
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Car> GetCarsByBrandName(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetCarsByColorName(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }
    }
}

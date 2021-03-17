using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
       
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

       [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.AddedNot);
            }
            carImage.CarImageDate = DateTime.Now;
            carImage.ImagePath = FileHelper.Add(file);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);

        }


        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = CheckIfCarImageNull(carId);

            return new SuccessDataResult<List<CarImage>>(result);

        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var updatedPath = _carImageDal.Get(c => c.Id == carImage.Id).ImagePath;
            var newPath = FileHelper.Update(updatedPath, file);
            carImage.ImagePath = newPath;
            carImage.CarImageDate= DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        //BusinessRules

        public List<CarImage> CheckIfCarImageNull(int carId)
        {
            string path = @"/Images/carImages/default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Any())
            {
                return result;

            }

            return new List<CarImage>() { new CarImage { Id = 0, CarId = carId, CarImageDate = DateTime.MinValue, ImagePath = path } };

        }
        public IResult CheckCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
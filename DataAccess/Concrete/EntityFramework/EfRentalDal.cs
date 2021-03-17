using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarContext>, IRentalDal
    {
        //public List<RentalDetailDto> GetRentalDetails()
        //{
        //    using (ReCarContext context = new ReCarContext())
        //    {
        //        var result = from r in context.Rentals
        //                     join u in context.Users
        //                     on u.Id equals r.Id
        //                     join c in context.Customers
        //                     on r.CustomerId equals c.Id
        //                     select new CarDetailDto
        //                     {
        //                         Id = c.Id,
        //                         //BrandId = b.BrandId,
        //                         //ColorId = co.ColorId,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description,
        //                         CarName = c.CarName,
        //                         BrandName = b.BrandName,
        //                         ColorName = co.ColorName


        //                     };
        //        return result.ToList();


        //    }
        //}
        public List<RentalDetailDto> GetRentalDetails()
        {
            throw new NotImplementedException();
        }
    }
}

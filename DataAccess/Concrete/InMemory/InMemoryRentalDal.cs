using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryRentalDal : IRentalDal

    {

        List<Rental> _rentals;
        public InMemoryRentalDal()
        {
            _rentals = new List<Rental>
            {

                new Rental{ Id=25,  CarId=1, CustomerId=33, },

            };
        }
        public void Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}

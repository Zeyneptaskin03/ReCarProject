using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Concrete;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}

using Core.Concrete;
using Core.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
    }
}

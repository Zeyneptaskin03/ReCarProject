using Core.Utilities.Result;
using Core.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Concrete;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
    }
}

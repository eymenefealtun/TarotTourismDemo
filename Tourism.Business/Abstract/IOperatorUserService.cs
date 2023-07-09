﻿
namespace Tourism.Entities.Concrete
{
    public interface IOperatorUserService
    {
        OperatorUser GetByUserId(int userId);
        OperatorUser GetByUsernameAndPassword(string username, string password);
        List<OperatorUser> GetAll();
        OperatorUser Add(OperatorUser operatorUser);
        OperatorUser Update(OperatorUser operatorUser);

    }
}

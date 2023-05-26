using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        T GetOperationInformation(int operationId);
        List<T> GetAllWithFilter(Expression<Func<T, bool>> filter = null);
        List<T> GetAll();
        List<T> GetOperationMain();
        List<T> GetDailySale();
        List<T> GetCustomerOperation(int operationId);
        List<T> SearchCustomerOperation(string name, int operationId);
        List<T> SearchOperationMain(string documentCode, int? mainCategoryId, int? subCategoryId, DateTime startDate, DateTime endDate, int operatorId);
        List<T> GetCustomers();
        T Add(T entity);
        T Update(T entity);

    }
}

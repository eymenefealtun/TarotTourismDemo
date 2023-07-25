using System.Linq.Expressions;
using Tourism.Core.Entities;
            
namespace Tourism.Core.DataAccess.EntityFramework.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        List<T> BulkUpdate(List<T> entity);
        List<T> BulkInsert(List<T> entity);         
        List<T> BulkDelete(List<T> entity);         

        #region Old
        // List<T> GetOperationMain();
        //List<T> GetCustomerOperation(int operationId, bool isActive);
        //List<T> GetCustomerOperationByReservationId(int operationId, int reservationId, bool isActive);
        //List<T> SearchCustomerOperation(string name, int operationId, bool isActive);
        //List<T> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate, int operatorId, int currencyId, bool isActive); 
        //T GetOperationInformation(int operationId);
        //List<T> GetDailySale();
        //List<T> GetCustomers();


        #endregion

    }
}

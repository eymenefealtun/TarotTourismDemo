using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfOperationInformationDal : EfEntityRepositoryBase<OperationInformation, AppDbContext>, IOperationInformationDal
    {
        public OperationInformation GetOperationInformation(int operationId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<OperationInformation>().FromSqlRaw($"SELECT O.Note, O.Id 'OperationId',O.LastUpdatedBy 'UpdateUserId', O.CreatedBy 'CreateUserId',O.DocumentCode, O.StartDate, O.EndDate, O.Description, O.CreatedDate,O.LastUpdated,Ou.Username 'CreatedBy', OuUp.Username'LastUpdatedBy',C.Id 'CurrencyId',Mc.Id'MainCategoryId',Sc.Id'SubCategoryId', O.IsActive, Op.SingleRoom,Op.DoubleRoom,OP.TripleRoom,OP.QuadRoom,OP.Baby,OP.Child,OPr.Name'CreatedByOperator', O.RowVersion 'OperationRowVersion', Op.RowVersion 'OperationPriceRowVersion' FROM Operations O LEFT JOIN OperationPrices Op ON Op.OperationId = O.Id LEFT JOIN SubCategory Sc ON Sc.Id = O.SubCategoryId LEFT JOIN MainCategory Mc ON Mc.Id = Sc.MainCategoryId LEFT JOIN Currencies C ON C.Id = O.CurrencyId LEFT JOIN OperatorUsers Ou ON Ou.Id = O.CreatedBy LEFT JOIN OperatorUsers OuUp ON OuUp.Id = O.LastUpdatedBy LEFT JOIN Operators Opr ON Opr.Id = Ou.OperatorId Where O.Id = {operationId} ").SingleOrDefault();
            }
        }
    }
}

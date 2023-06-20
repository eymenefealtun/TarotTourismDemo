using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfOperationMainDal : EfEntityRepositoryBase<OperationMain, AppDbContext>, IOperationMainDal
    {
        public List<OperationMain> GetOperationMain()       
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<OperationMain>().FromSqlRaw(@"SELECT O.DocumentCode,Op.Name'Operator',O.StartDate,O.EndDate, SUM(R.Pax)  'Pax', SUM(R.Room)'Room',C.Name 'Currency', O.Id,Sc.Id 'SubCategoryId' FROM Operations O   
        FULL JOIN Reservations R ON R.OperationId = O.Id
        FULL  JOIN SubCategory Sc ON sc.Id = O.SubCategoryId
        FULL  JOIN MainCategory Mc ON Mc.Id = Sc.MainCategoryId                 
        FULL  JOIN Currencies C ON C.Id = O.CurrencyId
        FULL  JOIN OperatorUsers Opu ON Opu.Id = O.CreatedBy            
        FULL  JOIN Operators Op ON Op.Id = Opu.OperatorId
        WHERE O.DocumentCode IS NOT NULL AND O.IsActive = 1 AND ( (R.IsActive = 1 OR (R.Pax Is Null OR R.Pax = 0 ) ))
        GROUP BY  O.DocumentCode,O.StartDate,O.EndDate,C.Name,Op.Name,O.Id,Sc.Id
        ORDER BY O.StartDate
        ").AsNoTracking().ToList();
            }
        }

        public List<OperationMain> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate, int operatorId, int currencyId, bool isActive)
        {
            using (AppDbContext context = new AppDbContext())
            {
                //return context.Set<TEntity>().FromSqlRaw($"SELECT O.DocumentCode,Op.Name'Operator',O.StartDate,O.EndDate,SUM(R.Pax) 'Pax', SUM(R.Room)'Room',C.Name 'Currency' FROM Reservations R FULL JOIN Operations O ON O.Id = R.OperationId FULL  JOIN SubCategory Sc ON sc.Id = O.SubCategoryId FULL  JOIN MainCategory Mc ON Mc.Id = Sc.MainCategoryId FULL  JOIN Currencies C ON C.Id = O.CurrencyId FULL  JOIN OperatorUsers Opu ON Opu.Id = O.CreatedBy FULL  JOIN Operators Op ON Op.Id = Opu.OperatorId WHERE ( O.DocumentCode LIKE '%{documentCode}%' OR '%{documentCode}%' Is NULL) AND (Mc.Id = {mainCategoryId} OR {mainCategoryId}  IS NULL) AND  O.DocumentCode IS NOT NULL GROUP BY  O.DocumentCode,O.StartDate,O.EndDate,C.Name,Op.Name").ToList();
                #region ProcedureFull
                //                ALTER PROCEDURE sp_get_products_mainsearch
                //@documentCode varchar(50),
                //@mainCategory int,
                //@subCategory int,
                //@startDate date,
                //@endDate date,        
                //@operator int
                //AS
                //BEGIN
                //SELECT O.DocumentCode,Op.Name'Operator',O.StartDate,O.EndDate,SUM(R.Pax) 'Pax', SUM(R.Room)'Room',C.Name 'Currency' FROM Reservations R
                //FULL JOIN Operations O ON O.Id = R.OperationId
                //FULL JOIN SubCategory Sc ON sc.Id = O.SubCategoryId
                //FULL JOIN MainCategory Mc ON Mc.Id = Sc.MainCategoryId
                //FULL JOIN Currencies C ON C.Id = O.CurrencyId
                //FULL JOIN OperatorUsers Opu ON Opu.Id = O.CreatedBy
                //FULL JOIN Operators Op ON Op.Id = Opu.OperatorId
                //WHERE(Mc.Id = @mainCategory OR @mainCategory = 0) AND(Sc.Id = @subCategory OR @subCategory = 0) AND(O.DocumentCode LIKE '%' + @documentCode + '%' OR '%' + @documentCode + '%' IS NULL) AND(O.StartDate >= @startDate OR @startDate IS NULL) AND(O.StartDate <= @endDate OR @endDate Is NULL) AND(Op.Id = @operator OR @operator = 0)  AND O.DocumentCode IS NOT NULL
                //GROUP BY  O.DocumentCode,O.StartDate,O.EndDate,C.Name,Op.Name OPTION(RECOMPILE)
                //END
                #endregion
                return context.Set<OperationMain>().FromSqlInterpolated($"EXEC sp_get_products_mainsearch {documentCode},{mainCategoryId},{subCategoryId},{startDate},{endDate}, {operatorId}, {currencyId}, {isActive}").AsNoTracking().ToList();
            }
        }



    }
}

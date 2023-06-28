using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
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
                return context.Set<OperationMain>().FromSqlRaw(@"SELECT O.DocumentCode,Op.Name'Operator',O.StartDate,O.EndDate, SUM(R.Pax)  'Pax', SUM(R.RoomId)'Room',C.Name 'Currency', O.Id,Sc.Id 'SubCategoryId',SUM(R.DiscountedPrice) 'CurrentIncome' FROM Operations O   
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
                #region ProcedureFull
                //                USE[Tourism]
                //GO

                ///****** Object:  StoredProcedure [dbo].[sp_get_products_mainsearch]    Script Date: 26/06/23 12:48:23 PM ******/
                //SET ANSI_NULLS ON
                //GO

                //SET QUOTED_IDENTIFIER ON
                //GO






                //CREATE PROCEDURE[dbo].[sp_get_products_mainsearch]
                //@documentCode varchar(50),
                //@mainCategory int,
                //@subCategory int,
                //@startDate date,
                //@endDate date,
                //@operator int,
                //@currencyId int,
                //@IsActive bit
                //AS
                //BEGIN
                //SELECT O.DocumentCode,Op.Name'Operator',O.StartDate,O.EndDate,(SELECT SUM(R.Pax)) 'Pax', SUM(R.Room)'Room',C.Name 'Currency',O.Id,Sc.Id'SubCategoryId' FROM Operations O
                //FULL JOIN Reservations R ON R.OperationId = O.Id
                //FULL JOIN SubCategory Sc ON sc.Id = O.SubCategoryId
                //FULL JOIN MainCategory Mc ON Mc.Id = Sc.MainCategoryId
                //FULL JOIN Currencies C ON C.Id = O.CurrencyId
                //FULL JOIN OperatorUsers Opu ON Opu.Id = O.CreatedBy
                //FULL JOIN Operators Op ON Op.Id = Opu.OperatorId
                //WHERE(Mc.Id = @mainCategory OR @mainCategory = 0) AND(Sc.Id = @subCategory OR @subCategory = 0) AND(O.DocumentCode LIKE '%' + @documentCode + '%' OR '%' + @documentCode + '%' IS NULL) AND(O.StartDate >= @startDate OR @startDate IS NULL) AND(O.StartDate <= @endDate OR @endDate Is NULL) AND(O.IsActive = @IsActive OR @IsActive = 1) AND(Op.Id = @operator OR @operator = 0) AND(O.CurrencyId = @currencyId OR @currencyId = 0)  AND O.DocumentCode IS NOT NULL AND((O.IsActive = @IsActive) AND(R.IsActive = 1 OR(R.Pax Is Null OR R.Pax = 0)))--OR R.Pax - (SELECT COUNT(*) FROM Reservations WHERE IsActive = 0 )= 0   )) --
                //                GROUP BY O.DocumentCode,O.StartDate,O.EndDate,C.Name,Op.Name,O.Id,Sc.Id OPTION(RECOMPILE)
                //END
                //GO



                #endregion
                return context.Set<OperationMain>().FromSqlInterpolated($" EXEC sp_get_products_mainsearch {documentCode},{mainCategoryId},{subCategoryId},{startDate},{endDate}, {operatorId}, {currencyId}, {isActive}").AsNoTracking().ToList();
            }
        }



    }
}

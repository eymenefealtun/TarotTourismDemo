﻿using Microsoft.EntityFrameworkCore;
using Ninject.Selection;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Tourism.DataAccess.Abstract;
using Tourism.Entities.Abstract;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : AppDbContext, new()
    {

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {

                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetOperationInformation(int operationId)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FromSqlRaw($"SELECT O.Note, O.Id 'OperationId',O.LastUpdatedBy 'UpdateUserId', O.CreatedBy 'CreateUserId',O.DocumentCode, O.StartDate, O.EndDate, O.Description, O.CreatedDate,O.LastUpdated,Ou.Username 'CreatedBy', OuUp.Username'LastUpdatedBy',C.Id 'CurrencyId',Mc.Id'MainCategoryId',Sc.Id'SubCategoryId', O.IsActive, Op.SingleRoom,Op.DoubleRoom,OP.TripleRoom,OP.QuadRoom,OP.Baby,OP.Child,OPr.Name'CreatedByOperator', O.RowVersion 'OperationRowVersion', Op.RowVersion 'OperationPriceRowVersion' FROM Operations O LEFT JOIN OperationPrices Op ON Op.OperationId = O.Id LEFT JOIN SubCategory Sc ON Sc.Id = O.SubCategoryId LEFT JOIN MainCategory Mc ON Mc.Id = Sc.MainCategoryId LEFT JOIN Currencies C ON C.Id = O.CurrencyId LEFT JOIN OperatorUsers Ou ON Ou.Id = O.CreatedBy LEFT JOIN OperatorUsers OuUp ON OuUp.Id = O.LastUpdatedBy LEFT JOIN Operators Opr ON Opr.Id = Ou.OperatorId Where O.Id = {operationId} ").SingleOrDefault();
            }
        }

        public List<TEntity> GetOperationMain()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FromSqlRaw(@"SELECT O.DocumentCode,Op.Name'Operator',O.StartDate,O.EndDate,SUM(R.Pax) 'Pax', SUM(R.Room)'Room',C.Name 'Currency', O.Id FROM Reservations R
FULL JOIN Operations O ON O.Id = R.OperationId
FULL  JOIN SubCategory Sc ON sc.Id = O.SubCategoryId
FULL  JOIN MainCategory Mc ON Mc.Id = Sc.MainCategoryId                 
FULL  JOIN Currencies C ON C.Id = O.CurrencyId
FULL  JOIN OperatorUsers Opu ON Opu.Id = O.CreatedBy            
FULL  JOIN Operators Op ON Op.Id = Opu.OperatorId
WHERE O.DocumentCode IS NOT NULL AND O.IsActive = 1
GROUP BY  O.DocumentCode,O.StartDate,O.EndDate,C.Name,Op.Name,O.Id
ORDER BY O.StartDate").AsNoTracking().ToList();
            }
        }
        public List<TEntity> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate, int operatorId, int currencyId, bool isActive)
        {
            using (TContext context = new TContext())
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
                return context.Set<TEntity>().FromSqlInterpolated($"EXEC sp_get_products_mainsearch {documentCode},{mainCategoryId},{subCategoryId},{startDate},{endDate}, {operatorId}, {currencyId}, {isActive}").AsNoTracking().ToList();
            }
        }

        public List<TEntity> GetDailySale()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FromSqlRaw(@"SELECT Ops.Name 'Operator' ,A.Name 'Agency',(SELECT CONCAT(o.StartDate,' | ', o.EndDate) )AS Period ,R.ReservationCode, R.Pax, R.Room,R.TotalPrice,O.DocumentCode,C.Name'Currency', Au.Username 'PurchasedBy', R.CreatedDate  FROM Operations O  --R.ReservationCode,R.Pax, R.Room, R.TotalPrice 
JOIN Reservations R ON R.OperationId = O.ID
JOIN OperationPrices Op ON Op.OperationId = O.Id
JOIN OperatorUsers Ou ON Ou.Id = O.CreatedBy
JOIN Operators Ops ON Ops.Id = Ou.OperatorId
JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId
JOIN Agencies A ON A.Id = Au.AgencyId
JOIN Currencies C ON C.Id = O.CurrencyId
ORDER BY R.CreatedDate DESC
").AsNoTracking().ToList();
            }
        }

        public List<TEntity> GetCustomerOperation(int operationId)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FromSqlRaw($"SELECT C.FirstName, C.LastName, C.Phone, C.BirthDate, C.Gender, C.IdNumber,Ro.Id'RoomId',R.Id'ReservationId',B.Name 'BedType', R.ReservationCode, A.Name 'Agency' From Customers C JOIN Rooms Ro ON Ro.Id = C.RoomId JOIN BedTypes B ON B.Id = Ro.BedTypeId JOIN Reservations R ON R.Id = Ro.ReservationId JOIN Operations O ON O.Id = R.OperationId JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId JOIN Agencies A ON A.Id = Au.AgencyId WHERE O.Id = {operationId} ORDER BY Ro.ReservationId").AsNoTracking().ToList();
            }
        }

        public List<TEntity> GetCustomers()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FromSqlRaw(@"SELECT C.FirstName, C.LastName, C.Phone, C.BirthDate, C.Gender, C.IdNumber,Ro.Id'RoomId',R.Id'ReservationId',B.Name 'BedType',R.ReservationCode, A.Name 'Agency' From Customers C 
JOIN Rooms Ro ON Ro.Id = C.RoomId           
JOIN BedTypes B ON B.Id = Ro.BedTypeId      
JOIN Reservations R ON R.Id = Ro.ReservationId 
JOIN Operations O ON O.Id = R.OperationId 
JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId 
JOIN Agencies A ON A.Id = Au.AgencyId
ORDER BY Ro.ReservationId").ToList();
            }
        }

        public List<TEntity> SearchCustomerOperation(string name, int operationId)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FromSqlRaw($"SELECT C.FirstName, C.LastName, C.Phone, C.BirthDate, C.Gender, C.IdNumber,Ro.Id'RoomId',R.Id'ReservationId',B.Name 'BedType',R.ReservationCode,O.Id From Customers C JOIN Rooms Ro ON Ro.Id = C.RoomId JOIN BedTypes B ON B.Id = Ro.BedTypeId JOIN Reservations R ON R.Id = Ro.ReservationId JOIN Operations O ON O.Id = R.OperationId WHERE C.FirstName LIKE '%{name}%' AND O.Id = {operationId} ORDER BY Ro.ReservationId").AsNoTracking().ToList();
            }
        }



        public TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
                return entity;
            }
        }


    }
}

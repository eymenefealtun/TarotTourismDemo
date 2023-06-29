using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfIncomeInformationDal : EfEntityRepositoryBase<IncomeInformation, AppDbContext>, IIncomeInformationDal
    {
        public IncomeInformation TotalIncomeByFar()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome'  FROM Reservations R").AsNoTracking().SingleOrDefault();
            }
        }

        public List<IncomeInformation> GetByOperation(int operationId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId WHERE (O.Id = {0} OR O.Id = 0)", operationId).AsNoTracking().ToList();
            }
        }

        public IncomeInformation TotalIncomeBySubCategory(int subCategoryId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R FULL  JOIN Operations O ON O.Id = R.OperationId FULL  JOIN SubCategory S ON S.Id = O.SubCategoryId FULL  JOIN MainCategory M ON M.Id = S.MainCategoryId WHERE s.Id = {0} ", subCategoryId).AsNoTracking().SingleOrDefault();
            }
        }
        public IncomeInformation TotalIncomeByMainCategory(int mainCategoryId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R FULL  JOIN Operations O ON O.Id = R.OperationId FULL  JOIN SubCategory S ON S.Id = O.SubCategoryId FULL  JOIN MainCategory M ON M.Id = S.MainCategoryId WHERE M.Id = {0} ", mainCategoryId).AsNoTracking().SingleOrDefault();
            }
        }


        public IncomeInformation TotalIncomeByReservation(int reservationId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId WHERE R.Id = {0}", reservationId).AsNoTracking().SingleOrDefault();
            }
        }

        public IncomeInformation TotalIncomeByAgencyUser(int agencyUserId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId JOIN AgencyUsers A on R.AgencyUserId = A.Id WHERE A.Id = {0} ", agencyUserId).AsNoTracking().SingleOrDefault();
            }
        }
        public IncomeInformation TotalIncomeByAgency(int agencyId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId JOIN AgencyUsers A on R.AgencyUserId = A.Id JOIN Agencies Ag on A.AgencyId = Ag.Id WHERE Ag.Id = {0}", agencyId).AsNoTracking().SingleOrDefault();
            }
        }
        public IncomeInformation TotalIncomeByOperator(int operatorId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId JOIN OperatorUsers OpU ON O.CreatedBy = Opu.Id JOIN Operators Op ON Op.Id = OpU.OperatorId JOIN AgencyUsers A on R.AgencyUserId = A.Id WHERE Op.Id = {0}", operatorId).AsNoTracking().SingleOrDefault();
            }
        }
        public IncomeInformation TotalIncomeByCurrency(int currencyId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId JOIN Currencies C ON C.Id = O.CurrencyId WHERE C.Id = {0} ", currencyId).AsNoTracking().SingleOrDefault();
            }
        }

        public IncomeInformation TotalIncomeByBedType(int bedTypeId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice)  'TotalIncome' FROM BedTypes B JOIN Rooms Ro On Ro.BedTypeId = B.Id JOIN Reservations R ON R.Id = Ro.ReservationId WHERE Ro.BedTypeId = {0} ", bedTypeId).AsNoTracking().SingleOrDefault();
            }
        }

        public IncomeInformation NumberOfBedSold(int bedTypeId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT CAST(COUNT(B.Id) AS decimal(18,2)) 'TotalIncome' FROM BedTypes B JOIN Rooms Ro On Ro.BedTypeId = B.Id JOIN Reservations R ON R.Id = Ro.ReservationId WHERE B.Id = {0} ", bedTypeId).AsNoTracking().SingleOrDefault();
            }
        }



    }
}
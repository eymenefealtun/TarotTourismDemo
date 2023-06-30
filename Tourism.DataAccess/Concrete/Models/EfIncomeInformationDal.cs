using Microsoft.EntityFrameworkCore;
using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfIncomeInformationDal : EfEntityRepositoryBase<IncomeInformation, AppDbContext>, IIncomeInformationDal
    {
        public IncomeInformation TotalIncomeByFar()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw("SELECT SUM(R.DiscountedPrice) 'TotalIncome', null 'Name' FROM Reservations R").AsNoTracking().SingleOrDefault();
            }
        }

        public List<IncomeInformation> GetByOperation(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome', O.DocumentCode 'Name' FROM Reservations R JOIN Operations O ON O.Id = R.OperationId  WHERE (O.DocumentCode LIKE '%{name}%' OR O.DocumentCode Is NULL) AND O.DocumentCode Is Not NULL GROUP BY O.DocumentCode").AsNoTracking().ToList();
            }
        }

        public List<IncomeInformation> TotalIncomeBySubCategory(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome' , S.Name 'Name' FROM Reservations R FULL  JOIN Operations O ON O.Id = R.OperationId FULL  JOIN SubCategory S ON S.Id = O.SubCategoryId FULL  JOIN MainCategory M ON M.Id = S.MainCategoryId WHERE (S.Name LIKE '%{name}%' OR S.Name Is NULL) AND S.Name Is Not NULL GROUP BY S.Name").AsNoTracking().ToList();
            }
        }
        public List<IncomeInformation> TotalIncomeByMainCategory(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome',  M.Name 'Name' FROM Reservations R FULL  JOIN Operations O ON O.Id = R.OperationId FULL  JOIN SubCategory S ON S.Id = O.SubCategoryId FULL  JOIN MainCategory M ON M.Id = S.MainCategoryId  WHERE (M.Name LIKE '%{name}%' OR M.Name Is NULL) AND M.Name Is Not NULL GROUP BY M.Name").AsNoTracking().ToList();
            }
        }


        public List<IncomeInformation> TotalIncomeByReservation(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome' , R.ReservationCode 'Name' FROM Reservations R  FULL JOIN Operations O ON O.Id = R.OperationId  WHERE (R.ReservationCode LIKE '%{name}%' OR R.ReservationCode Is NULL) AND R.ReservationCode Is Not NULL GROUP BY R.ReservationCode").AsNoTracking().ToList();
            }
        }

        public List<IncomeInformation> TotalIncomeByAgencyUser(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome', A.Username 'Name'  FROM Reservations R  FULL JOIN Operations O ON O.Id = R.OperationId FULL  JOIN AgencyUsers A on R.AgencyUserId = A.Id WHERE (A.Username LIKE '%{name}%' OR A.Username Is NULL) AND A.Username Is Not NULL  GROUP BY A.Username ").AsNoTracking().ToList();
            }
        }
        public List<IncomeInformation> TotalIncomeByAgency(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome' , Ag.Name 'Name' FROM Reservations R  FULL JOIN Operations O ON O.Id = R.OperationId FULL  JOIN AgencyUsers A on R.AgencyUserId = A.Id  FULL JOIN Agencies Ag on A.AgencyId = Ag.Id WHERE (Ag.Name LIKE '%{name}%' OR Ag.Name Is NULL) AND Ag.Name Is Not NULL GROUP BY Ag.Name").AsNoTracking().ToList();
            }
        }
        public List<IncomeInformation> TotalIncomeByOperator(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome' , Op.Name 'Name' FROM Reservations R  FULL JOIN Operations O ON O.Id = R.OperationId  FULL JOIN OperatorUsers OpU ON O.CreatedBy = Opu.Id JOIN Operators Op ON Op.Id = OpU.OperatorId JOIN AgencyUsers A on R.AgencyUserId = A.Id  WHERE (Op.Name LIKE '%{name}%' OR Op.Name Is NULL) AND Op.Name Is Not NULL GROUP BY Op.Name").AsNoTracking().ToList();
            }
        }
        public List<IncomeInformation> TotalIncomeByCurrency(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice) 'TotalIncome' , C.Name 'Name' FROM Reservations R  FULL JOIN Operations O ON O.Id = R.OperationId FULL  JOIN Currencies C ON C.Id = O.CurrencyId WHERE (C.Name LIKE '%{name}%' OR C.Name Is NULL) AND C.Name Is Not NULL  GROUP BY C.Name ").AsNoTracking().ToList();
            }
        }

        public List<IncomeInformation> TotalIncomeByBedType(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT SUM(R.DiscountedPrice)  'TotalIncome' ,  B.Name 'Name' FROM BedTypes B  FULL JOIN Rooms Ro On Ro.BedTypeId = B.Id  FULL JOIN Reservations R ON R.Id = Ro.ReservationId WHERE (B.Name LIKE '%{name}%' OR B.Name Is NULL) AND B.Name Is Not NULL GROUP BY B.Name").AsNoTracking().ToList();
            }
        }

        public List<IncomeInformation> NumberOfBedSold(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<IncomeInformation>().FromSqlRaw($"SELECT CAST(COUNT(R.Id) AS decimal(18,2)) 'TotalIncome' ,  B.Name 'Name' FROM BedTypes B FULL JOIN Rooms Ro On Ro.BedTypeId = B.Id  FULL JOIN Reservations R ON R.Id = Ro.ReservationId WHERE (B.Name LIKE '%{name}%' OR B.Name Is NULL)  AND B.Name Is Not NULL GROUP BY B.Name").AsNoTracking().ToList();
            }
        }



    }
}
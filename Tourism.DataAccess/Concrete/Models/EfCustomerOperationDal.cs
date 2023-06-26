using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Models;
using Tourism.Core.DataAccess.EntityFramework.Concrete;

namespace Tourism.DataAccess.Concrete.Models
{
    public class EfCustomerOperationDal : EfEntityRepositoryBase<CustomerOperation, AppDbContext>, ICustomerOperationDal
    {

        public List<CustomerOperation> GetCustomerOperation(int operationId, bool isActive)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<CustomerOperation>().FromSqlRaw($"SELECT (CASE WHEN lag_BedType is null THEN B.Name ELSE NULL END )AS BedType,Ro.Id'RoomId',C.Id 'CustomerId', C.FirstName 'FirstName',C.LastName, C.Phone, C.BirthDate, C.Gender, C.IdNumber,R.Id'ReservationId',B.Id'BedTypeId', R.ReservationCode, A.Name 'Agency',R.IsActive'IsActive', C.RowVersion 'CustomerRowVersion' FROM ( SELECT * , lag(RoomId) OVER (PARTITION BY RoomId ORDER BY FirstName) AS lag_BedType FROM Customers ) C JOIN Rooms Ro ON Ro.Id = C.RoomId  JOIN BedTypes B ON B.Id = Ro.BedTypeId   JOIN Reservations R ON R.Id = Ro.ReservationId  JOIN Operations O ON O.Id = R.OperationId JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId JOIN Agencies A ON A.Id = Au.AgencyId WHERE O.Id = {operationId} AND R.IsActive = {Convert.ToInt32(isActive)} ORDER BY Ro.ReservationId").AsNoTracking().ToList();
            }
        }

        public List<CustomerOperation> GetCustomerOperationByReservationId(int operationId, int reservationId, bool isActive)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<CustomerOperation>().FromSqlRaw($"SELECT (CASE WHEN lag_BedType is null THEN B.Name ELSE NULL END )AS BedType,Ro.Id'RoomId',C.Id 'CustomerId', C.FirstName 'FirstName',C.LastName, C.Phone, C.BirthDate, C.Gender, C.IdNumber,R.Id'ReservationId',B.Id'BedTypeId', R.ReservationCode, A.Name 'Agency',R.IsActive'IsActive', C.RowVersion 'CustomerRowVersion' FROM ( SELECT * , lag(RoomId) OVER (PARTITION BY RoomId ORDER BY FirstName) AS lag_BedType FROM Customers ) C JOIN Rooms Ro ON Ro.Id = C.RoomId  JOIN BedTypes B ON B.Id = Ro.BedTypeId   JOIN Reservations R ON R.Id = Ro.ReservationId  JOIN Operations O ON O.Id = R.OperationId JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId JOIN Agencies A ON A.Id = Au.AgencyId WHERE O.Id = {operationId} AND R.Id = {reservationId} AND R.IsActive = {Convert.ToInt32(isActive)}  ORDER BY Ro.ReservationId").AsNoTracking().ToList();
            }
        }

        public List<CustomerOperation> SearchCustomerOperation(string name, int operationId, bool isActive)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<CustomerOperation>().FromSqlRaw($"SELECT C.FirstName, C.LastName, C.Phone, C.BirthDate,B.Id'BedTypeId', C.Gender, C.IdNumber,Ro.Id'RoomId',R.Id'ReservationId',B.Name 'BedType',R.ReservationCode,O.Id,R.IsActive'IsActive',C.Id'CustomerId', A.Name 'Agency', C.RowVersion 'CustomerRowVersion' From Customers C JOIN Rooms Ro ON Ro.Id = C.RoomId jOIN BedTypes B ON B.Id = Ro.BedTypeId JOIN Reservations R ON R.Id = Ro.ReservationId JOIN Operations O ON O.Id = R.OperationId JOIN AgencyUsers Au On Au.Id = R.AgencyUserId JOIN Agencies A ON A.Id = Au.AgencyId WHERE C.FirstName LIKE '%{name}%' AND O.Id = {operationId} AND R.IsActive = {Convert.ToInt32(isActive)} ORDER BY Ro.ReservationId").AsNoTracking().ToList();
            }
        }

        public List<CustomerOperation> GetCustomers()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<CustomerOperation>().FromSqlRaw(@"SELECT C.FirstName,C.Id 'CustomerId', C.LastName, C.Phone, C.BirthDate, C.Gender, C.IdNumber,Ro.Id'RoomId',R.Id'ReservationId',B.Name 'BedType',R.ReservationCode, A.Name 'Agency',B.Id 'BedTypeId',R.IsActive'IsActive', C.RowVersion 'CustomerRowVersion' From Customers C 
JOIN Rooms Ro ON Ro.Id = C.RoomId           
JOIN BedTypes B ON B.Id = Ro.BedTypeId      
JOIN Reservations R ON R.Id = Ro.ReservationId 
JOIN Operations O ON O.Id = R.OperationId 
JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId 
JOIN Agencies A ON A.Id = Au.AgencyId
ORDER BY Ro.ReservationId").ToList();
            }
        }

        public List<CustomerOperation> GetCustomersWithFilter(string firstName, string id, string reservationCode)
        {
            using (AppDbContext context = new AppDbContext())
            {
                #region raw
                //                USE[Tourism]
                //GO

                ///****** Object:  StoredProcedure [dbo].[sp_get_customers_searchAllCustomers]    Script Date: 26/06/23 12:47:46 PM ******/
                //SET ANSI_NULLS ON
                //GO

                //SET QUOTED_IDENTIFIER ON
                //GO




                //CREATE PROCEDURE[dbo].[sp_get_customers_searchAllCustomers]
                //@firstName nvarchar(100),
                //@id varchar(100),
                //@reservationCode varchar(100)
                //AS
                //BEGIN
                //SELECT C.FirstName,C.Id 'CustomerId', C.LastName, C.Phone, C.BirthDate, C.Gender, C.IdNumber,Ro.Id'RoomId',R.Id'ReservationId',B.Name 'BedType',R.ReservationCode, A.Name 'Agency',B.Id 'BedTypeId',R.IsActive'IsActive', C.RowVersion 'CustomerRowVersion' From Customers C
                //JOIN Rooms Ro ON Ro.Id = C.RoomId
                //JOIN BedTypes B ON B.Id = Ro.BedTypeId
                //JOIN Reservations R ON R.Id = Ro.ReservationId
                //JOIN Operations O ON O.Id = R.OperationId
                //JOIN AgencyUsers Au ON Au.Id = R.AgencyUserId
                //JOIN Agencies A ON A.Id = Au.AgencyId
                //WHERE(C.FirstName LIKE '%' + @firstName + '%' OR '%' + @firstName + '%' IS NULL) AND(C.IdNumber LIKE '%' + @id + '%' OR '%' + @id + '%' IS NULL) AND(R.ReservationCode LIKE '%' + @reservationCode + '%' OR '%' + @reservationCode + '%' IS NULL)
                //END
                //GO 
                #endregion
                return context.Set<CustomerOperation>().FromSqlInterpolated($"EXEC sp_get_customers_searchAllCustomers {firstName}, {id}, {reservationCode}").ToList();
            }
        }


    }
}

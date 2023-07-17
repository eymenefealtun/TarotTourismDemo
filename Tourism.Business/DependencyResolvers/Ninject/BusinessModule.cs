using Ninject.Modules;
using Tourism.Business.Abstract;
using Tourism.Business.Abstract.Models;
using Tourism.Business.Authentication;
using Tourism.Business.Concrete;
using Tourism.Business.Concrete.Models;
using Tourism.DataAccess.Abstract;
using Tourism.DataAccess.Abstract.Models;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.DataAccess.Concrete.Models;
using Tourism.Entities.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IOperationService>().To<OperationManager>().InSingletonScope();
            Bind<IOperationDal>().To<EfOperationDal>().InSingletonScope();

            Bind<IOperationMainService>().To<OperationMainManager>().InSingletonScope();
            Bind<IOperationMainDal>().To<EfOperationMainDal>().InSingletonScope();

            Bind<IDailySaleService>().To<DailySaleManager>().InSingletonScope();
            Bind<IDailySaleDal>().To<EfDailySaleDal>().InSingletonScope();

            Bind<ICustomerOperationService>().To<CustomerOperationManager>().InSingletonScope();
            Bind<ICustomerOperationDal>().To<EfCustomerOperationDal>().InSingletonScope();

            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<IMainCategoryService>().To<MainCategoryManager>().InSingletonScope();
            Bind<IMainCategoryDal>().To<EfMainCategoryDal>().InSingletonScope();

            Bind<ISubCategoryService>().To<SubCategoryManager>().InSingletonScope();
            Bind<ISubCategoryDal>().To<EfSubCategoryDal>().InSingletonScope();

            Bind<IUserLevelService>().To<UserLevelManager>().InSingletonScope();
            //   Bind<IUserLevelDal>().To<EfUserLevelDal>().InSingletonScope();



            Bind<IOperatorUserRoleService>().To<OperatorUserRoleManager>().InSingletonScope();
            Bind<IOperatorUserRoleDal>().To<EfOperatorUserRoleDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();


            Bind<ICurrencyService>().To<CurrencyManager>().InSingletonScope();
            Bind<ICurrencyDal>().To<EfCurrencyDal>().InSingletonScope();

            Bind<IOperationInformationService>().To<OperationInformationManager>().InSingletonScope();
            Bind<IOperationInformationDal>().To<EfOperationInformationDal>().InSingletonScope();

            Bind<IOperatorService>().To<OperatorManager>().InSingletonScope();
            Bind<IOperatorDal>().To<EfOperatorDal>().InSingletonScope();

            Bind<IAgencyUserService>().To<AgencyUserManager>().InSingletonScope();
            Bind<IAgencyUserDal>().To<EfAgencyUserDal>().InSingletonScope();

            Bind<IReservationService>().To<ReservationManager>().InSingletonScope();
            Bind<IReservationDal>().To<EfReservationDal>().InSingletonScope();

            Bind<IAgencyService>().To<AgencyManager>().InSingletonScope();
            Bind<IAgencyDal>().To<EfAgencyDal>().InSingletonScope();

            Bind<IOperatorUserService>().To<OperatorUserManager>().InSingletonScope();
            Bind<IOperatorUserDal>().To<EfOperatorUserDal>().InSingletonScope();

            Bind<IRoomService>().To<RoomManager>().InSingletonScope();
            Bind<IRoomDal>().To<EfRoomDal>().InSingletonScope();

            Bind<IBedTypeService>().To<BedTypeManager>().InSingletonScope();
            Bind<IBedTypeDal>().To<EfBedTypeDal>().InSingletonScope();

            Bind<IOperatorUserFullService>().To<OperatorUserFullManager>().InSingletonScope();
            Bind<IOperatorUserFullDal>().To<EfOperatorUserFullDal>().InSingletonScope();

            Bind<IIncomeInformationService>().To<IncomeInformationManager>().InSingletonScope();
            Bind<IIncomeInformationDal>().To<EfIncomeInformationDal>().InSingletonScope();



            Bind<IOperationPriceService>().To<OperationPriceManager>().InSingletonScope();
            Bind<IOperationPriceDal>().To<EfOperationPriceDal>().InSingletonScope();


            Bind<IAuthenticationService>().To<AuthenticationService>().InSingletonScope();
        }


    }
}

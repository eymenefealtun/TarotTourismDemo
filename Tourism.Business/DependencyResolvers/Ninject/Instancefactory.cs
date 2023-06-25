using Ninject;

namespace Tourism.Business.DependencyResolvers.Ninject
{
    public class Instancefactory //this part might be transfered to Tourism.Core
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }

    }
}

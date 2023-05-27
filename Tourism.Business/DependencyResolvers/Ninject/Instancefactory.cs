 using Ninject;

namespace Tourism.Business.DependencyResolvers.Ninject
{
    public class Instancefactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }

    }
}

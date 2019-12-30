using Ninject;

namespace chatapp.core
{
    public class IoC
    {
        #region Public Properties

        public static IKernel Kernel { get; private set; } = new StandardKernel();

        #endregion

        #region Construction

        public static void Setup() 
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            //Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

    }
}

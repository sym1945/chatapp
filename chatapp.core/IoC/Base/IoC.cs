using Ninject;

namespace chatapp.core
{
    public class IoC
    {
        #region Public Properties

        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static IUIManager UI => IoC.Get<IUIManager>();

        public static ILogFactory Logger => IoC.Get<ILogFactory>();

        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        public static SettingsViewModel Settings => IoC.Get<SettingsViewModel>();

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
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }

        #endregion

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

    }
}

/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DesignRSC"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace DesignRSC.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MeniPage>();
            SimpleIoc.Default.Register<ProfileViewModel>();
            SimpleIoc.Default.Register<ListItemManVM>();
            SimpleIoc.Default.Register<QRViewModel>();

            SimpleIoc.Default.Register(ConfigureNavigation);
        }

        protected INavigationService ConfigureNavigation()
        {
            var navigationService = new NavigationService();
            /*navigationService.Configure("LoginPage", typeof(LoginPage));
            navigationService.Configure("LandingPage", typeof(LandingPage));
            navigationService.Configure("ProjectPage", typeof(ProjectPage));
            navigationService.Configure("SubmitPage", typeof(SubmitPage));
            navigationService.Configure("RegisterPage", typeof(RegisterPage));*/
            return navigationService;
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public MeniPage Meni
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MeniPage>();
            }
        }

        public ListItemManVM Liste
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListItemManVM>();
            }
        }

        public ProfileViewModel Profil
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProfileViewModel>();
            }
        }

        public QRViewModel QR
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QRViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MyCompanyInThePocket.Core.Helpers;
using MvvmCross.Platform;
using MyCompanyInThePocket.UWP.Helpers;

namespace MyCompanyInThePocket.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }


        protected override void InitializeLastChance()
        {
            Mvx.RegisterType<ISqliteConnectionFactory, DroidSqliteConnectionFactory>();
            Mvx.RegisterType<IAuthentificationPlatformFactory, AuthentificationPlatformFactory>();
            base.InitializeLastChance();
        }
    }
}

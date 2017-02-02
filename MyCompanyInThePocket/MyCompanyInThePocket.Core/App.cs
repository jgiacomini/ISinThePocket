using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MyCompanyInThePocket.Core.Helpers;
using MyCompanyInThePocket.Core.Repositories.Interfaces;
using MyCompanyInThePocket.Core.Repositories.MockRepositories;

namespace MyCompanyInThePocket.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.SplashScreenViewModel>();

#if DEBUG
            Mvx.RegisterSingleton<IOnlineMeetingRepository>(new MyCompanyInThePocket.Core.Repositories.MockRepositories.MeetingRepository());
#else
            Mvx.RegisterSingleton<IOnlineMeetingRepository>(new MyCompanyInThePocket.Core.Repositories.OnlineRepositories.MeetingRepository(Mvx.Resolve<IAuthentificationPlatformFactory>()));
#endif
        }

    }
}

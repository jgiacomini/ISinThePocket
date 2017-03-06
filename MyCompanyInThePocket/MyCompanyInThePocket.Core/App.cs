using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MyCompanyInThePocket.Core.Helpers;
using MyCompanyInThePocket.Core.Repositories.Interfaces;

namespace MyCompanyInThePocket.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
		private bool _useMock = true;

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

			RegisterAppStart<ViewModels.SplashScreenViewModel>();

            if (_useMock)
            {
                Mvx.RegisterType<IOnlineMeetingRepository>(() => new MyCompanyInThePocket.Core.Repositories.MockRepositories.MeetingRepository());
				Mvx.RegisterType<IOnlineUseFullLinkRepository>(() => new MyCompanyInThePocket.Core.Repositories.MockRepositories.UseFullLinkRepository());
            }
            else
            {
                Mvx.RegisterType<IOnlineMeetingRepository>(() => new MyCompanyInThePocket.Core.Repositories.OnlineRepositories.MeetingRepository());
				//Mvx.RegisterType<IOnlineUseFullLinkRepository>(() => new MyCompanyInThePocket.Core.Repositories.OnlineRepositories.UseFullLinkRepository());
            }
        }

    }
}

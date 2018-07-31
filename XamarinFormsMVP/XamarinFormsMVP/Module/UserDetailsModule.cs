using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsMVP.Infrastructure.Module;
using XamarinFormsMVP.Interactor;
using XamarinFormsMVP.Interactor.Interface;
using XamarinFormsMVP.Presenter;
using XamarinFormsMVP.View.Interface;

namespace XamarinFormsMVP.Module
{
    public class UserDetailsModule : ModuleBase
    {
        public UserDetailsModule(IUserDetailsView View)
        {
            Container.Register(() => View);
            Container.Register<IUserDetailsInteractor, UserDetailsInteractor>();
            Container.Register<UserDetailsPresenter>();
            Container.Verify();
        }
    }
}

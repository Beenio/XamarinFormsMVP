using XamarinFormsMVP.Infrastructure.Module;
using XamarinFormsMVP.Interactor;
using XamarinFormsMVP.Interactor.Interface;
using XamarinFormsMVP.Presenter;
using XamarinFormsMVP.View.Interface;

namespace XamarinFormsMVP.Module
{
    public class UserListModule : ModuleBase
    {
        public UserListModule(IUserListView View)
        {
            Container.Register(() => View);
            Container.Register<IUserListInteractor, UserListInteractor>();
            Container.Register<UserListPresenter>();
            Container.Verify();
        }
    }
}

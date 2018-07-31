using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsMVP.Infrastructure.Presenter;
using XamarinFormsMVP.Interactor.Interface;
using XamarinFormsMVP.Model.EntityViewModel;
using XamarinFormsMVP.View.Interface;

namespace XamarinFormsMVP.Presenter
{
    public class UserListPresenter : PresenterBase<IUserListView, IUserListInteractor>
    {
        public UserListPresenter(IUserListView view, IUserListInteractor interactor) : base(view, interactor)
        {
        }

        public async void AddUser()
        {
            await Task.Run(() => 
            {
                try
                {
                    View.GoToUserDetails();
                }
                catch (Exception e)
                {
                    View.HandleFailure(e.Message);
                }
            });
        }

        public async void GetUsers(Action<List<UserViewModel>> Success)
        {
            await Task.Run(() =>
            {
                try
                {
                    var Users = Interactor.GetUsers();
                    Success(Users);
                }
                catch (Exception e)
                {
                    View.HandleFailure(e.Message);
                }              
            });
        }

        public async void ItemTapped(UserViewModel User)
        {
            await Task.Run(() =>
            {
                try
                {
                    View.GoToUserDetails(User);
                }
                catch (Exception e)
                {
                    View.HandleFailure(e.Message);
                }
            });
        }
    }
}

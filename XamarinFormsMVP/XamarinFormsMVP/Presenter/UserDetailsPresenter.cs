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
    public class UserDetailsPresenter : PresenterBase<IUserDetailsView, IUserDetailsInteractor>
    {
        public UserDetailsPresenter(IUserDetailsView view, IUserDetailsInteractor interactor) : base(view, interactor)
        {
        }

        public async void SaveUser(UserViewModel User)
        {
            await Task.Run(() =>
            {
                try
                {
                    Interactor.SaveUser(User);
                    View.GoBack();
                }
                catch (Exception e)
                {
                    View.HandleFailure(e.Message);
                }
            });
        }
    }
}

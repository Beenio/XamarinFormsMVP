using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsMVP.Infrastructure.View;
using XamarinFormsMVP.Model.EntityViewModel;
using XamarinFormsMVP.Presenter;

namespace XamarinFormsMVP.View.Interface
{
    public interface IUserListView : IViewBase
    {
        void GoToUserDetails(UserViewModel Model = null);
    }
}

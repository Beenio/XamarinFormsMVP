using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsMVP.Infrastructure.Interactor;
using XamarinFormsMVP.Model.EntityViewModel;

namespace XamarinFormsMVP.Interactor.Interface
{
    public interface IUserDetailsInteractor : IInteractorBase
    {
        void SaveUser(UserViewModel User);
    }
}

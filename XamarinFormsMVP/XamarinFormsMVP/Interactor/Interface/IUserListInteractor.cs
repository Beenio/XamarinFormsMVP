using System.Collections.Generic;
using XamarinFormsMVP.Infrastructure.Interactor;
using XamarinFormsMVP.Model.EntityViewModel;

namespace XamarinFormsMVP.Interactor.Interface
{
    public interface IUserListInteractor : IInteractorBase
    {
        List<UserViewModel> GetUsers();
    }
}

using Mapster;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsMVP.Infrastructure.Interactor;
using XamarinFormsMVP.Interactor.Interface;
using XamarinFormsMVP.Model.Entity;
using XamarinFormsMVP.Model.EntityViewModel;
using XamarinFormsMVP.Model.Repository;

namespace XamarinFormsMVP.Interactor
{
    public class UserListInteractor : InteractorBase, IUserListInteractor
    {
        public List<UserViewModel> GetUsers()
        {
            var Repository = new UserRepository();
            var Users = Repository.Get<UserEntity>().Adapt<List<UserViewModel>>();
            return Users;
        }
    }
}

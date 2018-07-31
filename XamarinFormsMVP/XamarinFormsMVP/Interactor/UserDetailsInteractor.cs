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
    public class UserDetailsInteractor : InteractorBase, IUserDetailsInteractor
    {
        public void SaveUser(UserViewModel User)
        {
            if (User == null)
                return;

            var Repository = new UserRepository();
            if (string.IsNullOrEmpty(User.Id))
            {
                Repository.Insert(new UserEntity() { Email = User.Email, Name = User.Name, Age = User.Age, Telephone = User.Telephone });
            }
            else
            {
                var Entity = Repository.Get(w => w.Id.Equals(User.Id));
                if(Entity != null)
                {
                    Repository.Write(() =>
                    {
                        Entity.Name = User.Name;
                        Entity.Email = User.Email;
                        Entity.Age = User.Age;
                        Entity.Telephone = User.Telephone;
                    });
                }
            }
        }
    }
}

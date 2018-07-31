using Mapster;
using XamarinFormsMVP.Model.Entity;
using XamarinFormsMVP.Model.EntityViewModel;

namespace XamarinFormsMVP.Model.Mapper
{
    public class UserMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserEntity, UserViewModel>();
            config.NewConfig<UserViewModel, UserEntity>();
        }
    }
}

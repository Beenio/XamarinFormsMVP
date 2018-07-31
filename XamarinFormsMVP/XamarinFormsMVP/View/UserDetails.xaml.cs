using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsMVP.Infrastructure.View;
using XamarinFormsMVP.Model.EntityViewModel;
using XamarinFormsMVP.Module;
using XamarinFormsMVP.Presenter;
using XamarinFormsMVP.View.Interface;

namespace XamarinFormsMVP.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetails : ContentPageBase<UserDetailsPresenter>, IUserDetailsView
	{
        private UserViewModel User;

        protected override IViewBase View => this;

        protected override Container Container { get; }

        public UserDetails(UserViewModel User)
		{
			InitializeComponent ();
            Container = new UserDetailsModule(this).Container;
            CreatePresenter();

            this.User = User;
            LoadData();
            LoadActions();
        }

        public void LoadData()
        {
            if(User != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    NameEntry.Text = User.Name;
                    AgeEntry.Text = User.Age;
                    TelephoneEntry.Text = User.Telephone;
                    EmailEntry.Text = User.Email;
                });
            }
        }

        public void LoadActions()
        {
            SaveButton.Clicked += SaveButton_Clicked;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Presenter.SaveUser(new UserViewModel()
            {
                Age = AgeEntry.Text,
                Email = EmailEntry.Text,
                Name = NameEntry.Text,
                Telephone = TelephoneEntry.Text
            });
        }

        public void GoBack()
        {
            Device.BeginInvokeOnMainThread(async () => 
            {
                await Navigation.PopAsync();
            });
        }
    }
}
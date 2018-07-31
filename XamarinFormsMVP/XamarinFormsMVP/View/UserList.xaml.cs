using SimpleInjector;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsMVP.Extensions;
using XamarinFormsMVP.Infrastructure.View;
using XamarinFormsMVP.Model.EntityViewModel;
using XamarinFormsMVP.Module;
using XamarinFormsMVP.Presenter;
using XamarinFormsMVP.View.Interface;

namespace XamarinFormsMVP.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserList : ContentPageBase<UserListPresenter>, IUserListView
    {
        protected override IViewBase View => this;

        protected override Container Container { get; }

        public ICommand OnAddCommand { get; set; }

        public ObservableCollection<UserViewModel> ItemsList { get; set; } = new ObservableCollection<UserViewModel>();
       

        public UserList ()
		{
            InitializeComponent();
            Container = new UserListModule(this).Container;
            CreatePresenter();
            SetupPage();
            SetupActions();
        }

        public void SetupPage()
        {
            ToolbarItems.Add(new ToolbarItem("ADD", string.Empty, AddUser));
            ListView.ItemsSource = ItemsList;
        }

        public void SetupActions()
        {
            OnAddCommand = new Command(AddUser);
        }

        public void AddUser()
        {
            Presenter.AddUser();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Presenter.GetUsers(LoadUsers);
        }

        public void LoadUsers(List<UserViewModel> Users)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ItemsList.Clear();
                ItemsList.AddRange(Users);
                UpdateVisible();
            });
        }

        private void UpdateVisible()
        {
            if (ItemsList.Count > 0)
            {
                LabelEmpty.IsVisible = false;
                ListView.IsVisible = true;
            }
            else
            {
                LabelEmpty.IsVisible = true;
                ListView.IsVisible = false;
            }
        }

        public void GoToUserDetails(UserViewModel Model = null)
        {
            Device.BeginInvokeOnMainThread(async () => 
            {
                await Navigation.PushAsync(new UserDetails(Model));
            });
        }
    }
}
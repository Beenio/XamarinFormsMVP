using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsMVP.Infrastructure.Presenter;

namespace XamarinFormsMVP.View.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuList : ContentPage
    {
        public ListView ListView;

        public MenuList()
        {
            InitializeComponent();

            BindingContext = new MasterNavigationMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterNavigationMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterNavigationMenuItem> MenuItems { get; set; }
            
            public MasterNavigationMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterNavigationMenuItem>(new[]
                {
                    new MasterNavigationMenuItem { Id = 0, Title = "Home", TargetType = typeof(MainPage) },
                    new MasterNavigationMenuItem { Id = 1, Title = "User List", TargetType = typeof(UserList) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
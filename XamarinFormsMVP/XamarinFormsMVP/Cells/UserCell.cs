using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsMVP.Cells
{
    public class UserCell : ViewCell
    {
        public UserCell()
        {
            var Grid = new Grid() { Padding = new Thickness(4, 0, 4, 0) };
            var NameLabel = new Label() { FontAttributes = FontAttributes.Bold, FontSize = 12, VerticalOptions = LayoutOptions.End };
            var EmailLabel = new Label() { FontSize = 10, TextColor = Color.LightGray, VerticalOptions = LayoutOptions.Start };

            NameLabel.SetBinding(Label.TextProperty, "Name");
            EmailLabel.SetBinding(Label.TextProperty, "Email");

            Grid.Children.Add(NameLabel, 0, 0);
            Grid.Children.Add(EmailLabel, 0, 1);

            View = Grid;
        }
    }
}

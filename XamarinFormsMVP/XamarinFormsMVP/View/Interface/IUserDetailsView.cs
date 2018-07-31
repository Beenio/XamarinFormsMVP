using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsMVP.Infrastructure.View;

namespace XamarinFormsMVP.View.Interface
{
    public interface IUserDetailsView : IViewBase
    {
        void GoBack();
    }
}

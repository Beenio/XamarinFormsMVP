using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsMVP.Infrastructure.View
{
    public interface IViewBase
    {
        void HandleFailure(string Message);
    }
}

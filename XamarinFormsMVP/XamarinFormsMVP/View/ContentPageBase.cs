using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using XamarinFormsMVP.Infrastructure.Presenter;
using XamarinFormsMVP.Infrastructure.View;

namespace XamarinFormsMVP.View
{
    public abstract class ContentPageBase<T> : ContentPage, IViewBase where T : PresenterBase
    {
        protected T Presenter { get; set; }
        protected abstract IViewBase View { get; }
        protected abstract Container Container { get; }

        public ContentPageBase()
        {
        }

        protected void CreatePresenter()
        {
            Presenter = Container.GetInstance<T>();
        }

        public void HandleFailure(string Message)
        {
            Debug.WriteLine(Message);
        }
    }
}

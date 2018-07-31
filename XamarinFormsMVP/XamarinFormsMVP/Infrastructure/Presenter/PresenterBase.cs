using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsMVP.Infrastructure.Interactor;
using XamarinFormsMVP.Infrastructure.View;

namespace XamarinFormsMVP.Infrastructure.Presenter
{
    public abstract partial class PresenterBase
    {
        protected IViewBase View { get; set; }
        protected IInteractorBase Interactor { get; set; }
        public PresenterBase(IViewBase view, IInteractorBase interactor)
        {
            View = view;
            Interactor = interactor;
        }
    }

    public abstract class PresenterBase<V, I> : PresenterBase where V : IViewBase where I : IInteractorBase
    {
        public PresenterBase(V view, I interactor) : base(view, interactor)
        {
        }
        protected new V View
        {
            get
            {
                return (V)base.View;
            }
            set
            {
                base.View = value;
            }
        }
        protected new I Interactor
        {
            get
            {
                return (I)base.Interactor;
            }
            set
            {
                base.Interactor = value;
            }
        }
    }
}

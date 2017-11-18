using System;
using Xamarin.Forms;
namespace Sample.Layouts
{
    public class NativeLayout:View
    {
        public static BindableProperty SampleProperty =
            BindableProperty.Create(
                nameof(Sample),
                typeof(int),
                typeof(NativeLayout),
                default(int),
                defaultBindingMode: BindingMode.OneWay
            );

        public int Sample
        {
            get { return (int)GetValue(SampleProperty); }
            set { SetValue(SampleProperty, value); }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            return base.OnMeasure(widthConstraint, heightConstraint);
        }
    }
}

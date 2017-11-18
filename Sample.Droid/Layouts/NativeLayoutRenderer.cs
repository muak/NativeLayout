using System.Linq;
using System.Reflection;
using Android.Content;
using Android.Views;
using Android.Widget;
using Sample.Droid.Layouts;
using Sample.Layouts;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(NativeLayout), typeof(NativeLayoutRenderer))]
namespace Sample.Droid.Layouts {
    public class NativeLayoutRenderer : ViewRenderer<NativeLayout, ViewGroup> {
        RelativeLayout _parentView;
        LinearLayout _container;
        TextView _label1;
        TextView _label2;
        TextView _label3;

        public NativeLayoutRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<NativeLayout> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _label1 = new TextView(Context) { Gravity = GravityFlags.CenterVertical };
                _label2 = new TextView(Context) { Gravity = GravityFlags.CenterVertical };
                _label3 = new TextView(Context) { Gravity = GravityFlags.CenterVertical };

                _label1.SetBackgroundColor(Android.Graphics.Color.Argb(100, 255, 0, 0));
                _label2.SetBackgroundColor(Android.Graphics.Color.Argb(100, 0, 200, 0));
                _label3.SetBackgroundColor(Android.Graphics.Color.Argb(100, 0, 0, 255));

                _label1.Text = "One";
                _label2.Text = "Two";
                _label3.Text = "Three";


                var id = Element.Sample;

                var m = this.GetType().GetRuntimeMethods().Where(x => x.Name == $"Sample{id}").FirstOrDefault();
                m?.Invoke(this, null);

                this.SetBackgroundColor(Android.Graphics.Color.Argb(160, 230, 230, 230));

                SetNativeControl((ViewGroup)_parentView ?? _container);
            }
        }

        void Sample1()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);

            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1, //余白を優先して割り当てる
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label3, param2);
        }

        void Sample2()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            _label3.Text = "LongTextTextTextTextTextTextTextTextTextTextTextTextTextTextTextTextEnd";
            _label3.SetMaxLines(1);

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);

            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1, //余白を優先して割り当てる
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label3, param2);
        }

        void Sample3()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);
            _container.AddView(_label3, param);
        }

        void Sample4()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向
            _container.SetGravity(GravityFlags.End); //右寄せ

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);
            _container.AddView(_label3, param);
        }

        void Sample5()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);
            _container.AddView(_label3, param);

            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1
            };

            //分けたい箇所にWeight1のダミーを挿入
            _container.AddView(new LinearLayout(Context), 1, param2);
        }


        void Sample6()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);
            _container.AddView(_label3, param);
        }

        void Sample7()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical, //垂直方向位置
                RightMargin = (int)Context.ToPixels(6), //要素間マージン
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);

            //最後の要素にはマージンは不要
            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1,
                Gravity = GravityFlags.CenterVertical
            };
            _container.AddView(_label3, param2);
        }

        void Sample8()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向


            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) { //高さは親に合わせる
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical, //垂直方向位置
                RightMargin = (int)Context.ToPixels(6), //要素間マージン
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);

            //最後の要素にはマージンは不要
            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) { //高さは親に合わせる
                Width = 0,
                Weight = 1,
                Gravity = GravityFlags.CenterVertical
            };
            _container.AddView(_label3, param2);
        }

        void Sample9()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            //レイアウトの余白設定
            var padding = (int)Context.ToPixels(6); //ToPixelsはFormsの拡張メソッドでdpをpxに変換する
            _container.SetPadding(padding, padding, padding, padding);

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical, //垂直方向位置
                RightMargin = (int)Context.ToPixels(6), //要素間マージン
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);

            //最後の要素にはマージンは不要
            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) {
                Width = 0,
                Weight = 1,
                Gravity = GravityFlags.CenterVertical
            };
            _container.AddView(_label3, param2);
        }

        void Sample10()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            //レイアウトの余白設定
            var padding = (int)Context.ToPixels(6);
            _container.SetPadding(padding, padding, padding, padding);

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) {
                Gravity = GravityFlags.CenterVertical, //垂直方向位置
                RightMargin = (int)Context.ToPixels(6), //要素間マージン
            };
            _container.AddView(_label1, param);

            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) {
                Width = (int)Context.ToPixels(120), //幅固定値指定
                Gravity = GravityFlags.CenterVertical, //垂直方向位置
                RightMargin = (int)Context.ToPixels(6), //要素間マージン
            };
            _container.AddView(_label2, param2);

            //最後の要素にはマージンは不要
            var param3 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) {
                Width = 0,
                Weight = 1,
                Gravity = GravityFlags.CenterVertical
            };
            _container.AddView(_label3, param3);
        }

        void Sample11()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Height = (int)Context.ToPixels(50),//個別の高さ
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label1, param);

            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Height = (int)Context.ToPixels(80),//個別の高さ
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label2, param2);

            var param3 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical //垂直方向位置
            };
            _container.AddView(_label3, param3);
        }

        void Sample12()
        {
            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.Top //垂直方向位置 上揃え
            };
            _container.AddView(_label1, param);

            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.Bottom //垂直方向位置 下揃え
            };
            _container.AddView(_label2, param2);

            var param3 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical //垂直方向位置 中央揃え
            };
            _container.AddView(_label3, param3);
        }

        void Sample13()
        {
            _parentView = new RelativeLayout(Context);

            _container = new LinearLayout(Context);
            _container.Orientation = Orientation.Horizontal; //並べる方向

            var param = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) {
                Width = 0,
                Weight = 1,//余白は平等に
                Gravity = GravityFlags.CenterVertical, //垂直方向位置
                RightMargin = (int)Context.ToPixels(6), //要素間マージン
            };
            _container.AddView(_label1, param);
            _container.AddView(_label2, param);

            //最後の要素にはマージンは不要
            var param2 = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent) {
                Width = 0,
                Weight = 1,
                Gravity = GravityFlags.CenterVertical
            };
            _container.AddView(_label3, param2);

            using (var p = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent))
            {
                //親Viewにぴったりに合わせて挿入
                _parentView.AddView(_container, p);
            }

            var margin = (int)Context.ToPixels(6);

            var label4 = new TextView(Context) { Text = "Four" };
            label4.SetBackgroundColor(Android.Graphics.Color.Argb(125, 0, 0, 0));
            label4.SetTextColor(Android.Graphics.Color.White);


            using (var p = new RelativeLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent))
            {
                p.AddRule(LayoutRules.AlignParentTop);  //親の上の合わせる
                p.AddRule(LayoutRules.AlignParentLeft); //親の左に合わせる
                p.TopMargin = margin;
                p.LeftMargin = margin;
                _parentView.AddView(label4, p);
            }

            var label5 = new TextView(Context) { Text = "Five" };
            label5.SetBackgroundColor(Android.Graphics.Color.Argb(125, 0, 0, 0));
            label5.SetTextColor(Android.Graphics.Color.White);

            using (var p = new RelativeLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent))
            {
                p.AddRule(LayoutRules.AlignParentTop);   //親の上に合わせる
                p.AddRule(LayoutRules.AlignParentRight); //親の右に合わせる
                p.TopMargin = margin;
                p.RightMargin = margin;
                _parentView.AddView(label5, p);
            }

            var label6 = new TextView(Context) { Text = "Six" };
            label6.SetBackgroundColor(Android.Graphics.Color.Argb(125, 0, 0, 0));
            label6.SetTextColor(Android.Graphics.Color.White);

            using (var p = new RelativeLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent))
            {
                p.AddRule(LayoutRules.AlignParentBottom); //親の下に合わせる
                p.AddRule(LayoutRules.AlignParentRight);  //親の右に合わせる
                p.BottomMargin = margin;
                p.RightMargin = margin;
                _parentView.AddView(label6, p);
            }

            var label7 = new TextView(Context) { Text = "Seven" };
            label7.SetBackgroundColor(Android.Graphics.Color.Argb(125, 0, 0, 0));
            label7.SetTextColor(Android.Graphics.Color.White);

            using (var p = new RelativeLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent))
            {
                p.AddRule(LayoutRules.AlignParentLeft);     //親の左に合わせる
                p.AddRule(LayoutRules.AlignParentBottom);   //親の下に合わせる
                p.LeftMargin = margin;
                p.BottomMargin = margin;
                _parentView.AddView(label7, p);
            }

            var label8 = new TextView(Context) { Text = "Eight" };
            label8.SetBackgroundColor(Android.Graphics.Color.Argb(125, 0, 0, 0));
            label8.SetTextColor(Android.Graphics.Color.White);

            using (var p = new RelativeLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent))
            {
                p.AddRule(LayoutRules.CenterInParent);  //親の水平垂直ど真ん中に合わせる
                _parentView.AddView(label8, p);
            }
        }

        void Sample14()
        {
            //xmlリソースからレイアウトを呼び出す
            var view = LayoutInflater.FromContext(Context).Inflate(Resource.Layout.NativeLayout, null);
            _parentView = view as RelativeLayout;
        }
    }
}

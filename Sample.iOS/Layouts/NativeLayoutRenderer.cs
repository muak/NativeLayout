using System;
using System.Linq;
using System.Reflection;
using CoreAnimation;
using Sample.iOS.Layouts;
using Sample.Layouts;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NativeLayout), typeof(NativeLayoutRenderer))]
namespace Sample.iOS.Layouts {
    public class NativeLayoutRenderer : ViewRenderer<NativeLayout, UIView> {
        UIView _parentView;
        UIStackView _container;
        UILabel _label1;
        UILabel _label2;
        UILabel _label3;

        protected override void OnElementChanged(ElementChangedEventArgs<NativeLayout> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {

                _label1 = new UILabel { Text = "One", BackgroundColor = UIColor.FromRGBA(255, 0, 0, 100) };
                _label2 = new UILabel { Text = "Two", BackgroundColor = UIColor.FromRGBA(0, 200, 0, 100) };
                _label3 = new UILabel { Text = "Three", BackgroundColor = UIColor.FromRGBA(0, 0, 255, 100) };

                var id = Element.Sample;

                var m = this.GetType().GetRuntimeMethods().Where(x => x.Name == $"Sample{id}").FirstOrDefault();
                m?.Invoke(this, null);

                this.BackgroundColor = UIColor.FromRGBA(230, 230, 230, 160);

                SetNativeControl(_parentView ?? _container);
            }
        }

        void Sample1()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.Fill, //余白分配設定
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);

            //余った領域を広げる優先度の設定（低いものが優先して拡大する）
            _label1.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label2.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label3.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal); //最優先
        }

        void Sample2()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.Fill, //余白分配設定
            };

            _label3.Text = "LongTextTextTextTextTextTextTextTextTextTextTextTextTextTextTextTextEnd";

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);

            //余った領域を広げる優先度の設定（低いものが優先して拡大する）
            _label1.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label2.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label3.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal); //最優先

            //縮まりやすさの設定（低いものが優先して縮まる）
            _label1.SetContentCompressionResistancePriority(999f, UILayoutConstraintAxis.Horizontal);
            _label2.SetContentCompressionResistancePriority(999f, UILayoutConstraintAxis.Horizontal);
            _label3.SetContentCompressionResistancePriority(1f, UILayoutConstraintAxis.Horizontal); //最優先
        }

        void Sample3()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.Fill, //余白分配設定
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);

            var dummy = new UIView();
            _container.AddArrangedSubview(dummy);

            //余った領域を広げる優先度の設定（低いものが優先して拡大する）
            _label1.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label2.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label3.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            dummy.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal); //最優先
        }

        void Sample4()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.Fill, //余白分配設定
            };

            //先頭にダミーを追加
            var dummy = new UIView();
            _container.AddArrangedSubview(dummy);

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);


            //余った領域を広げる優先度の設定（低いものが優先して拡大する）
            dummy.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal); //最優先
            _label1.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label2.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label3.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
        }

        void Sample5()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.Fill, //余白分配設定
            };

            _container.AddArrangedSubview(_label1);

            //分けたいところにダミーを追加
            var dummy = new UIView();
            _container.AddArrangedSubview(dummy);

            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);


            //余った領域を広げる優先度の設定（低いものが優先して拡大する）
            _label1.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            dummy.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal); //最優先
            _label2.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label3.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
        }

        void Sample6()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.FillEqually, //余白分配設定 均等
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);
        }

        void Sample7()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.FillEqually, //余白分配設定 均等
                Spacing = 6 //要素間のマージン
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);
        }

        void Sample8()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Fill, //垂直位置属性
                Distribution = UIStackViewDistribution.FillEqually, //余白分配設定 均等
                Spacing = 6 //要素間のマージン
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);
        }

        void Sample9()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Fill, //垂直位置属性
                Distribution = UIStackViewDistribution.FillEqually, //余白分配設定 均等
                Spacing = 6 //要素間のマージン
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);

            //レイアウトの余白設定
            _container.LayoutMargins = new UIEdgeInsets(6, 6, 6, 6);
            _container.LayoutMarginsRelativeArrangement = true;
        }

        void Sample10()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Fill, //垂直位置属性
                Distribution = UIStackViewDistribution.Fill, //余白分配設定
                Spacing = 6 //要素間のマージン
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);

            //レイアウトの余白設定
            _container.LayoutMargins = new UIEdgeInsets(6, 6, 6, 6);
            _container.LayoutMarginsRelativeArrangement = true;

            _label1.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label2.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            _label3.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal);

            //固定の幅を指定
            _label2.WidthAnchor.ConstraintEqualTo(120).Active = true;
        }

        void Sample11()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.FillEqually, //余白分配設定 均等
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);

            //個別の高さを指定
            _label1.HeightAnchor.ConstraintEqualTo(50).Active = true;
            _label2.HeightAnchor.ConstraintEqualTo(80).Active = true;
        }

        void Sample12()
        {
            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Fill, //垂直位置属性
                Distribution = UIStackViewDistribution.FillEqually, //余白分配設定 均等
            };

            //ラッパーのUIStackViewを作成する（それぞれ垂直属性を変える）
            var wrapper1 = new UIStackView { Alignment = UIStackViewAlignment.Top };
            var wrapper2 = new UIStackView { Alignment = UIStackViewAlignment.Bottom };
            var wrapper3 = new UIStackView { Alignment = UIStackViewAlignment.Center };

            //ラッパーに要素を詰める
            wrapper1.AddArrangedSubview(_label1);
            wrapper2.AddArrangedSubview(_label2);
            wrapper3.AddArrangedSubview(_label3);

            _container.AddArrangedSubview(wrapper1);
            _container.AddArrangedSubview(wrapper2);
            _container.AddArrangedSubview(wrapper3);
        }

        void Sample13()
        {
            _parentView = new UIView();

            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Fill, //垂直位置属性
                Distribution = UIStackViewDistribution.FillEqually, //余白分配設定 均等
                Spacing = 6 //要素間のマージン
            };

            _container.AddArrangedSubview(_label1);
            _container.AddArrangedSubview(_label2);
            _container.AddArrangedSubview(_label3);

            //親Viewにサイズぴったりにする
            _parentView.AddSubview(_container);
            _container.TranslatesAutoresizingMaskIntoConstraints = false;
            _container.TopAnchor.ConstraintEqualTo(_parentView.TopAnchor, 0).Active = true;
            _container.LeftAnchor.ConstraintEqualTo(_parentView.LeftAnchor, 0).Active = true;
            _container.BottomAnchor.ConstraintEqualTo(_parentView.BottomAnchor, 0).Active = true;
            _container.RightAnchor.ConstraintEqualTo(_parentView.RightAnchor, 0).Active = true;


            var label4 = new UILabel { Text = "Four", BackgroundColor = UIColor.FromRGBA(0, 0, 0, 125), TextColor = UIColor.White };

            _parentView.AddSubview(label4);

            //左上から6,6の位置に置く
            label4.TranslatesAutoresizingMaskIntoConstraints = false;
            label4.TopAnchor.ConstraintEqualTo(_parentView.TopAnchor, 6).Active = true;
            label4.LeftAnchor.ConstraintEqualTo(_parentView.LeftAnchor, 6).Active = true;

            var label5 = new UILabel { Text = "Five", BackgroundColor = UIColor.FromRGBA(0, 0, 0, 125), TextColor = UIColor.White };

            _parentView.AddSubview(label5);

            //右上から6,6の位置に置く（RightとBottomから内側へのマージンはマイナス指定）
            label5.TranslatesAutoresizingMaskIntoConstraints = false;
            label5.TopAnchor.ConstraintEqualTo(_parentView.TopAnchor, 6).Active = true;
            label5.RightAnchor.ConstraintEqualTo(_parentView.RightAnchor, -6).Active = true;

            var label6 = new UILabel { Text = "Six", BackgroundColor = UIColor.FromRGBA(0, 0, 0, 125), TextColor = UIColor.White };

            _parentView.AddSubview(label6);

            //右下から6,6の位置に置く
            label6.TranslatesAutoresizingMaskIntoConstraints = false;
            label6.RightAnchor.ConstraintEqualTo(_parentView.RightAnchor, -6).Active = true;
            label6.BottomAnchor.ConstraintEqualTo(_parentView.BottomAnchor, -6).Active = true;

            var label7 = new UILabel { Text = "Seven", BackgroundColor = UIColor.FromRGBA(0, 0, 0, 125), TextColor = UIColor.White };

            _parentView.AddSubview(label7);

            //左下から6,6,の位置に置く
            label7.TranslatesAutoresizingMaskIntoConstraints = false;
            label7.LeftAnchor.ConstraintEqualTo(_parentView.LeftAnchor, 6).Active = true;
            label7.BottomAnchor.ConstraintEqualTo(_parentView.BottomAnchor, -6).Active = true;

            var label8 = new UILabel { Text = "Eight", BackgroundColor = UIColor.FromRGBA(0, 0, 0, 125), TextColor = UIColor.White };

            _parentView.AddSubview(label8);

            //ど真ん中に置く
            label8.TranslatesAutoresizingMaskIntoConstraints = false;
            label8.CenterXAnchor.ConstraintEqualTo(_parentView.CenterXAnchor).Active = true;
            label8.CenterYAnchor.ConstraintEqualTo(_parentView.CenterYAnchor).Active = true;
        }

        void Sample14()
        {
            _parentView = new UIView();

            _container = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal, //並べる方向
                Alignment = UIStackViewAlignment.Center, //垂直位置属性
                Distribution = UIStackViewDistribution.Fill, //余白分配設定
                Spacing = 6 //要素間のマージン
            };

            //レイアウトの余白設定
            _container.LayoutMargins = new UIEdgeInsets(6, 6, 6, 6);
            _container.LayoutMarginsRelativeArrangement = true;

            var image = new UIImageView(UIImage.FromBundle("icon.png"));
            image.ContentMode = UIViewContentMode.ScaleAspectFit;

            _container.AddArrangedSubview(image);

            image.WidthAnchor.ConstraintEqualTo(80).Active = true;
            image.HeightAnchor.ConstraintEqualTo(46).Active = true;

            var vStack = new UIStackView {
                Axis = UILayoutConstraintAxis.Vertical,
                Alignment = UIStackViewAlignment.Fill,
                Distribution = UIStackViewDistribution.Fill,
                Spacing = 6
            };

            var hStack = new UIStackView {
                Axis = UILayoutConstraintAxis.Horizontal,
                Alignment = UIStackViewAlignment.Center,
                Distribution = UIStackViewDistribution.Fill,
                Spacing = 6
            };

            var label1 = new UILabel { Text = "Xamarin Native Layout Sample TextTextTextTextText" };
            var label2 = new UILabel { Text = "******" };
            label1.Font = label1.Font.WithSize(16);
            label2.Font = label2.Font.WithSize(16);

            hStack.AddArrangedSubview(label1);
            hStack.AddArrangedSubview(label2);

            //余った領域を広げる優先度の設定（低いものが優先して拡大する）
            label1.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal);
            label2.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);

            //縮まりやすさの設定（低いものが優先して縮まる）
            label1.SetContentCompressionResistancePriority(1f, UILayoutConstraintAxis.Horizontal);
            label2.SetContentCompressionResistancePriority(999f, UILayoutConstraintAxis.Horizontal);

            vStack.AddArrangedSubview(hStack);

            var label3 = new UILabel { Text = "複雑なレイアウトも入れ子にすることで実現可能です。Androidの方が簡単なのでiOS側からレイアウトを組んで行く方が良いかもしれません。" };
            label3.LineBreakMode = UILineBreakMode.CharacterWrap;
            label3.Lines = 2;
            label3.Font = label3.Font.WithSize(12);

            vStack.AddArrangedSubview(label3);

            hStack.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Vertical);
            label3.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Vertical);

            _container.AddArrangedSubview(vStack);

            image.SetContentHuggingPriority(999f, UILayoutConstraintAxis.Horizontal);
            vStack.SetContentHuggingPriority(1f, UILayoutConstraintAxis.Horizontal);

            image.SetContentCompressionResistancePriority(999f, UILayoutConstraintAxis.Horizontal);
            vStack.SetContentCompressionResistancePriority(1f, UILayoutConstraintAxis.Horizontal);

            _parentView.AddSubview(_container);
            _container.TranslatesAutoresizingMaskIntoConstraints = false;
            _container.TopAnchor.ConstraintEqualTo(_parentView.TopAnchor, 0).Active = true;
            _container.LeftAnchor.ConstraintEqualTo(_parentView.LeftAnchor, 0).Active = true;
            _container.BottomAnchor.ConstraintEqualTo(_parentView.BottomAnchor, 0).Active = true;
            _container.RightAnchor.ConstraintEqualTo(_parentView.RightAnchor, 0).Active = true;


            var label4 = new UILabel { Text = "Sample", BackgroundColor = UIColor.FromRGBA(0, 0, 0, 125), TextColor = UIColor.White };
            label4.Font = label4.Font.WithSize(12);

            _parentView.AddSubview(label4);

            label4.TranslatesAutoresizingMaskIntoConstraints = false;
            label4.TopAnchor.ConstraintEqualTo(_parentView.TopAnchor, 3).Active = true;
            label4.LeftAnchor.ConstraintEqualTo(_parentView.LeftAnchor, 3).Active = true;
        }
    }

    // Apply BackgroundColor https://stackoverflow.com/questions/34868344/how-to-change-the-background-color-of-uistackview
    public class UIStackViewEx : UIStackView {
        Lazy<CAShapeLayer> _backgroundLayer;

        public UIStackViewEx()
        {
            _backgroundLayer = new Lazy<CAShapeLayer>(() => {
                var layer = new CAShapeLayer();
                this.Layer.InsertSublayer(layer, 0);
                return layer;
            });
        }

        UIColor _backgroundColor;
        public override UIColor BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                SetNeedsLayout();
            }
        }

        public override void LayoutSubviews()
        {

            base.LayoutSubviews();
            _backgroundLayer.Value.Path = UIBezierPath.FromRect(this.Bounds).CGPath;
            _backgroundLayer.Value.FillColor = BackgroundColor?.CGColor;

        }
    }
}

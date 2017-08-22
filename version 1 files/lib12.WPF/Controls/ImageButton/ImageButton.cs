using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace lib12.WPF.Controls.ImageButton
{
    public class ImageButton : Button
    {
        #region Props
        public SolidColorBrush ShadowBrush
        {
            get { return (SolidColorBrush)GetValue(ShadowBrushProperty); }
            set { SetValue(ShadowBrushProperty, value); }
        }
        public static readonly DependencyProperty ShadowBrushProperty =
            DependencyProperty.Register("ShadowBrush", typeof(SolidColorBrush), typeof(ImageButton), new PropertyMetadata(Brushes.Black, ShadowBrush_Changed));

        private static void ShadowBrush_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var imageButton = (ImageButton)sender;
            var color = ((SolidColorBrush)e.NewValue).Color;
            imageButton.DropShadowEffect = CreateDropShadowEffect(color);
        }

        internal DropShadowEffect DropShadowEffect
        {
            get { return (DropShadowEffect)GetValue(DropShadowEffectProperty); }
            set { SetValue(DropShadowEffectProperty, value); }
        }
        internal static readonly DependencyProperty DropShadowEffectProperty =
            DependencyProperty.Register("DropShadowEffect", typeof(DropShadowEffect), typeof(ImageButton), new PropertyMetadata(CreateDropShadowEffect(Colors.Black)));
        #endregion

        #region sctor
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }
        #endregion

        #region Logic
        private static DropShadowEffect CreateDropShadowEffect(Color color)
        {
            return new DropShadowEffect
            {
                Color = color,
                ShadowDepth = 0,
                BlurRadius = 2.5
            };
        }
        #endregion
    }
}

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using lib12.Collections;

namespace lib12.WPF.Controls.FluidTextBox
{
    [TemplatePart(Name = "PART_TextBlock", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
    public class FluidTextBox : TextBox
    {
        #region Const
        private static readonly string digitSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        #endregion

        #region Fields
        private TextBox textBox;
        #endregion

        #region Dependency props
        public GridLength LabelWidth
        {
            get
            {
                return (GridLength)GetValue(LabelWidthProperty);
            }
            set
            {
                SetValue(LabelWidthProperty, value);
            }
        }
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(FluidTextBox), new PropertyMetadata(new GridLength(100)));

        public string Label
        {
            get
            {
                return (string)GetValue(LabelProperty);
            }
            set
            {
                SetValue(LabelProperty, value);
            }
        }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(FluidTextBox));

        public string WatermarkText
        {
            get
            {
                return (string)GetValue(WatermarkTextProperty);
            }
            set
            {
                SetValue(WatermarkTextProperty, value);
            }
        }
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(FluidTextBox));

        public bool IsWatermarkVisible
        {
            get
            {
                return (bool)GetValue(IsWatermarkVisibleProperty);
            }
            private set
            {
                SetValue(IsWatermarkVisibleProperty, value);
            }
        }
        public static readonly DependencyProperty IsWatermarkVisibleProperty =
            DependencyProperty.Register("IsWatermarkVisible", typeof(bool), typeof(FluidTextBox));

        public EntryMode EntryMode
        {
            get
            {
                return (EntryMode)GetValue(EntryModeProperty);
            }
            set
            {
                SetValue(EntryModeProperty, value);
            }
        }
        public static readonly DependencyProperty EntryModeProperty =
            DependencyProperty.Register("EntryMode", typeof(EntryMode), typeof(FluidTextBox), new PropertyMetadata(EntryMode.All, EntryMode_Changed));
        #endregion

        #region sctor
        static FluidTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FluidTextBox), new FrameworkPropertyMetadata(typeof(FluidTextBox)));
        }
        #endregion

        #region Start
        public FluidTextBox()
        {
            GotFocus += this_GotFocus;
            LostFocus += this_LostFocus;
            Loaded += this_Loaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            textBox = (TextBox)GetTemplateChild("PART_TextBox");
            textBox.TextChanged += textBox_TextChanged;
            if (EntryMode != EntryMode.All)
            {
                textBox.PreviewTextInput += textBox_PreviewTextInput;
                textBox.PreviewKeyDown += textBox_PreviewKeyDown;
            }

            UpdateWatermarkVisibility();
        }
        #endregion

        #region EntryMode
        private static void EntryMode_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var fluidTextBox = (FluidTextBox)sender;
            if (fluidTextBox.textBox == null)//OnApplyTemplate not called
                return;

            if ((EntryMode)e.OldValue != EntryMode.All)
            {
                fluidTextBox.textBox.PreviewTextInput -= fluidTextBox.textBox_PreviewTextInput;
                fluidTextBox.textBox.PreviewKeyDown -= fluidTextBox.textBox_PreviewKeyDown;
            }

            if ((EntryMode)e.NewValue != EntryMode.All)
            {
                fluidTextBox.textBox.PreviewTextInput += fluidTextBox.textBox_PreviewTextInput;
                fluidTextBox.textBox.PreviewKeyDown += fluidTextBox.textBox_PreviewKeyDown;
            }
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (EntryMode == EntryMode.Integer && !Char.IsDigit(ch))
                    e.Handled = true;

                if (EntryMode == EntryMode.Double && (!Char.IsDigit(ch) && (ch != digitSeparator[0] || textBox.Text.Contains(digitSeparator[0]))))
                    e.Handled = true;
            }
        }

        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        #endregion

        #region Events support
        private void this_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateWatermarkVisibility();
            //UpdateSelection();
        }

        private void this_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateWatermarkVisibility();
        }

        private void this_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWatermarkVisibility();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateWatermarkVisibility();
        }
        #endregion

        #region Logic
        private void UpdateWatermarkVisibility()
        {
            IsWatermarkVisible = textBox != null && textBox.Text.IsNullOrEmpty() && !textBox.IsFocused;
        }
        #endregion
    }
}

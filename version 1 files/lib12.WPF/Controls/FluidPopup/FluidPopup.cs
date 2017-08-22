using System;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Threading;
using lib12.WPF.Extensions;

namespace lib12.WPF.Controls.FluidPopup
{
    public class FluidPopup : Behavior<Popup>
    {
        #region Fields
        private DispatcherTimer timer;
        #endregion

        #region Props
        public double StaysOpenFor { get; set; }
        public bool CloseAfterClick { get; set; }
        #endregion

        #region Start
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PlacementTarget.MouseEnter += target_MouseEnter;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
            timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(StaysOpenFor) };
            timer.Tick += timer_Tick;
        }
        #endregion

        #region Logic
        private void target_MouseEnter(object sender, MouseEventArgs e)
        {
            if (AssociatedObject.IsOpen)
                return;

            AssociatedObject.Open();
            timer.Start();
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClosePopup();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (AssociatedObject.IsMouseOver || AssociatedObject.PlacementTarget.IsMouseOver)
                return;

            ClosePopup();
        }

        private void ClosePopup()
        {
            AssociatedObject.Close();
            timer.Stop();
        }
        #endregion
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CustomControlClock.CustomControls
{
   // public delegate void TimeChangedEventHandler(object sender, TimeChangeEventArgs args);
    public class AnalogClock : Control
    {
        private Line hourHand;
        private Line minuteHand;
        private Line secondHand;

        static AnalogClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
        }

        //Properties
        public static DependencyProperty ShowSecondsProperty = DependencyProperty.Register("ShowSeconds", typeof(bool), typeof(AnalogClock), new PropertyMetadata(true));
        public bool ShowSeconds
        {
            get { return (bool)GetValue(ShowSecondsProperty); }
            set { SetValue(ShowSecondsProperty, value); }
        }

        //Event
        public static RoutedEvent TimeChangeEvent = 
            EventManager.RegisterRoutedEvent("TimeChanged", RoutingStrategy.Direct, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(AnalogClock));



        public event RoutedPropertyChangedEventHandler<DateTime> TimeChanged
        {
            add
            {
                AddHandler(TimeChangeEvent, value);
            }
            remove
            {
                RemoveHandler(TimeChangeEvent, value);
            }
        }


        public override void OnApplyTemplate()
        {
            hourHand = Template.FindName("PART_HourHand", this) as Line;
            minuteHand = Template.FindName("PART_MinuteHand", this) as Line;
            secondHand = Template.FindName("PART_SecondHand", this) as Line;
            // BindingInCode();

            UpdateHandAngles(DateTime.Now);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            base.OnApplyTemplate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            OnTimeChange(DateTime.Now);
        }

        protected virtual void OnTimeChange(DateTime time)
        {
            UpdateHandAngles(time);
            RaiseEvent(new RoutedPropertyChangedEventArgs <DateTime>(DateTime.Now.AddSeconds(-1),DateTime.Now,TimeChangeEvent));
        }

        private void UpdateHandAngles(DateTime time)
        {
            hourHand.RenderTransform = new RotateTransform((time.Hour / 12.0) * 360, 0.5, 0.5);
            minuteHand.RenderTransform = new RotateTransform((time.Minute / 60.0) * 360, 0.5, 0.5);
            secondHand.RenderTransform = new RotateTransform((time.Second / 60.0) * 360, 0.5, 0.5);
        }



        private void BindingInCode()
        {
            Binding showSecondHandBinding = new Binding()
            {
                Path = new PropertyPath(nameof(ShowSeconds)),
                Source = this,
                Converter = new BooleanToVisibilityConverter()
            };

            secondHand.SetBinding(VisibilityProperty, showSecondHandBinding);
        }
    }
}

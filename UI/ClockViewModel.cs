using DeskClock.Core;
using DeskClock.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace DeskClock.UI
{
    public class ClockViewModel : ViewModelBase
    {
        private Debouncer _debouncer;

        public ClockViewModel()
        {
            StartClockTimer();

            App.Messenger.Register(App.Events.WindowMoved, (Action<Point>)(p => { this.UpdateWindowPosition(p.X, p.Y); }));
            _debouncer = new Debouncer(250);
            DisplayBrush = new SolidColorBrush(Settings.ClockColor);
            FontSize = Settings.ClockFontSize;
            FontFamily = Settings.ClockFontFamily;

            SetBrush();
        }

        #region Clock Display

        private void StartClockTimer()
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += delegate
            {
                RaisePropertyChanged("TimeDisplay");
            };
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        public string TimeDisplay
        {
            get { return DateTime.Now.ToString("t"); }
        }

        #endregion

        #region Settings Visibility

        private bool _isShowing;
        public bool IsShowing
        {
            get { return _isShowing; }
            set
            {
                if (_isShowing != value)
                {
                    _isShowing = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void Show()
        {
            IsShowing = true;
        }

        public void Hide()
        {
            IsShowing = false;
        }

        public void Toggle()
        {
            IsShowing = !IsShowing;
        }

        #endregion

        #region Settings

        public void UpdateWindowPosition(double x, double y)
        {
            _debouncer.Call(() => { Settings.XPosition = x; Settings.YPosition = y; Settings.Save(); });
        }

        private SolidColorBrush _displayBrush;
        public SolidColorBrush DisplayBrush
        {
            get { return _displayBrush; }
            set
            {
                if (_displayBrush != value)
                {
                    _displayBrush = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _fontSize;
        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                if (_fontSize != value)
                {
                    _fontSize = value;
                    Settings.ClockFontSize = value;
                    Settings.Save();

                    RaisePropertyChanged();
                }
            }
        }

        private FontFamily _fontFamily;
        public FontFamily FontFamily
        {
            get { return _fontFamily; }
            set
            {
                if (_fontFamily != value)
                {
                    _fontFamily = value;
                    Settings.ClockFontFamily = value;
                    Settings.Save();

                    RaisePropertyChanged();
                }
            }
        }


        private void SetBrush()
        {
            var color = DisplayBrush.Color;
            BrushRed = color.R;
            BrushBlue = color.B;
            BrushGreen = color.G;
            BrushAlpha = color.A;
        }

        private void UpdateBrush()
        {
            Settings.ClockColor = Color.FromArgb(BrushAlpha, BrushRed, BrushGreen, BrushBlue);
            Settings.Save();

            DisplayBrush = new SolidColorBrush(Settings.ClockColor);
        }

        private byte _brushRed;
        public byte BrushRed
        {
            get { return _brushRed; }
            set
            {
                if (_brushRed != value)
                {
                    _brushRed = value;
                    RaisePropertyChanged();
                    UpdateBrush();
                }
            }
        }

        private byte _brushBlue;
        public byte BrushBlue
        {
            get { return _brushBlue; }
            set
            {
                if (_brushBlue != value)
                {
                    _brushBlue = value;
                    RaisePropertyChanged();
                    UpdateBrush();
                }
            }
        }

        private byte _brushGreen;
        public byte BrushGreen
        {
            get { return _brushGreen; }
            set
            {
                if (_brushGreen != value)
                {
                    _brushGreen = value;
                    RaisePropertyChanged();
                    UpdateBrush();
                }
            }
        }

        private byte _brushAlpha;
        public byte BrushAlpha
        {
            get { return _brushAlpha; }
            set
            {
                if (_brushAlpha != value)
                {
                    _brushAlpha = value;
                    RaisePropertyChanged();
                    UpdateBrush();
                }
            }
        }

        #endregion
    }
}

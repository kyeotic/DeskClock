using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DeskClock.Lib
{
    public class Debouncer
    {
        private Timer _timer;
        private Action _action;
        private double _waitTime;

        public Debouncer(double waitTime)
        {
            _waitTime = waitTime;
        }

        private void CreateTimer()
        {
            //Stop the old timer if it exists
            if (_timer != null)
                _timer.Enabled = false;

            _timer = new Timer(_waitTime);
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = false;
            _timer.Enabled = true;
        }         

        public void Call(Action action)
        {
            _action = action;
            CreateTimer();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _action();
        }
    }
}

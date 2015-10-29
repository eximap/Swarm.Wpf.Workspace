using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;

namespace Swarm.Wpf.Workspace.Controls.Tasks
{
    public class SwarmTimeSpan
    {
        private DateTime? _started;
        private TimeSpan _elapsed = new TimeSpan(0);

        public void Start()
        {
            UpdateElapsed();

            _started = _started ?? DateTime.Now;
        }

        public void Pause()
        {
            UpdateElapsed();

            _started = null;
        }

        private void UpdateElapsed() { if (_started.HasValue) _elapsed = DateTime.Now - (DateTime)_started; _started = DateTime.Now; }

        public void Stop()
        {
            _started = null;
            _elapsed = new TimeSpan(0);
        }

        public TimeSpan GetElapsedTime()
        {
            if (_started.HasValue) _elapsed += (DateTime.Now - (DateTime)_started);
            return _elapsed;
            return new TimeSpan(0);
        }
    }

    class SdTask
    {
        public SdTask()
        {
            Started = null;
            Supsended = null;
        }

        public int Id { get; set; }
        public string Url { get; set; }

        [XmlIgnore]
        protected DateTime? Started { get; set; }
        [XmlIgnore]
        protected DateTime? Supsended { get; set; }

        public TimeSpan ElapsedTime { get { return new TimeSpan(0); } }
        public TimeSpan SupsendedTime { get { return new TimeSpan(0); } }
        
        //private TimeSpan _supsendHolder = new TimeSpan(0);
        //public TimeSpan SupsendedTime
        //{
        //    get
        //    {
        //        return _elapsed;
        //        //if (Supsended == null) return _supsendHolder;
        //        //var rt = DateTime.Now - Supsended; 
        //        //return (TimeSpan)rt;
        //    }
        //}

        //public void Start()
        //{
        //    Started = Started ?? DateTime.Now;
        //    _supsendHolder = new TimeSpan(SupsendedTime.Ticks);
        //    Supsended = null;
        //}

        DateTime? _elapsed = null;
        TimeSpan? _elapsedTime = null;
        //internal void Pause()
        //{
        //    _elapsedTime = _elapsedTime ?? new TimeSpan(0);
        //    _elapsed = _elapsed ?? DateTime.Now;
        //    _elapsedTime = DateTime.Now - _elapsed;
        //
        //    Supsended = Supsended + SupsendedTime ?? DateTime.Now + SupsendedTime;
        //}

        private bool _isFull = false;
        [XmlIgnore]
        public bool IsFull
        {
            get { return _isFull; }
            set
            {
                _isFull = value;
                Element.Height = _isFull ? 80 : 36;
            }
        }
        public string ToString(bool isFull)
        {
            return isFull ?
                String.Format("ID:{0}\nUrl:'{1}'\nElapsed:{2}\nSupsended:{3}", Id, Url, ElapsedTime.ToString(@"dd\.hh\:mm\:ss"), SupsendedTime.ToString(@"dd\.hh\:mm\:ss"))
                : ToString();
        }
        public override string ToString()
        {
            return Id + "\n" +ElapsedTime.ToString(@"dd\.hh\:mm\:ss");
        }

        public void AddToCollection(UIElementCollection collection)
        {
            collection.Add(Element);
        }

        TextBlock _element;
        [XmlIgnore]
        public TextBlock Element
        {
            get { _element = GetUIElement(); return _element; }
            protected set { _element = value; }
        }
        private void Update(TextBlock element)
        {
            element.Text = ToString(IsFull);
        }
        private TextBlock GetUIElement()
        {
            if (_element != null) { Update(_element); return _element; }

            var tb = new TextBlock
            {
                Background = new LinearGradientBrush(Color.FromArgb(255, 243, 243, 243), Colors.White, 1d),
                Height = 36,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };

            tb.MouseEnter += tb_MouseEnter;
            tb.MouseLeave += tb_MouseLeave;

            return tb;
        }

        Brush _old;
        void tb_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _old = Element.Background;
            Element.Background = new LinearGradientBrush(new GradientStopCollection(new[]{
                new GradientStop(Color.FromArgb(150,242,223, 243), 0), new GradientStop(Color.FromArgb(150, 255,243, 255) , 1)}));
        }
        void tb_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Element.Background = _old;
        }
    }
}

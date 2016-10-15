using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using SourceLiveTimer.Demo;

namespace SourceLiveTimer.Speedrun
{
    class Split : ICloneable
    {
        public event EventHandler OnUpdate;

        private int? _BestSegment;
        private string _Name;

        public string Map { get; set; }                
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value && OnUpdate != null)
                    OnUpdate(this, null);
                _Name = value;
            }
        }
        public int? Ticks { get; private set; }
        [JsonIgnore]public int? LiveTicks { get; private set; }
        public int? Segment { get; private set; }
        [JsonIgnore] public int? LiveSegment { get; private set; }
        public int? BestSegment
        {
            get
            {
                return _BestSegment;
            }
            set
            {
                bool changed = _BestSegment != value;
                _BestSegment = value;

                if (changed && OnUpdate != null)
                    OnUpdate(this, null);
            }
        }


        public Split(string map, string name)
        {
            this.Map = map;
            this.Name = name;
        }

        [JsonConstructor]
        public Split(string map, string name, int? segment, int? ticks, int? bestSegment)
        {
            this.Map = map;
            this.Name = name;
            this.Segment = segment;
            this.Ticks = ticks;
            this.BestSegment = bestSegment;
        }

        public void SetTicks(int? segment, int? ticks)
        {
            bool changed = Ticks != ticks || Segment != segment;

            Ticks = ticks;
            Segment = segment;

            if (segment <= BestSegment || BestSegment == null)
                BestSegment = segment;

           if (changed && OnUpdate != null)
                OnUpdate(this, null);
        }

        public void InitializeLiveTicks(int? ticks)
        {
            LiveTicks = ticks;
            LiveSegment = 0;
        }

        public void Update(DemoParseResult result)
        {
            LiveSegment += result.AdjustedTicks;
            LiveTicks += result.AdjustedTicks;
        }
        
        public bool IsBest()
        {
            return (LiveSegment < BestSegment || BestSegment == null);
        }

        public void UpdateBest()
        {
            if (IsBest())
            {
                BestSegment = LiveSegment;
            }
        }

        public void Reset()
        {
            LiveSegment = null;
            LiveTicks = null;
        }

        public Object Clone() {
            return new Split(Map, Name, Segment, Ticks, BestSegment);
        }

    }
}

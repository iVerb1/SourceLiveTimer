using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using SourceLiveTimer.Demo;

namespace SourceLiveTimer.Speedrun
{
    [JsonConverter(typeof(RunJsonConverter))]
    class Run : List<Split>, ICloneable
    {
        public event EventHandler OnNameUpdate;
        public event EventHandler OnSplitUpdate;
        public event EventHandler OnSplit;
        public event EventHandler OnBest;
        public event EventHandler OnResplit;
        public event EventHandler OnPersonalBest;
        public event EventHandler OnReset;

        private int _CurrentSplitIndex = 0;
        private int _TotalTicks = 0;
        private string _Name = null;

        public Category Category { get; set; }
        public int CurrentSplitIndex
        {
            get
            {
                return _CurrentSplitIndex;
            }
            set
            {
                _CurrentSplitIndex = value;
            }
        }        
        public int TotalTicks
        {
            get
            {
                return _TotalTicks;
            }
            set {
                _TotalTicks = value;
            }
        }        
        public string Name
        {
            get
            {
                if (_Name == null)
                    _Name = Category.Name;
                return _Name;
            }
            set {
                bool changed = _Name != value;
                _Name = value;
                if (changed && OnNameUpdate != null)
                    OnNameUpdate(this, null);
            }
        }
        public string CurrentDemo { get; set; }

        
        public Run(Category category)
        {
            this.Category = category;

            InitializeSplits();
            SubscribeToEvents();
        }

        public Run(Category category, string runName, List<Split> splits) : base(splits)
        {
            this.Category = category;
            this.Name = runName;

            SubscribeToEvents();
        }

        public Run(Category category, List<DemoParseResult> demoResults)
        {
            this.Category = category;

            InitializeSplits();
            for (int i = 0; i < demoResults.Count; i++)
            {
                Update(demoResults[i]);
            }
            Reset(true);
            SubscribeToEvents();
        }


        private void InitializeSplits()
        {
            for (int i = 0; i < Category.Maps.Length; i++)
            {
                Split split = new Split(Category.Maps[i], Category.MapNames[i]);
                Add(split);
            }
        }

        private void SubscribeToEvents()
        {
            ForEach(delegate(Split split)
            {
                split.OnUpdate += (o, e) => { OnSplitUpdate(this, null); };
            });
        }

        public void Update(DemoParseResult result)
        {
            if (!LastSplitDone())
            {
                //regular split
                if (result.MapName == GetCurrentSplit().Map)
                {
                    Split(result);

                    if (OnSplit != null)
                        OnSplit(this, null);

                    return;
                }
            }
            if (!AtFirstSplit())
            {
                //resplit if you died and continued
                if (result.MapName == GetPreviousSplit().Map)
                {
                    Resplit(result);

                    if (OnResplit != null)
                        OnResplit(this, null);
                }
            }
        }

        public void Split(DemoParseResult result)
        {
            GetCurrentSplit().InitializeLiveTicks(TotalTicks);
            GetCurrentSplit().Update(result);

            if (GetCurrentSplit().IsBest() && OnBest != null)
                OnBest(this, null);
            
            if(IsPersonalBest() && OnPersonalBest != null)
                OnPersonalBest(this, null);

            TotalTicks += result.AdjustedTicks;
            CurrentSplitIndex++;
        }

        public void Resplit(DemoParseResult result)
        {
            TotalTicks += result.AdjustedTicks;
            GetPreviousSplit().Update(result);
        }      

        public void setTicks(Split split, int? ticks)
        {
            if (ticks == null)
                split.SetTicks(null, null);
            else
            {
                #region Validating split

                int splitIndex = IndexOf(split);

                if (splitIndex < Count - 1)
                {
                    for (int i = splitIndex + 1; i < Count; i++)
                    {
                        if (this[i].Ticks != null)
                        {
                            if (this[i].Ticks < ticks)
                            {
                                throw new InvalidSplitsException();
                            }
                            break;
                        }
                    }
                }
                if (splitIndex > 0)
                {
                    for (int i = splitIndex - 1; i >= 0; i--)
                    {
                        if (this[i].Ticks != null)
                        {
                            if (this[i].Ticks > ticks)
                            {
                                throw new InvalidSplitsException();
                            }
                            break;
                        }
                    }
                }

                #endregion

                #region Updating segment ticks

                int? segment;
                if (splitIndex < Count - 1)
                {
                    Split nextSplit = this[splitIndex + 1];
                    segment = nextSplit.Ticks - ticks;
                }
                if (splitIndex > 0)
                {
                    Split previousSplit = this[splitIndex - 1];
                    segment = ticks - previousSplit.Ticks;
                }
                else
                {
                    segment = ticks;
                }
                split.SetTicks(segment, ticks);

                #endregion
            }
        }

        public void Reset(bool lastSplitAccurate)
        {
            if (AtFirstSplit())
                throw new ArgumentException();

            UpdateBests(lastSplitAccurate);

            foreach (Split split in this)
            {
                if (IsPersonalBest() && lastSplitAccurate)
                    split.SetTicks(split.LiveSegment, split.LiveTicks);

                split.Reset();
            }
            CurrentSplitIndex = 0;
            TotalTicks = 0;

            if (OnReset != null)
                OnReset(this, null);
        }

        public void UpdateBests(bool lastSplitAccurate)
        {
            int maxSplitIndex;
            if (lastSplitAccurate)
                maxSplitIndex = CurrentSplitIndex - 1;
            else
                maxSplitIndex = CurrentSplitIndex - 2;

            for (int i = 0; i <= maxSplitIndex; i++)
            {
                Split split = this[i];
                split.UpdateBest();
            }
        }

        public bool ContainsBests()
        {
            foreach (Split s in this)
            {
                if (s.IsBest())
                    return true;
            }
            return false;
        }

        public int? GetSumOfBest()
        {
            int? sumOfBest = 0;
            foreach (Split split in this)
            {
                if (split.IsBest())
                {
                    sumOfBest += split.LiveSegment;
                }
                else
                {
                    sumOfBest += split.BestSegment;
                }
            }
            return sumOfBest;
        }

        public bool IsPersonalBest()
        {
            if (CurrentSplitIndex == Count && IsAhead())
                return true;
            else
                return false;
        }

        public bool IsAhead() {
            if (!AtFirstSplit())
            {
                return GetPreviousSplit().LiveTicks < GetPreviousSplit().Ticks || GetPreviousSplit().Ticks == null;
            }
            else
                return false;
        }

        public bool AtFirstSplit()
        {
            return CurrentSplitIndex == 0;
        }

        public bool LastSplitDone()
        {
            return CurrentSplitIndex == Count;
        }

        public Split GetSplit(int index)
        {
            return this[index];
        }

        public Split GetCurrentSplit()
        {
            return this[CurrentSplitIndex];
        }

        public Split GetPreviousSplit()
        {
            return this[CurrentSplitIndex - 1];
        }

        public Object Clone()
        {
            List<Split> splits = new List<Split>();
            foreach (Split split in this)
            {
                splits.Add((Split)split.Clone());
            }
            Run run = new Run(Category, Name, splits);
            run.CurrentDemo = CurrentDemo;
            run.CurrentSplitIndex = CurrentSplitIndex;
            run.TotalTicks = TotalTicks;
            return run;
        }
        
    }
}

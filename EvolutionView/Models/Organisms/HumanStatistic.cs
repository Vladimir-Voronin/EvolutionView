using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LiveCharts.Defaults;
using LiveCharts.Geared;

namespace EvolutionView.Models.Organisms
{
    class HumanStatistic
    {
        public static ObservableValue _HeightPointsAverageNow = new ObservableValue(0);

        private ObservableValue HeightPointsAverageNow {
            get { return _HeightPointsAverageNow; }
            set { _HeightPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _BodyPhysicsAverageNow = new ObservableValue(0);

        private ObservableValue BodyPhysicsAverageNow
        {
            get { return _BodyPhysicsAverageNow; }
            set {
                _BodyPhysicsAverageNow = value;
            }
        }
        
        public static ObservableValue _BeautyPointsAverageNow = new ObservableValue(0);

        private ObservableValue BeautyPointsAverageNow {
            get { return _BeautyPointsAverageNow; }
            set {
                _BeautyPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _IntelligencePointsAverageNow = new ObservableValue(0);

        private ObservableValue IntelligencePointsAverageNow
        {
            get { return _IntelligencePointsAverageNow; }
            set {
                _IntelligencePointsAverageNow = value;
            }
        }
        
        public static ObservableValue _EmotionalityPointsAverageNow = new ObservableValue(0);

        private ObservableValue EmotionalityPointsAverageNow
        {
            get { return _EmotionalityPointsAverageNow; }
            set {
                _EmotionalityPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _ExtroversionPointsAverageNow = new ObservableValue(0);

        private ObservableValue ExtroversionPointsAverageNow
        {
            get { return _ExtroversionPointsAverageNow; }
            set {
                _ExtroversionPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _CreativityPointsAverageNow = new ObservableValue(0);

        private ObservableValue CreativityPointsAverageNow
        {
            get { return _CreativityPointsAverageNow; }
            set {
                _CreativityPointsAverageNow = value;
            }
        }

        public void UpdateStatistic(List<Human> alive_humans)
            {
                if(alive_humans.Count > 0)
                {
                    if(alive_humans[0].HeightObject != null)
                        HeightPointsAverageNow.Value = alive_humans.Select(h => h.HeightObject.CurrentPoints).Average();
                    if(alive_humans[0].BodyPhysicsObject != null)
                        BodyPhysicsAverageNow.Value = alive_humans.Select(h => h.BodyPhysicsObject.CurrentPoints).Average();
                    if(alive_humans[0].BeautyObject != null)
                        BeautyPointsAverageNow.Value = alive_humans.Select(h => h.BeautyObject.CurrentPoints).Average();
                    if(alive_humans[0].IntelligenceObject != null)
                        IntelligencePointsAverageNow.Value = alive_humans.Select(h => h.IntelligenceObject.CurrentPoints).Average();
                    if(alive_humans[0].EmotionalityObject != null)
                        EmotionalityPointsAverageNow.Value = alive_humans.Select(h => h.EmotionalityObject.CurrentPoints).Average();
                    if(alive_humans[0].ExtroversionObject != null)
                        ExtroversionPointsAverageNow.Value = alive_humans.Select(h => h.ExtroversionObject.CurrentPoints).Average();
                    if(alive_humans[0].CreativityObject != null)
                        CreativityPointsAverageNow.Value = alive_humans.Select(h => h.CreativityObject.CurrentPoints).Average();
                }
            }

        #region Geared Properties

        private int _NumberOfViewsValues { get; set; } = 10;

        public static GearedValues<double> _HeightGeared = new GearedValues<double>();

        private GearedValues<double> HeightGeared
        {
            get { return _HeightGeared; }
            set
            {
                _HeightGeared = value;
            }
        }

        public static GearedValues<double> _BodyPhysicsGeared = new GearedValues<double>();

        private GearedValues<double> BodyPhysicsGeared
        {
            get { return _BodyPhysicsGeared; }
            set
            {
                _BodyPhysicsGeared = value;
            }
        }

        public static GearedValues<double> _BeautyGeared = new GearedValues<double>();

        private GearedValues<double> BeautyGeared
        {
            get { return _BeautyGeared; }
            set
            {
                _BeautyGeared = value;
            }
        }

        public static GearedValues<double> _IntelligenceGeared = new GearedValues<double>();

        private GearedValues<double> IntelligenceGeared
        {
            get { return _IntelligenceGeared; }
            set
            {
                _IntelligenceGeared = value;
            }
        }

        public static GearedValues<double> _EmotionalityGeared = new GearedValues<double>();

        private GearedValues<double> EmotionalityGeared
        {
            get { return _EmotionalityGeared; }
            set
            {
                _EmotionalityGeared = value;
            }
        }

        public static GearedValues<double> _ExtroversionGeared = new GearedValues<double>();

        private GearedValues<double> ExtroversionGeared
        {
            get { return _ExtroversionGeared; }
            set
            {
                _ExtroversionGeared = value;
            }
        }

        public static GearedValues<double> _CreativityGeared = new GearedValues<double>();

        private GearedValues<double> CreativityGeared
        {
            get { return _CreativityGeared; }
            set
            {
                _CreativityGeared = value;
            }
        }

        #endregion


        public void UpdateGeared()
        {
            HeightGeared.Add(HumanStatistic._HeightPointsAverageNow.Value);
            if (HeightGeared.Count > _NumberOfViewsValues)
                HeightGeared.RemoveAt(0);

            BodyPhysicsGeared.Add(HumanStatistic._BodyPhysicsAverageNow.Value);
            if (BodyPhysicsGeared.Count > _NumberOfViewsValues)
                BodyPhysicsGeared.RemoveAt(0);

            BeautyGeared.Add(HumanStatistic._BeautyPointsAverageNow.Value);
            if (BeautyGeared.Count > _NumberOfViewsValues)
                BeautyGeared.RemoveAt(0);

            IntelligenceGeared.Add(HumanStatistic._IntelligencePointsAverageNow.Value);
            if (IntelligenceGeared.Count > _NumberOfViewsValues)
                IntelligenceGeared.RemoveAt(0);

            EmotionalityGeared.Add(HumanStatistic._EmotionalityPointsAverageNow.Value);
            if (EmotionalityGeared.Count > _NumberOfViewsValues)
                EmotionalityGeared.RemoveAt(0);

            ExtroversionGeared.Add(HumanStatistic._ExtroversionPointsAverageNow.Value);
            if (ExtroversionGeared.Count > _NumberOfViewsValues)
                ExtroversionGeared.RemoveAt(0);

            CreativityGeared.Add(HumanStatistic._CreativityPointsAverageNow.Value);
            if (CreativityGeared.Count > _NumberOfViewsValues)
                CreativityGeared.RemoveAt(0);

        }

        public void ClearGeared()
        {
            HeightGeared.Clear();
            BodyPhysicsGeared.Clear();
            BeautyGeared.Clear();
            IntelligenceGeared.Clear();
            EmotionalityGeared.Clear();
            ExtroversionGeared.Clear();
            CreativityGeared.Clear();
        }
    }
}

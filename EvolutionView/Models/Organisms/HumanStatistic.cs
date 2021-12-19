using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LiveCharts.Defaults;

namespace EvolutionView.Models.Organisms
{
    class HumanStatistic
    {
        public static ObservableValue _HeightPointsAverageNow = new ObservableValue(0);

        public ObservableValue HeightPointsAverageNow {
            get { return _HeightPointsAverageNow; }
            set { _HeightPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _BodyPhysicsAverageNow = new ObservableValue(0);

        public ObservableValue BodyPhysicsAverageNow
        {
            get { return _BodyPhysicsAverageNow; }
            set {
                _BodyPhysicsAverageNow = value;
            }
        }
        
        public static ObservableValue _BeautyPointsAverageNow = new ObservableValue(0);

        public ObservableValue BeautyPointsAverageNow {
            get { return _BeautyPointsAverageNow; }
            set {
                _BeautyPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _IntelligencePointsAverageNow = new ObservableValue(0);

        public ObservableValue IntelligencePointsAverageNow
        {
            get { return _IntelligencePointsAverageNow; }
            set {
                _IntelligencePointsAverageNow = value;
            }
        }
        
        public static ObservableValue _EmotionalityPointsAverageNow = new ObservableValue(0);

        public ObservableValue EmotionalityPointsAverageNow
        {
            get { return _EmotionalityPointsAverageNow; }
            set {
                _EmotionalityPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _ExtroversionPointsAverageNow = new ObservableValue(0);

        public ObservableValue ExtroversionPointsAverageNow
        {
            get { return _ExtroversionPointsAverageNow; }
            set {
                _ExtroversionPointsAverageNow = value;
            }
        }
        
        public static ObservableValue _CreativityPointsAverageNow = new ObservableValue(0);

        public ObservableValue CreativityPointsAverageNow
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
    }
}

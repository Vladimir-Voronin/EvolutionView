using EvolutionView.Models;
using EvolutionView.Models.Organisms;
using EvolutionView.Models.Worlds;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EvolutionView.ViewModels
{
    class StatisticViewModel : INotifyPropertyChanged
    {
        public ChartValues<ObservableValue> Values1 { get; set; }

        public ChartValues<double> Values2 { get; set; }

        public void UpdateStatisticMaxValues()
        {
            //Values2 = new ChartValues<double> { Evolution.WorldType.getHeightMaxPoints(),
            //                                    Evolution.WorldType.getBodyPhysicsMaxPoints(),
            //                                    Evolution.WorldType.getBeautyMaxPoints(),
            //                                    Evolution.WorldType.getIntelligenceMaxPoints(),
            //                                    Evolution.WorldType.getEmotionalityMaxPoints(),
            //                                    Evolution.WorldType.getExtroversionMaxPoints(),
            //                                    Evolution.WorldType.getCreativityMaxPoints(),
            //};
            Values2[0] = Evolution.WorldType.getHeightMaxPoints();
            Values2[1] = Evolution.WorldType.getBodyPhysicsMaxPoints();
            Values2[2] = Evolution.WorldType.getBeautyMaxPoints();
            Values2[3] = Evolution.WorldType.getIntelligenceMaxPoints();
            Values2[4] = Evolution.WorldType.getEmotionalityMaxPoints();
            Values2[5] = Evolution.WorldType.getExtroversionMaxPoints();
            Values2[6] = Evolution.WorldType.getCreativityMaxPoints();

            //Values2.Add(0);
            //Values2.RemoveAt(7);
        }


        public StatisticViewModel()
        {
            HumanStatistic statistic = new HumanStatistic();
            Values1 = new ChartValues<ObservableValue> { HumanStatistic._HeightPointsAverageNow,
                                                         HumanStatistic._BodyPhysicsAverageNow,
                                                         HumanStatistic._BeautyPointsAverageNow,
                                                         HumanStatistic._IntelligencePointsAverageNow,
                                                         HumanStatistic._EmotionalityPointsAverageNow,
                                                         HumanStatistic._ExtroversionPointsAverageNow,
                                                         HumanStatistic._CreativityPointsAverageNow,
                                                         };
            Values2 = new ChartValues<double> { 0,
                                                0,
                                                0,
                                                0,
                                                0,
                                                0,
                                                0,
            };
        }

        #region PropertyChanged logic

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
    }

    
}
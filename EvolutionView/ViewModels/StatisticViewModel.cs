using EvolutionView.Models;
using EvolutionView.Models.Organisms;
using EvolutionView.Models.Worlds;
using EvolutionView.ViewModels.Base;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EvolutionView.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        public ChartValues<ObservableValue> Values1 { get; set; }

        public ChartValues<double> Values2 { get; set; }

        public GearedValues<double> HeightGeared { get; set; }
        public GearedValues<double> BodyPhysicsGeared { get; set; }
        public GearedValues<double> BeautyGeared { get; set; }
        public GearedValues<double> IntelligenceGeared { get; set; }
        public GearedValues<double> EmotionalityGeared { get; set; }
        public GearedValues<double> ExtroversionGeared { get; set; }
        public GearedValues<double> CreativityGeared { get; set; }

        public void UpdateStatisticMaxValues()
        {
            Values2[0] = Evolution.WorldType.getHeightMaxPoints();
            Values2[1] = Evolution.WorldType.getBodyPhysicsMaxPoints();
            Values2[2] = Evolution.WorldType.getBeautyMaxPoints();
            Values2[3] = Evolution.WorldType.getIntelligenceMaxPoints();
            Values2[4] = Evolution.WorldType.getEmotionalityMaxPoints();
            Values2[5] = Evolution.WorldType.getExtroversionMaxPoints();
            Values2[6] = Evolution.WorldType.getCreativityMaxPoints();
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

            HeightGeared = HumanStatistic._HeightGeared;
            BodyPhysicsGeared = HumanStatistic._BodyPhysicsGeared;
            BeautyGeared = HumanStatistic._BeautyGeared;
            IntelligenceGeared = HumanStatistic._IntelligenceGeared;
            EmotionalityGeared = HumanStatistic._EmotionalityGeared;
            ExtroversionGeared = HumanStatistic._ExtroversionGeared;
            CreativityGeared = HumanStatistic._CreativityGeared;
        }
    }

    
}
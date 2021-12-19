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

            Values2 = new ChartValues<double> { BasketballPlayersWorld.HeightMaxPoints,
                                                BasketballPlayersWorld.BodyPhysicsMaxPoints,
                                                BasketballPlayersWorld.BeautyMaxPoints,
                                                BasketballPlayersWorld.IntelligenceMaxPoints,
                                                BasketballPlayersWorld.EmotionalityMaxPoints,
                                                BasketballPlayersWorld.ExtroversionMaxPoints,
                                                BasketballPlayersWorld.CreativityMaxPoints,
            };
            //Values1 = new ChartValues<ObservableValue> { new ObservableValue(0), new ObservableValue(0),  };
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
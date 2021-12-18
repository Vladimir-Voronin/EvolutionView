using System;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using EvolutionView.Infrastructure;
using EvolutionView.Models.Organisms;
using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models
{
    class Evolution : IDisposable, INotifyPropertyChanged
    {
        public static ObservableCollection<Human> HumanList { get; set; } = new ObservableCollection<Human>();

        public static int PopulationThreshold { get; set; } = 200;

        public static bool DeleteDeadHumans { get; set; } = true;

        public static float DefaultDeathCoefficientPart { get; set; } = 1;

        private float Deathcoefficient { get; set; }

        private HumanWorld WorldType { get; set; }

        private List<Human> AliveHumansInThisYear { get; set; }

        private bool StopTheEvolution { get; set; }

        private HumanFactory Factory { get; set; }

        private float MaxPointsInThisYear { get; set; } = 0;
        
        private float MinPointsInThisYear { get; set; } = float.MaxValue;

        private int current_year;

        public int CurrentYear {
            get { return current_year; }
            set
            {
                current_year = value;
                OnPropertyChanged();
            }
        }

        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        private static CancellationToken token = cancelTokenSource.Token;

        private static Task CurrentTask { get; set; }

        public Evolution(HumanWorld world_type, int number_of_people_on_start)
        {
            StopWork();
            WorldType = world_type;

            HumanList.Clear();
            Factory = new HumanFactory();
            Factory.SetSettings(WorldType);

            for (int i = 0; i < number_of_people_on_start; i++)
            {
                HumanList.Add(Factory.ReturnNewHuman());
            }

            Deathcoefficient = DefaultDeathCoefficientPart;
            CurrentYear = 0;
        }

        public static void StopWork()
        {
            if (CurrentTask == null)
            {

            }
            else if (CurrentTask.Status == TaskStatus.Running)
            {
                cancelTokenSource.Cancel();
                CurrentTask.Wait();
            }
            CurrentTask = null;

            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }

        public static void RunInSeparateTask(Evolution evolution)
        {
            CurrentTask = null;
            CurrentTask = Task.Run(evolution.StartEvolution);
        }

        public void StartEvolution()
        {
            ContinueEvolution();
            while(true)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                if (!StopTheEvolution)
                {
                    OneYearOfEvolution();
                    Thread.Sleep(100);
                }
            }
        }

        private void OneYearOfEvolution()
        {
            MaxPointsInThisYear = 0;
            MinPointsInThisYear = float.MaxValue;
            CurrentYear += 1;
            
            foreach (var human in HumanList)
                {
                    if (human.IsAlive)
                    {
                        human.Age += 1;
                        MaxPointsInThisYear = human.Points > MaxPointsInThisYear ? human.Points : MaxPointsInThisYear;
                        MinPointsInThisYear = human.Points < MinPointsInThisYear ? human.Points : MinPointsInThisYear;
                    }
                    if (human.Age == human.LifeExpectancy)
                    {
                        human.IsAlive = false;
                    }
                }

            if (DeleteDeadHumans)
            {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    for (int i = 0; i < HumanList.Count; i++)
                    {
                        if (HumanList[i].IsAlive != true)
                        {
                            HumanList.RemoveAt(i);
                            i--;
                        }
                    }
                });
            }
                
            IEnumerable<Human> alives = from human in HumanList
                                     where human.IsAlive
                                     select human;

            AliveHumansInThisYear = alives.ToList();

            float chance = 0;
            float randomFloat = 0;
            int random_index = -1;

            // Change the DeathCoeficient if numbers of alive humans > PopulationThreshold
            AdjustDeathCoefficient(AliveHumansInThisYear.Count());

            if (AliveHumansInThisYear.Count > 1)
            {
                float coef = MaxPointsInThisYear / 100;
                for (int i = 0; i < AliveHumansInThisYear.Count(); i++)
                {
                    chance = (AliveHumansInThisYear[i].Points - MinPointsInThisYear) / MaxPointsInThisYear / Deathcoefficient / coef;
                    randomFloat = (float)StaticVariables.Rand.NextDouble();
                    if (randomFloat < chance)
                    {
                        while(random_index < 0 || random_index == i)
                        {
                            random_index = StaticVariables.Rand.Next(0, AliveHumansInThisYear.Count());
                        }

                        App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                        {
                            if (random_index >= 0 && random_index != i)
                                HumanList.Add(Factory.ReturnNewHumanByTwoHumans(AliveHumansInThisYear[i], AliveHumansInThisYear[random_index]));
                        });
                    }
                }
            }
        }

        private void AdjustDeathCoefficient(int number_of_alive_humans)
        {
            if(number_of_alive_humans > PopulationThreshold)
            {
                int shift = Convert.ToInt32(PopulationThreshold * 0.1);
                Deathcoefficient = DefaultDeathCoefficientPart + 0.1f + (number_of_alive_humans - PopulationThreshold) / shift;
            }
            else
            {
                Deathcoefficient = DefaultDeathCoefficientPart;
            }
        }

        public void PauseEvolution()
        {
            StopTheEvolution = true;
        }

        public void StopEvolution()
        {

        }

        public void ContinueEvolution()
        {
            StopTheEvolution = false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #region Property changed logic


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
    }
}

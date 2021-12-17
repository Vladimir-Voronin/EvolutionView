using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EvolutionView.Models.Organisms;
using EvolutionView.Models.BaseModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EvolutionView.Models
{
    class Evolution : IDisposable, INotifyPropertyChanged
    {
        public HumanWorld WorldType { get; set; }

        public static ObservableCollection<Human> HumanList { get; set; } = new ObservableCollection<Human>();

        public bool StopTheGame { get; set; }

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
            HumanFactory factory = new HumanFactory();
            factory.SetSettings(WorldType);

            for (int i = 0; i < number_of_people_on_start; i++)
            {
                HumanList.Add(factory.ReturnNewHuman());
            }

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
                if (!StopTheGame)
                {
                    CurrentYear += 1;
                    foreach (var human in HumanList)
                    {
                        if (human.IsAlive) human.Age += 1;
                        if (human.Age == human.LifeExpectancy) human.IsAlive = false;
                    }
                    Thread.Sleep(30);
                }
            }
        }

        public void PauseEvolution()
        {
            StopTheGame = true;
        }

        public void StopEvolution()
        {

        }

        public void ContinueEvolution()
        {
            StopTheGame = false;
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

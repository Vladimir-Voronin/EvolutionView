using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Characteristics;
using EvolutionView.Models.Organisms;
using EvolutionView.Infrastructure.Commands;
using EvolutionView.Models.Worlds;
using EvolutionView.Models;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EvolutionView.ViewModels
{
    class MainWindowViewModel : IDisposable, INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<Human> list_of_humans = Evolution.HumanList;

        public ObservableCollection<Human> ListOfHumans
        {
            get { return list_of_humans; }
            set { list_of_humans = value; }
        }

        private Evolution evolution_object;

        public Evolution EvolutionObject
        {
            get { return evolution_object; }
            set { 
                evolution_object = value;
                OnPropertyChanged();
            }
        }

        private bool delete_dead_humans;

        public bool DeleteDeadHumans
        {
            get { return delete_dead_humans; }
            set { delete_dead_humans = value;
                Evolution.DeleteDeadHumans = value;
            }
        }


        #region GenesSettings

        // CheckBoxes
        #region IsActiveSetting

        private bool is_active_height_characteristic = HeightParametrsDefault.IsActive;

        public bool IsActiveHeightCharacteristic
        {
            get { return is_active_height_characteristic = HeightParametrsDefault.IsActive; }
            set { is_active_height_characteristic = HeightParametrsDefault.IsActive = value; }
        }


        #endregion

        // SLIDERS
        #region Minimum and Maximum Genes  

        // set boundaries for the number of people
        private readonly int minimum_humans = 10;

        public int MinHumans
        {
            get { return minimum_humans; }
        }

        private readonly int maximum_humans = 200;

        public int MaxHumans
        {
            get { return maximum_humans; }
        }

        private int number_of_people = 24;

        public int NumberOfPeople
        {
            get { return number_of_people; }
            set { number_of_people = value; }
        }

        private int min_genes_height = HeightParametrsDefault.min_genes;

        public int MinGenesHeight
        {
            get { return min_genes_height = HeightParametrsDefault.min_genes; }
        }

        private int max_genes_height = HeightParametrsDefault.max_genes;

        public int MaxGenesHeight
        {
            get { return max_genes_height = HeightParametrsDefault.max_genes; }
        }

        private int genes_value_height;

        public int GenesValueHeight
        {
            get { return genes_value_height; }
            set { genes_value_height = value; }
        }

        #endregion

        #endregion

        #region Test Properties

        // Test Properties
        private Human test_human;

        public Human TestHuman
        {
            get { return test_human; }
            set { test_human = value; }
        }

        #endregion

        #endregion

        #region Commands

        public ICommand CreateEvolutionCommand { get; }

        private bool CanCreateEvolutionCommandExecute(object p) => true;

        private void OnCreateEvolutionCommandExecuted(object p)
        {
            // Set Current Genes
            HeightParametrsDefault.CurrentGenes = GenesValueHeight;

            EvolutionObject = new Evolution(new BasketballPlayersWorld(), NumberOfPeople);
        }

        public ICommand StartEvolutionCommand { get; }

        private bool CanStartEvolutionCommandExecute(object p)
        {
            if (EvolutionObject != null) return true;
            return false; 
        }

        private void OnStartEvolutionCommandExecuted(object p)
        {
            Evolution.RunInSeparateTask(EvolutionObject);
        }

        public ICommand ContinueEvolutionCommand { get; }

        private bool CanContinueEvolutionCommandExecute(object p)
        {
            if (EvolutionObject != null) return true;
            return false; 
        }

        private void OnContinueEvolutionCommandExecuted(object p)
        {
            EvolutionObject.ContinueEvolution();
        }
        
        public ICommand PauseEvolutionCommand { get; }

        private bool CanPauseEvolutionCommandExecute(object p)
        {
            if (EvolutionObject != null) return true;
            return false; 
        }

        private void OnPauseEvolutionCommandExecuted(object p)
        {
            EvolutionObject.PauseEvolution();
        }

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            CreateEvolutionCommand = new ActionCommand(OnCreateEvolutionCommandExecuted, CanCreateEvolutionCommandExecute);

            StartEvolutionCommand = new ActionCommand(OnStartEvolutionCommandExecuted, CanStartEvolutionCommandExecute);

            ContinueEvolutionCommand = new ActionCommand(OnContinueEvolutionCommandExecuted, CanContinueEvolutionCommandExecute);

            PauseEvolutionCommand = new ActionCommand(OnPauseEvolutionCommandExecuted, CanPauseEvolutionCommandExecute);

            #endregion
        }

        #region IDisposable Support

        ~MainWindowViewModel()
        {
            Dispose(true);
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Evolution.StopWork();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MainWindowViewModel()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #region Property changed logic


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
    }
}

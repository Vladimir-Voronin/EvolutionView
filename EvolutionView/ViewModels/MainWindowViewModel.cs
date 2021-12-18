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

        private bool delete_dead_humans = Evolution.DeleteDeadHumans;

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
        
        private bool is_active_body_physics_characteristic = BodyPhisicsParametrsDefault.IsActive;

        public bool IsActiveBodyPhysicsCharacteristic
        {
            get { return is_active_body_physics_characteristic = BodyPhisicsParametrsDefault.IsActive; }
            set { is_active_body_physics_characteristic = BodyPhisicsParametrsDefault.IsActive = value; }
        }
        
        private bool is_active_beauty_characteristic = BeautyParametrsDefault.IsActive;

        public bool IsActiveBeautyCharacteristic
        {
            get { return is_active_body_physics_characteristic = BeautyParametrsDefault.IsActive; }
            set { is_active_body_physics_characteristic = BeautyParametrsDefault.IsActive = value; }
        }
        
        private bool is_active_intelligence_characteristic = IntelligenceParametrsDefault.IsActive;

        public bool IsActiveIntelligenceCharacteristic
        {
            get { return is_active_intelligence_characteristic = IntelligenceParametrsDefault.IsActive; }
            set { is_active_intelligence_characteristic = IntelligenceParametrsDefault.IsActive = value; }
        }
        
        private bool is_active_emotionality_characteristic = EmotionalityParametrsDefault.IsActive;

        public bool IsActiveEmotionalityCharacteristic
        {
            get { return is_active_emotionality_characteristic = EmotionalityParametrsDefault.IsActive; }
            set { is_active_emotionality_characteristic = EmotionalityParametrsDefault.IsActive = value; }
        }
        
        private bool is_active_extroversion_characteristic = ExtroversionParametrsDefault.IsActive;

        public bool IsActiveExtroversionCharacteristic
        {
            get { return is_active_extroversion_characteristic = ExtroversionParametrsDefault.IsActive; }
            set { is_active_extroversion_characteristic = ExtroversionParametrsDefault.IsActive = value; }
        }
        
        private bool is_active_creativity_characteristic = CreativityParametrsDefault.IsActive;

        public bool IsActiveCreativityCharacteristic
        {
            get { return is_active_creativity_characteristic = CreativityParametrsDefault.IsActive; }
            set { is_active_creativity_characteristic = CreativityParametrsDefault.IsActive = value; }
        }

        #endregion

        #region Evolution Settings

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
        
        private readonly int minimum_population_threshold = 100;

        public int MinimumPopulationthreshold
        {
            get { return minimum_population_threshold; }
        }

        private readonly int maximum_population_threshold = 2000;

        public int MaximumPopulationthreshold
        {
            get { return maximum_population_threshold; }
        }

        private int population_threshold_value = Evolution.PopulationThreshold;

        public int PopulationThresholdValue
        {
            get { return population_threshold_value; }
            set { population_threshold_value = value;
                Evolution.PopulationThreshold = value;
            }
        }

        #endregion

        // SLIDERS
        #region Minimum and Maximum Genes  

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
        
        private int min_genes_body_physics = BodyPhisicsParametrsDefault.min_genes;

        public int MinGenesBodyPhysics
        {
            get { return min_genes_body_physics = BodyPhisicsParametrsDefault.min_genes; }
        }

        private int max_genes_body_physics = BodyPhisicsParametrsDefault.max_genes;

        public int MaxGenesBodyPhysics
        {
            get { return max_genes_body_physics = BodyPhisicsParametrsDefault.max_genes; }
        }

        private int genes_value_body_physics;

        public int GenesValueBodyPhysics
        {
            get { return genes_value_body_physics; }
            set { genes_value_body_physics = value; }
        }
        
        private int min_genes_beauty = BeautyParametrsDefault.min_genes;

        public int MinGenesBeauty
        {
            get { return min_genes_beauty = BeautyParametrsDefault.min_genes; }
        }

        private int max_genes_beauty = BeautyParametrsDefault.max_genes;

        public int MaxGenesBeauty
        {
            get { return max_genes_beauty = BeautyParametrsDefault.max_genes; }
        }

        private int genes_value_beauty;

        public int GenesValueBeauty
        {
            get { return genes_value_beauty; }
            set { genes_value_beauty = value; }
        }
        
        private int min_genes_intellegence = IntelligenceParametrsDefault.min_genes;

        public int MinGenesIntellegence
        {
            get { return min_genes_intellegence = IntelligenceParametrsDefault.min_genes; }
        }

        private int max_genes_intellegence = IntelligenceParametrsDefault.max_genes;

        public int MaxGenesIntellegence
        {
            get { return max_genes_intellegence = IntelligenceParametrsDefault.max_genes; }
        }

        private int genes_value_intellegence;

        public int GenesValueIntellegence
        {
            get { return genes_value_intellegence; }
            set { genes_value_intellegence = value; }
        }


        private int min_genes_emotionality = EmotionalityParametrsDefault.min_genes;

        public int MinGenesEmotionality
        {
            get { return min_genes_emotionality = EmotionalityParametrsDefault.min_genes; }
        }

        private int max_genes_emotionality = EmotionalityParametrsDefault.max_genes;

        public int MaxGenesEmotionality
        {
            get { return max_genes_emotionality = EmotionalityParametrsDefault.max_genes; }
        }

        private int genes_value_emotionality;

        public int GenesValueEmotionality
        {
            get { return genes_value_emotionality; }
            set { genes_value_emotionality = value; }
        }
        
        
        private int min_genes_extroversion = ExtroversionParametrsDefault.min_genes;

        public int MinGenesExtroversion
        {
            get { return min_genes_extroversion = ExtroversionParametrsDefault.min_genes; }
        }

        private int max_genes_extroversion = ExtroversionParametrsDefault.max_genes;

        public int MaxGenesExtroversion
        {
            get { return max_genes_extroversion = ExtroversionParametrsDefault.max_genes; }
        }

        private int genes_value_extroversion;

        public int GenesValueExtroversion
        {
            get { return genes_value_extroversion; }
            set { genes_value_extroversion = value; }
        }
        
        
        private int min_genes_creativity = CreativityParametrsDefault.min_genes;

        public int MinGenesCreativity
        {
            get { return min_genes_creativity = CreativityParametrsDefault.min_genes; }
        }

        private int max_genes_creativity = CreativityParametrsDefault.max_genes;

        public int MaxGenesCreativity
        {
            get { return max_genes_creativity = CreativityParametrsDefault.max_genes; }
        }

        private int genes_value_creativity;

        public int GenesValueCreativity
        {
            get { return genes_value_creativity; }
            set { genes_value_creativity = value; }
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
            BodyPhisicsParametrsDefault.CurrentGenes = GenesValueBodyPhysics;
            BeautyParametrsDefault.CurrentGenes = GenesValueBeauty;
            IntelligenceParametrsDefault.CurrentGenes = GenesValueIntellegence;
            EmotionalityParametrsDefault.CurrentGenes = GenesValueEmotionality;
            ExtroversionParametrsDefault.CurrentGenes = GenesValueExtroversion;
            CreativityParametrsDefault.CurrentGenes = GenesValueCreativity;

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

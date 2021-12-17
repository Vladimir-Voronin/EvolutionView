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

namespace EvolutionView.ViewModels
{
    class MainWindowViewModel
    {
        #region Properties

        private ObservableCollection<Human> list_of_humans;

        public ObservableCollection<Human> ListOfHumans
        {
            get { return list_of_humans; }
            set { list_of_humans = value; }
        }

        private int current_year;

        public int CurrentYear
        {
            get { return current_year; }
            set { current_year = value; }
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

        private readonly int maximum_humans = 100;

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

        public ICommand StartEvolutionCommand { get; }

        private bool CanStartEvolutionCommandExecute(object p) => true;

        private void OnStartEvolutionCommandExecuted(object p)
        {
            // Set Current Genes
            HeightParametrsDefault.CurrentGenes = GenesValueHeight;

            ListOfHumans.Clear();
            HumanFactory factory = new HumanFactory();
            factory.SetSettings(new BasketballPlayersWorld());

            for (int i = 0; i < NumberOfPeople; i++)
            {
                ListOfHumans.Add(factory.ReturnNewHuman());
            }

            Task t = Task.Run(StartEvolution);
        }

        #endregion

        private void StartEvolution()
        {
            //while(!StopTheGame)
            //{
            //    Year += 1;
            //}
            for (int i = 0; i < 100; i++)
            {
                foreach (var human in ListOfHumans)
                {
                    human.Age += 1;
                }
                Thread.Sleep(10);
            }
        }

        public void PauseEvolution()
        {

        }

        public void ContinueEvolution()
        {

        }

        public void StopEvolution()
        {

        }

        public MainWindowViewModel()
        {
            #region Commands

            StartEvolutionCommand = new ActionCommand(OnStartEvolutionCommandExecuted, CanStartEvolutionCommandExecute);

            #endregion

            ListOfHumans = new ObservableCollection<Human>();
        }
    }
}

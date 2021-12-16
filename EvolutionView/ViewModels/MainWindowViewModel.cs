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

        // set boundaries for the number of people
        private int minimum_humans = 10;

        public int MinHumans 
        {
            get { return minimum_humans; }
        }

        private int maximum_humans = 100;

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

        private Human test_human;

        public Human TestHuman
        {
            get { return test_human; }
            set { test_human = value; }
        }


        #endregion

        #region Commands

        public ICommand StartEvolutionCommand { get; }

        private bool CanStartEvolutionCommandExecute(object p) => true;

        private void OnStartEvolutionCommandExecuted(object p)
        {
            HeightParametrsDefault.CurrentGenes = 10;
            HumanFactory factory = new HumanFactory();
            factory.SetSettings();
            TestHuman = factory.ReturnNewHuman();
            ListOfHumans = new ObservableCollection<Human>();
            ListOfHumans.Add(TestHuman);
        }

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            StartEvolutionCommand = new ActionCommand(OnStartEvolutionCommandExecuted, CanStartEvolutionCommandExecute);

            #endregion
        }
    }
}

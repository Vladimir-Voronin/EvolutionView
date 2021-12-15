using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Characteristics;

namespace EvolutionView.ViewModels
{
    class MainWindowViewModel
    {
        #region Properties

        private ObservableCollection<Сharacteristic> list_of_characteristic;

        public ObservableCollection<Сharacteristic> ListOfCharacteristic
        {
            get { return list_of_characteristic; }
            set { list_of_characteristic = value; }
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


        #endregion

        #region Commands

        #endregion

        public MainWindowViewModel()
        {

        }
    }
}

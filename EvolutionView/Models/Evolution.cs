using System.Collections.ObjectModel;
using EvolutionView.Models.Organisms;
using EvolutionView.Models.BaseModels;
using System.Collections.Generic;
using System.Collections;
using EvolutionView.Infrastructure.Interfaces;
using EvolutionView.Models.Characteristics;

namespace EvolutionView.Models
{
    class Evolution
    {
        public HumanWorld WorldType { get; set; }

        public static ObservableCollection<Human> HumanList { get; set; } = new ObservableCollection<Human>();

        public bool StopTheGame { get; set; }

        public Evolution(HumanWorld world_type, int number_of_people_on_start)
        {
            
            WorldType = world_type;

            HumanList.Clear();
            HumanFactory factory = new HumanFactory();
            factory.SetSettings(WorldType);

            for (int i = 0; i < number_of_people_on_start; i++)
            {
                HumanList.Add(factory.ReturnNewHuman());
            }

            StartEvolution();
        }

        private void StartEvolution()
        {
            while(!StopTheGame)
            {

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
            StopTheGame = true;
        }
    }
}

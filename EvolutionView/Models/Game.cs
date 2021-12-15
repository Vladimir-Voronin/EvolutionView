using System.Collections.Generic;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Organisms;
using EvolutionView.Infrastructure.Interfaces;

namespace EvolutionView.Models
{
    class Game
    {
        public World WorldType { get; set; }

        public List<Human> HumanList { get; set; }

        public List<float> HumanWeight { get; set; }

        public Game(World world_type, List<ICharacteristicParametrsDefault> parametrs)
        {
            WorldType = world_type;
            HumanFactory factory = new HumanFactory();
        }

        private void StartGame()
        {

        }

        public void PauseGame()
        {

        }

        public void ContinueGame()
        {

        }

        public void StopGame()
        {

        }
    }
}

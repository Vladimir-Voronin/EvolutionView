using System.Collections.Generic;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Organisms;

namespace EvolutionView.Models
{
    class Game
    {
        public List<Human> HumanList { get; set; }

        public List<float> HumanWeight { get; set; }
    }
}

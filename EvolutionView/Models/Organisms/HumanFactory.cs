using System.Collections.Generic;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Characteristics;
using EvolutionView.Models.Organisms;
using EvolutionView.Infrastructure.Interfaces;

namespace EvolutionView.Models.Organisms
{
    class HumanFactory
    {
        public HumanFactory()
        {
        }

        public void SetSettings(List<ICharacteristicParametrsDefault> parametrs)
        {
            int genes = 0;
            genes = HeightParametrsDefault.CurrentGenes;
            Height height = new Height();
        }
    }
}

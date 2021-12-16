using System.Collections.Generic;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Characteristics;
using EvolutionView.Models.Organisms;
using EvolutionView.Infrastructure.Interfaces;

namespace EvolutionView.Models.Organisms
{
    class HumanFactory
    {
        //private Dictionary<string, Сharacteristic> SettingsDict { get; set; }

        private int AmountofGenes;

        public HumanFactory()
        {
        }

        public void SetSettings()
        {
            // All characteristics should be in SettingsDict
            int start_index = 0;
            int end_index = 0;
            if(HeightParametrsDefault.IsActive)
            {
                end_index += HeightParametrsDefault.CurrentGenes;
                GeneSeries gen_serias = new GeneSeries(HeightParametrsDefault.CurrentGenes);

                // Set Parametrs Default
                HeightParametrsDefault.StartIndex = start_index;
                HeightParametrsDefault.EndIndex = end_index;

                start_index += HeightParametrsDefault.CurrentGenes;
            }

            AmountofGenes = end_index;
        }

        public Human ReturnNewHuman(HumanWorld world)
        {
            return new Human(AmountofGenes, world);
        }
    }
}

using System.Collections.Generic;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Characteristics;
using EvolutionView.Models.Organisms;
using EvolutionView.Infrastructure.Interfaces;

namespace EvolutionView.Models.Organisms
{
    class HumanFactory
    {
        private Dictionary<string, Сharacteristic> SettingsDict { get; set; }

        private int AmountofGenes;

        public HumanFactory()
        {
        }

        public void SetSettings()
        {
            SettingsDict = new Dictionary<string, Сharacteristic>();
            // All characteristics should be in SettingsDict
            int start_index = 0;
            int end_index = 0;
            if(HeightParametrsDefault.IsActive)
            {
                end_index += HeightParametrsDefault.CurrentGenes;
                GeneSeries gen_serias = new GeneSeries(HeightParametrsDefault.CurrentGenes);
                Height height = new Height(gen_serias, start_index, end_index);
                SettingsDict.Add(HeightParametrsDefault.Name, height);
                start_index += HeightParametrsDefault.CurrentGenes;
            }

            AmountofGenes = end_index;
        }

        public Human ReturnNewHuman()
        {
            return new Human(SettingsDict, AmountofGenes);
        }
    }
}

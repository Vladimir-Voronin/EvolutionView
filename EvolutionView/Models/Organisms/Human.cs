using EvolutionView.Models.BaseModels;
using System.Collections.Generic;
using EvolutionView.Models.Characteristics;
using System.Linq;

namespace EvolutionView.Models.Organisms
{
    class Human : Organism
    {
        public int? HeightValue { get; set; }

        private Dictionary<string, Сharacteristic> SettingsDict { get; set; }

        public List<Gene> genes_list { get; set; }

        public Human(Dictionary<string, Сharacteristic> settings_dict, int amount_of_genes)
        {
            SettingsDict = settings_dict;

            // Add all genes to genes_list
            genes_list = Enumerable.Repeat<Gene>(new Gene(), amount_of_genes).ToList();
            foreach (var chacacteristic in SettingsDict.Values)
            {
                chacacteristic.GenesObject.SetGenesRandomly();
                for (int i = chacacteristic.StartIndex; i < chacacteristic.EndIndex; i++)
                {
                    genes_list[i] = chacacteristic.GenesObject.Serie[i - chacacteristic.StartIndex];
                }
            }

            // Starting calculating methods
            CalculateHeight();
        }

        public void CalculateHeight()
        {
            Height height = (Height)SettingsDict["Height"];
            //genes_list.AddRange(height.GenesObject.Serie);

        }
    }
}

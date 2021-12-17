using EvolutionView.Models.BaseModels;
using System.Collections.Generic;
using EvolutionView.Models.Characteristics;
using System.Linq;
using System;
using EvolutionView.Infrastructure.Interfaces;
using EvolutionView.Infrastructure;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EvolutionView.Infrastructure.HelpClasses;

namespace EvolutionView.Models.Organisms
{
    class Human : Organism, INotifyPropertyChanged
    {
        public static List<ICharacteristicParametrsDefault> HumanCharacteristicList { get; set; } = new List<ICharacteristicParametrsDefault>() { new HeightParametrsDefault() };

        public bool IsAlive { get; set; } = true;

        public int LifeExpectancy { get; set; }

        public int NumbersOfChildren { get; set; }

        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public Height HeightObject { get; set; }

        public float Points { get; set; }

        public List<Gene> GenesList { get; set; }

        public Human(Human first_human, Human second_human, HumanWorld world)
        {
            GenesList = Enumerable.Repeat<Gene>(new Gene(), first_human.GenesList.Count).ToList();

            SetGenesListByCrossover(first_human, second_human); 
            
            GetLifeExpectancy();

            // Starting SetCalculating methods
            SetAndCalculateHeight();

            CalculatePoints(world);

            first_human.NumbersOfChildren += 1;
            second_human.NumbersOfChildren += 1;
        }

        // Initialize full randomly
        public Human(int amount_of_genes, HumanWorld world)
        {
            // Add all genes to genes_list
            GenesList = Enumerable.Repeat<Gene>(new Gene(), amount_of_genes).ToList();

            SetRandomlyGensList();

            GetLifeExpectancy();

            // Starting SetCalculating methods
            SetAndCalculateHeight();

            CalculatePoints(world);
        }

        public void CalculatePoints(HumanWorld world)
        {
            Points += world.CalculatePointsForHumanInThisWorld(this);
        }

        public void GetLifeExpectancy()
        {
            LifeExpectancy = EvaluatePro.LinearFunctionInt(HumanParametrsDefault.LifeCoeficients, HumanParametrsDefault.LifeValues);
        }

        public void SetRandomlyGensList()
        {
            for (int i = 0; i < GenesList.Count; i++)
            {
                Gene Gene = new Gene
                {
                    Value = (byte)StaticVariables.Rand.Next(0, 2)
                };
                GenesList[i] = Gene;
            }
        }

        public void SetGenesListByCrossover(Human first_human, Human second_human)
        {
            for (int i = 0; i < GenesList.Count; i++)
            {
                if (first_human.GenesList[i].Value == second_human.GenesList[i].Value)
                    GenesList[i] = first_human.GenesList[i];
                else
                {
                    Gene gene = new Gene();
                    gene.Value = StaticVariables.Rand.Next(0, 2);
                    GenesList[i] = gene;
                }
                    
            }
        }

        #region SetAndCalculateMethods

        public void SetAndCalculateHeight()
        {
            if (HeightParametrsDefault.IsActive)
            {
                // Create new object
                HeightObject = HeightParametrsDefault.ReturnNewCharacteristic();
                // From GenesList set Serie to object
                HeightObject.GenesObject.Serie = GenesList.GetRange(HeightParametrsDefault.StartIndex, HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex).ToArray();

                // Calculate Height.Value
                int amount_of_genes = HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex;
                float percent_equals_to_1 = GenesList.GetRange(HeightParametrsDefault.StartIndex, HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex).Count((x) => x.Value == 1) /
                    (float)GenesList.GetRange(HeightParametrsDefault.StartIndex, HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex).Count;

                int step = Convert.ToInt32((HeightParametrsDefault.max_height - HeightParametrsDefault.min_height) * percent_equals_to_1);
                HeightObject.Value = Convert.ToInt32(HeightParametrsDefault.min_height + step);
            }
        }

        #endregion

        #region Property changed logic


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion

    }
}

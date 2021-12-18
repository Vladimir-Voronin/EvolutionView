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

        private int _number_of_children;

        public int NumbersOfChildren {
            get { return _number_of_children; }
            set
            {
                _number_of_children = value;
                OnPropertyChanged();
            }
        }

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
        
        public BodyPhysics BodyPhysicsObject { get; set; }

        public Beauty BeautyObject { get; set; }

        public float Points { get; set; }

        public List<Gene> GenesList { get; set; }

        public Human(Human first_human, Human second_human, HumanWorld world)
        {
            GenesList = Enumerable.Repeat<Gene>(new Gene(), first_human.GenesList.Count).ToList();

            SetGenesListByCrossover(first_human, second_human); 
            
            GetLifeExpectancy();

            // Starting SetCalculating methods
            SetAndCalculateAllCharacteristics();

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
            SetAndCalculateAllCharacteristics();

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


        public void SetAndCalculateAllCharacteristics()
        {
            SetAndCalculateHeight();
            SetAndCalculateBodyPhysics();
            SetAndCalculateBeauty();
        }

        public void SetAndCalculateHeight()
        {
            if (HeightParametrsDefault.IsActive)
            {
                int shift = (HeightParametrsDefault.max_value - HeightParametrsDefault.min_value) / HeightParametrsDefault.CurrentGenes / 2;
                // Create new object
                HeightObject = HeightParametrsDefault.ReturnNewCharacteristic();
                // From GenesList set Serie to object
                HeightObject.GenesObject.Serie = GenesList.GetRange(HeightParametrsDefault.StartIndex, HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex).ToArray();

                // Calculate Height.Value
                int amount_of_genes = HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex;
                float percent_equals_to_1 = GenesList.GetRange(HeightParametrsDefault.StartIndex, HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex).Count((x) => x.Value == 1) /
                    (float)GenesList.GetRange(HeightParametrsDefault.StartIndex, HeightParametrsDefault.EndIndex - HeightParametrsDefault.StartIndex).Count;

                int step = Convert.ToInt32((HeightParametrsDefault.max_value - HeightParametrsDefault.min_value) * percent_equals_to_1);
                HeightObject.Value = Convert.ToInt32(HeightParametrsDefault.min_value + step) + StaticVariables.Rand.Next(-shift, shift + 1);
            }
        }
        
        public void SetAndCalculateBodyPhysics()
        {
            if (BodyPhisicsParametrsDefault.IsActive)
            {
                int shift = (BodyPhisicsParametrsDefault.max_value - BodyPhisicsParametrsDefault.min_value) / BodyPhisicsParametrsDefault.CurrentGenes / 2;
                // Create new object
                BodyPhysicsObject = BodyPhisicsParametrsDefault.ReturnNewCharacteristic();
                // From GenesList set Serie to object
                BodyPhysicsObject.GenesObject.Serie = GenesList.GetRange(BodyPhisicsParametrsDefault.StartIndex, BodyPhisicsParametrsDefault.EndIndex - BodyPhisicsParametrsDefault.StartIndex).ToArray();

                // Calculate Height.Value
                int amount_of_genes = BodyPhisicsParametrsDefault.EndIndex - BodyPhisicsParametrsDefault.StartIndex;

                float percent_equals_to_1 = GenesList.GetRange(BodyPhisicsParametrsDefault.StartIndex, BodyPhisicsParametrsDefault.EndIndex - BodyPhisicsParametrsDefault.StartIndex).Count((x) => x.Value == 1) /
                    (float)GenesList.GetRange(BodyPhisicsParametrsDefault.StartIndex, BodyPhisicsParametrsDefault.EndIndex - BodyPhisicsParametrsDefault.StartIndex).Count;

                int step = Convert.ToInt32((BodyPhisicsParametrsDefault.max_value - BodyPhisicsParametrsDefault.min_value) * percent_equals_to_1);
                BodyPhysicsObject.Value = Convert.ToInt32(BodyPhisicsParametrsDefault.min_value + step) + StaticVariables.Rand.Next(-shift, shift + 1);
            }
        }
        
        public void SetAndCalculateBeauty()
        {
            if (BeautyParametrsDefault.IsActive)
            {
                int shift = (BeautyParametrsDefault.max_value - BeautyParametrsDefault.min_value) / BeautyParametrsDefault.CurrentGenes / 2;
                // Create new object
                BeautyObject = BeautyParametrsDefault.ReturnNewCharacteristic();
                // From GenesList set Serie to object
                BeautyObject.GenesObject.Serie = GenesList.GetRange(BeautyParametrsDefault.StartIndex, BeautyParametrsDefault.EndIndex - BeautyParametrsDefault.StartIndex).ToArray();

                // Calculate Height.Value
                int amount_of_genes = BeautyParametrsDefault.EndIndex - BeautyParametrsDefault.StartIndex;

                float percent_equals_to_1 = GenesList.GetRange(BeautyParametrsDefault.StartIndex, BeautyParametrsDefault.EndIndex - BeautyParametrsDefault.StartIndex).Count((x) => x.Value == 1) /
                    (float)GenesList.GetRange(BeautyParametrsDefault.StartIndex, BeautyParametrsDefault.EndIndex - BeautyParametrsDefault.StartIndex).Count;

                int step = Convert.ToInt32((BeautyParametrsDefault.max_value - BeautyParametrsDefault.min_value) * percent_equals_to_1);
                BeautyObject.Value = Convert.ToInt32(BeautyParametrsDefault.min_value + step) + StaticVariables.Rand.Next(-shift, shift + 1);
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

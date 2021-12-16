using EvolutionView.Infrastructure;

namespace EvolutionView.Models
{
    class GeneSeries
    {
        public Gene[] Serie { get; set; }

        public GeneSeries(int length)
        {
            Serie = new Gene[length];
        }

        public void SetGenesRandomly()
        {
            for (int i = 0; i < Serie.Length; i++)
            {
                Serie[i].Value = (byte)StaticVariables.Rand.Next(0, 2);
            }
        }
    }
}

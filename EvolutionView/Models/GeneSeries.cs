using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionView.Models
{
    class GeneSeries
    {
        public Gene[] Serie { get; set; }

        public GeneSeries(int length)
        {
            Serie = new Gene[length];
        }
    }
}

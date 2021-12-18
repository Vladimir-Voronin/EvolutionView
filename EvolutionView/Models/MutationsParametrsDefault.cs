using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionView.Models
{
    class MutationsParametrsDefault
    {
        public static readonly int min_value = 0;
        public static readonly int max_value = 8;

        private static int current_value = 0;

        public static int CurrentValue
        {
            get { return current_value; }
            set
            {
                if (value < min_value) current_value = min_value;
                else if (value > max_value) current_value = max_value;
                else current_value = value;
            }
        }
    }
}

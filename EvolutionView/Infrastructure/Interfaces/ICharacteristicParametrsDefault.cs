using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionView.Infrastructure.Interfaces
{
    interface ICharacteristicParametrsDefault
    {
        public static bool IsActive = true; 
        public static string Name;
        public static readonly int min_genes;
        public static readonly int max_genes;
    }
}

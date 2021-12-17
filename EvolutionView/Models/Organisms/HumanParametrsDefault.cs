using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionView.Models.Organisms
{
    static class HumanParametrsDefault
    {
        public static List<(float, float)> LifeCoeficients { get; set; } = new List<(float, float)>() { (0f, 0.05f),
                                                                                                        (0.05f, 0.5f),
                                                                                                        (0.5f, 0.8f),
                                                                                                        (0.8f, 1.0f),
                                                                                                        };

        public static List<(int, int)> LifeValues { get; set; } = new List<(int, int)>() { (90, 85),
                                                                                           (85, 55),
                                                                                           (55, 40),
                                                                                           (40, 5),
                                                                                         };
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using EvolutionView.Infrastructure;

namespace EvolutionView.Infrastructure.HelpClasses
{
    static class EvaluatePro
    {
        public static float LinearFunctionFloat(int min, int max, int max_points, int current_value, bool IsUpper = true)
        {
            max = max - min;
            current_value = current_value - min;
            float percent = (float)current_value / max;

            if (IsUpper) return percent * max_points;
            else return (1 - percent) * max_points;
        }
        
        public static float LinearFunctionFloatWithFlatMax(int min, int max, int max_points, int current_value, int flat_value)
        {
            if (current_value >= flat_value) return max_points;

            flat_value = flat_value - min;
            current_value = current_value - min;
            float percent = (float)current_value / flat_value;
            return percent * max_points;
        }

        public static float LinearFunctionFloatWithLocalMax(int min, int max, int max_points, int current_value, int local_max)
        {
            if (current_value > 90)
            {
                _ = 1;
            }

            local_max = local_max - min;
            current_value = current_value - min;
            float step =  max_points / (float)local_max;
            if (current_value <= local_max)
            {
                float check = step * current_value;
                return step * current_value;
            }
            else
            {
                float check = max_points - step * (current_value - local_max);
                return max_points - step * (current_value - local_max);

            }

        }

        private static int LinearFunction(float first_coef, float second_coef, int first_val, int second_value, float search_coef)
        {
            second_coef = second_coef - first_coef;
            search_coef = search_coef - first_coef;
            first_coef = 0;

            float percent = search_coef / second_coef;

            if(first_val > second_value)
                return Convert.ToInt32(first_val - (first_val - second_value) * percent);  
            else
                return Convert.ToInt32(first_val + (second_value - first_val) * percent);
        }

        public static int LinearFunctionInt(List<(float, float)> coef, List<(int, int)> values)
        {
            if (coef.Count != values.Count) throw new Exception("Lengthes of Lists not equals to each other");

            float randomFloat = (float)StaticVariables.Rand.NextDouble();

            int i = 0;
            int search_index = -1;
            float first_coef = -1;
            float second_coef = -1;
            foreach (var (first, second) in coef)
            {
                if(randomFloat >= first && randomFloat <= second)
                {
                    first_coef = first;
                    second_coef = second;
                    search_index = i;
                }
                i++;
            }

            int first_value = values[search_index].Item1;
            int second_value = values[search_index].Item2;

            return LinearFunction(first_coef, second_coef, first_value, second_value, randomFloat); ;
        }
    }
}

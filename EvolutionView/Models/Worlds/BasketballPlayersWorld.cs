using EvolutionView.Infrastructure.HelpClasses;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Characteristics;
using EvolutionView.Models.Organisms;
using System;
using System.Collections.Generic;

namespace EvolutionView.Models.Worlds
{
    class BasketballPlayersWorld : HumanWorld
    {
        public static string Name { get; set; } = "Basketball Players";

        public override float CalculatePointsForHumanInThisWorld(Human human)
        {
            float points = 0;

            points += EvaluateHeight(human.HeightObject);
            points += EvaluateBodyPhysics(human.BodyPhysicsObject);
            points += EvaluateBeauty(human.BeautyObject);
            points += EvaluateIntelligence(human.IntelligenceObject);

            return points;
        }

        #region Evaluation Methods

        private float EvaluateHeight(Height height)
        {
            if (height != null && height.Value.HasValue)
            {
                return EvaluatePro.LinearFunctionFloat(HeightParametrsDefault.min_value, HeightParametrsDefault.max_value, 200, height.Value.Value);
            }
            return 0;
        }
        
        private float EvaluateBodyPhysics(BodyPhysics body_physics)
        {
            if (body_physics != null && body_physics.Value.HasValue)
            {
                return EvaluatePro.LinearFunctionFloatWithLocalMax(BodyPhisicsParametrsDefault.min_value, BodyPhisicsParametrsDefault.max_value, 150, body_physics.Value.Value, Convert.ToInt32(BodyPhisicsParametrsDefault.max_value * 0.9));
            }
            return 0;
        }
        
        private float EvaluateBeauty(Beauty body_physics)
        {
            if (body_physics != null && body_physics.Value.HasValue)
            {
                return EvaluatePro.LinearFunctionFloatWithFlatMax(BodyPhisicsParametrsDefault.min_value, BodyPhisicsParametrsDefault.max_value, 50, body_physics.Value.Value, Convert.ToInt32(BeautyParametrsDefault.max_value * 0.3));
            }
            return 0;
        }
        
        private float EvaluateIntelligence(Intelligence intelligence)
        {
            if (intelligence != null && intelligence.Value.HasValue)
            {
                List<(int, int)> coeficients = new List<(int, int)>() { (IntelligenceParametrsDefault.min_value, Convert.ToInt32(IntelligenceParametrsDefault.max_value * 0.4)),
                                                                            (Convert.ToInt32(IntelligenceParametrsDefault.max_value * 0.4), Convert.ToInt32(IntelligenceParametrsDefault.max_value * 0.9)),
                                                                            (Convert.ToInt32(IntelligenceParametrsDefault.max_value * 0.9), IntelligenceParametrsDefault.max_value) };

                List<(int, int)> values = new List<(int, int)>() { (0, 100), (100, 100), (100, 70)};

                return EvaluatePro.LinearFunctionFloatByLists(coeficients, values, intelligence.Value.Value);
            }
            return 0;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Organisms;
using EvolutionView.Models.Characteristics;
using EvolutionView.Infrastructure.HelpClasses;

namespace EvolutionView.Models.Worlds
{
    class BasketballPlayersWorld : HumanWorld
    {
        public new static string Name { get; set; } = "Basketball Players";

        public new static int HeightMaxPoints { get; set; } = 200;
        public new static int BodyPhysicsMaxPoints { get; set; } = 150;
        public new static int BeautyMaxPoints { get; set; } = 50;
        public new static int IntelligenceMaxPoints { get; set; } = 100;
        public new static int EmotionalityMaxPoints { get; set; } = 100;
        public new static int ExtroversionMaxPoints { get; set; } = 60;
        public new static int CreativityMaxPoints { get; set; } = 80;

        public override float CalculatePointsForHumanInThisWorld(Human human)
        {
            float points = 0;

            points += EvaluateHeight(human.HeightObject);
            points += EvaluateBodyPhysics(human.BodyPhysicsObject);
            points += EvaluateBeauty(human.BeautyObject);
            points += EvaluateIntelligence(human.IntelligenceObject);
            points += EvaluateEmotionality(human.EmotionalityObject);
            points += EvaluateExtroversion(human.ExtroversionObject);
            points += EvaluateCreativity(human.CreativityObject);

            return points;
        }

        public override string ToString()
        {
            return Name;
        }

        #region GetMethods

        public override int getHeightMaxPoints()
        {
            return HeightMaxPoints;
        }

        public override int getBodyPhysicsMaxPoints()
        {
            return BodyPhysicsMaxPoints;
        }

        public override int getBeautyMaxPoints()
        {
            return BeautyMaxPoints;
        }

        public override int getIntelligenceMaxPoints()
        {
            return IntelligenceMaxPoints;
        }

        public override int getEmotionalityMaxPoints()
        {
            return EmotionalityMaxPoints;
        }

        public override int getExtroversionMaxPoints()
        {
            return ExtroversionMaxPoints;
        }

        public override int getCreativityMaxPoints()
        {
            return CreativityMaxPoints;
        }

        #endregion


        #region Evaluation Methods

        private float EvaluateHeight(Height height)
        {
            if (height != null && height.Value.HasValue)
            {
                height.CurrentPoints = EvaluatePro.LinearFunctionFloat(HeightParametrsDefault.min_value, HeightParametrsDefault.max_value, HeightMaxPoints, height.Value.Value);
                return height.CurrentPoints;
            }
            return 0;
        }
        
        private float EvaluateBodyPhysics(BodyPhysics body_physics)
        {
            if (body_physics != null && body_physics.Value.HasValue)
            {
                body_physics.CurrentPoints = EvaluatePro.LinearFunctionFloatWithLocalMax(BodyPhisicsParametrsDefault.min_value, 
                                                                                         BodyPhisicsParametrsDefault.max_value, 
                                                                                         BodyPhysicsMaxPoints, body_physics.Value.Value, 
                                                                                         Convert.ToInt32(BodyPhisicsParametrsDefault.max_value * 0.9));
                return body_physics.CurrentPoints;
            }
            return 0;
        }
        
        private float EvaluateBeauty(Beauty beauty)
        {
            if (beauty != null && beauty.Value.HasValue)
            {
                beauty.CurrentPoints = EvaluatePro.LinearFunctionFloatWithFlatMax(BodyPhisicsParametrsDefault.min_value, 
                                                                                  BodyPhisicsParametrsDefault.max_value,
                                                                                  BeautyMaxPoints,
                                                                                  beauty.Value.Value, 
                                                                                  Convert.ToInt32(BeautyParametrsDefault.max_value * 0.3));
                return beauty.CurrentPoints;
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

                List<(int, int)> values = new List<(int, int)>() { (0, IntelligenceMaxPoints), (IntelligenceMaxPoints, IntelligenceMaxPoints), (IntelligenceMaxPoints, Convert.ToInt32(IntelligenceMaxPoints * 0.7)) };

                intelligence.CurrentPoints = EvaluatePro.LinearFunctionFloatByLists(coeficients, values, intelligence.Value.Value);

                return intelligence.CurrentPoints;
            }
            return 0;
        }

        private float EvaluateEmotionality(Emotionality emotionality)
        {
            if (emotionality != null && emotionality.Value.HasValue)
            {
                List<(int, int)> coeficients = new List<(int, int)>() { (EmotionalityParametrsDefault.min_value, Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.6)),
                                                                            (Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.6), Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.8)),
                                                                            (Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.8), EmotionalityParametrsDefault.max_value) };

                List<(int, int)> values = new List<(int, int)>() { (EmotionalityMaxPoints, EmotionalityMaxPoints),
                                                                   (EmotionalityMaxPoints, Convert.ToInt32(EmotionalityMaxPoints * 0.7)), 
                                                                   (Convert.ToInt32(EmotionalityMaxPoints * 0.7), 0) };

                emotionality.CurrentPoints = EvaluatePro.LinearFunctionFloatByLists(coeficients, values, emotionality.Value.Value);

                return emotionality.CurrentPoints;
            }
            return 0;
        }
        
        private float EvaluateExtroversion(Extroversion extroversion)
        {
            if (extroversion != null && extroversion.Value.HasValue)
            {
                List<(int, int)> coeficients = new List<(int, int)>() { (EmotionalityParametrsDefault.min_value, Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.2)),
                                                                            (Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.2), Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.8)),
                                                                            (Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.8), EmotionalityParametrsDefault.max_value) };

                List<(int, int)> values = new List<(int, int)>() { (0, ExtroversionMaxPoints), (ExtroversionMaxPoints, ExtroversionMaxPoints), (ExtroversionMaxPoints, 0) };

                extroversion.CurrentPoints = EvaluatePro.LinearFunctionFloatByLists(coeficients, values, extroversion.Value.Value);

                return extroversion.CurrentPoints;
            }
            return 0;
        }
        
        private float EvaluateCreativity(Creativity creativity)
        {
            if (creativity != null && creativity.Value.HasValue)
            {
                List<(int, int)> coeficients = new List<(int, int)>() { (EmotionalityParametrsDefault.min_value, Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.3)),
                                                                            (Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.3), Convert.ToInt32(EmotionalityParametrsDefault.max_value* 0.7)),
                                                                            (Convert.ToInt32(EmotionalityParametrsDefault.max_value * 0.7), EmotionalityParametrsDefault.max_value) };

                List<(int, int)> values = new List<(int, int)>() { (0, 0), (0, Convert.ToInt32(CreativityMaxPoints *0.2)), (Convert.ToInt32(CreativityMaxPoints*0.2), CreativityMaxPoints) };

                creativity.CurrentPoints = EvaluatePro.LinearFunctionFloatByLists(coeficients, values, creativity.Value.Value);

                return creativity.CurrentPoints;
            }
            return 0;
        }

        #endregion
    }
}

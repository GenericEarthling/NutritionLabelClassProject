namespace NutritionCalculator
{
    class Utilities
    {
        // NOTE: 1 gram = .035274 oz
        //       1 oz = 28.3 grams
        //       1 milliliter = 0.033814 oz
        const double GRAM_TO_OZ = .035274;
        const double OZ_TO_GRAM = 28.3;
        const double MILLILITER_TO_OZ = 0.033814;
        double nutrient = nutrientsPerGram(4, 5);

        // calculate percentage of each nutrient per gram 
        // percentageOfNutrientInEachGram = totalNutrientGramsPerServingOnLabel / totalGramsPerServingOnLabel
        public static double nutrientsPerGram( double i, double j)
        {
            return i / j;
        }
        
        // find the total value for each nutrient in each ingredient
        // totalNutrientValueInRecipe = percentageOfNutrientInEachGram x totalNutrientGramsInRecipe
        public static double totalNutrientValueInRecipe(double i, double j)
        {
            return i * j;
        }

        // ounces to grams conversion (for radio button)
        public static double ouncesToGrams(double ounces)
        {
            return ounces * OZ_TO_GRAM;
        }

        // millileters to oz, then oz to grams  (for radio button)
        public static double milliliterToGram(double milliliter)
        {
            double ounces = milliliter * MILLILITER_TO_OZ;
            return ounces * OZ_TO_GRAM;
        }
    }
}

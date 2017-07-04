using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCalculator
{
    class Ingredient
    {
        public Ingredient()
        {
        }

        private string name;
        private double amount;
        private int servingSize;
        private double calories;
        private double fat;
        private double saturatedFat;
        private double cholesterol;
        private double sodium;
        private double carbohydrates;
        private double fiber;
        private double protein;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public int ServingSize
        {
            get { return servingSize; }
            set { servingSize = value; }
        }
        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }
        public double Fat
        {
            get { return fat; }
            set { fat = value; }
        }
        public double SaturatedFat
        {
            get { return saturatedFat; }
            set { saturatedFat = value; }
        }
        public double Cholesterol
        {
            get { return cholesterol; }
            set { cholesterol = value; }
        }
        public double Sodium
        {
            get { return sodium; }
            set { sodium = value; }
        }
        public double Carbohydrates
        {
            get { return carbohydrates; }
            set { carbohydrates = value; }
        }
        public double Fiber
        {
            get { return fiber; }
            set { fiber = value; }
        }
        public double Protein
        {
            get { return protein; }
            set { protein = value; }
        }

        // display title bar
        public static string displayTitleBar()
        {
            string nameTitle = "Ingredient";
            string amountTitle = "Amount";
            string caloriesTitle = "Calories";
            string fatTitle = "Fat";
            string satFatTitle = "Sat.Fat";
            string cholTitle = "Cholesterol";
            string sodiumTitle = "Sodium";
            string carbsTitle = "Carbs";
            string fiberTitle = "Fiber";
            string proteinTitle = "Protein";

            string display = String.Format("{0,-20} {1,12} {2,12} {3,12} {4,12} {5,12} {6,12} {7,12} {8,12} {9,12}",
               nameTitle, amountTitle, caloriesTitle, fatTitle, satFatTitle, cholTitle, sodiumTitle, carbsTitle, fiberTitle, proteinTitle);

            return display;
        }


        public override string ToString()
        {
            return String.Format("{0,-20} {1,12} {2,12} {3,12} {4,12} {5,12} {6,12} {7,12} {8,12} {9,12}\n",
                Name, Amount,
                Calories.ToString("F1"),
                Fat.ToString("F1"),
                SaturatedFat.ToString("F1"),
                Cholesterol.ToString("F1"),
                Sodium.ToString("F1"),
                Carbohydrates.ToString("F1"),
                Fiber.ToString("F1"),
                Protein.ToString("F1") );
        }
    }
}
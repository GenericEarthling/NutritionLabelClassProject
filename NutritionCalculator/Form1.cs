using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace NutritionCalculator
{
    public partial class FormNutritionCalculator : Form
    {
        public FormNutritionCalculator()
        {
            InitializeComponent();
            labelHeading.Text = Ingredient.displayTitleBar().ToString();
        }
        
        // array variables for storing ingredients
        const int MAX_INGREDIENTS = 15;
        String[] displayArray = new string[MAX_INGREDIENTS];
        int arrayIndex = 0;
        string list;

        // variables for holding recipe totals
        int servings;
        double amount, totalCal, totalFat, totalSatFat, totalChol;
        double totalSodium, totalCarbs, totalFiber, totalProtein;

        private void buttonReset_Click_1(object sender, EventArgs e)
        {
            // reset recipe name
            textBoxRecipeName.Clear();

            labelIngredientList.Visible = false;
            labelRecipeIngredientList.Visible = false;

            // clear totals for display on right label
            totalCal = 0;
            labelCaloriesPerServing.Text = "0";
            totalFat = 0;
            labelFatPerServing.Text = "0";
            totalSatFat = 0;
            labelSatFatPerServing.Text = "0";
            totalChol = 0;
            labelCholesterolPerServing.Text = "0";
            totalSodium = 0;
            labelSodiumPerServing.Text = "0";
            totalCarbs = 0;
            labelCarbsPerServing.Text = "0";
            totalFiber = 0;
            labelFiberPerServing.Text = "0";
            totalProtein = 0;
            labelProteinPerServing.Text = "0";

            // clear all values
            textBoxIngredient.Clear();
            textBoxRecipeAmt.Clear();
            textBoxServingSize.Clear();
            textBoxCalories.Clear();
            textBoxFat.Clear();
            textBoxSatFat.Clear();
            textBoxCholesterol.Clear();
            textBoxSodium.Clear();
            textBoxCarbohydrates.Clear();
            textBoxFiber.Clear();
            textBoxProtein.Clear();

            // turn OFF the Recipe Totals options
            textBoxNumOfServings.Text = "1";
            textBoxNumOfServings.Enabled = false;
            buttonNumOfServings.Enabled = false;

            // reset array index
            arrayIndex = 0;

            // TODO!! Reset the array values to null
        }

        private void buttonNumOfServings_Click_1(object sender, EventArgs e)
        {
            double calPerServing, fatPerServing, satFatPerServing, cholPerServing;
            double sodiumPerServing, carbsPerServing, fiberPerServing, proteinPerServing;
            try
            {
                // devide each nutrient by number of servings
                // TODO: convert this to a method for better exception handling
                servings = Convert.ToInt32(textBoxNumOfServings.Text);
                calPerServing = totalCal / servings;
                labelCaloriesPerServing.Text = calPerServing.ToString("F1");
                fatPerServing = totalFat / servings;
                labelFatPerServing.Text = fatPerServing.ToString("F1");
                satFatPerServing = totalSatFat / servings;
                labelSatFatPerServing.Text = satFatPerServing.ToString("F1");
                cholPerServing = totalChol / servings;
                labelCholesterolPerServing.Text = cholPerServing.ToString("F1");
                sodiumPerServing = totalSodium / servings;
                labelSodiumPerServing.Text = sodiumPerServing.ToString("F1");
                carbsPerServing = totalCarbs / servings;
                labelCarbsPerServing.Text = carbsPerServing.ToString("F1");
                fiberPerServing = totalFiber / servings;
                labelFiberPerServing.Text = fiberPerServing.ToString("F1");
                proteinPerServing = totalProtein / servings;
                labelProteinPerServing.Text = proteinPerServing.ToString("F1");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Number of servings must be greater than zero. Duh! " + ex);
            }
        }

        private void buttonAddIngredient_Click_1(object sender, EventArgs e)
        {
            // create ingredient object and get values
            Ingredient i = new Ingredient();
            try
            {
                i.Name = textBoxIngredient.Text;
                i.Amount = Convert.ToDouble(textBoxRecipeAmt.Text);
                i.ServingSize = Convert.ToInt32(textBoxServingSize.Text);
                i.Calories = Convert.ToDouble(textBoxCalories.Text);
                i.Fat = Convert.ToDouble(textBoxFat.Text);
                i.SaturatedFat = Convert.ToDouble(textBoxSatFat.Text);
                i.Cholesterol = Convert.ToDouble(textBoxCholesterol.Text);
                i.Sodium = Convert.ToDouble(textBoxSodium.Text);
                i.Carbohydrates = Convert.ToDouble(textBoxCarbohydrates.Text);
                i.Fiber = Convert.ToDouble(textBoxFiber.Text);
                i.Protein = Convert.ToDouble(textBoxProtein.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: All fields must have a value. Use 0 for unknown." + ex);
            }

            // calculate radio button conversion (method is at the bottom)
            // TODO: create more/better conversion methods
            amount = i.Amount;  // getCheckedRadioButton(i.Amount);

            // calculate the total percentage of each nutrient per gram
            // I could take out the "Utilities", but I'm leaving it for my reminder of what it is
            double percentageCalories = Utilities.nutrientsPerGram(i.Calories, i.ServingSize);
            double percentageFat = Utilities.nutrientsPerGram(i.Fat, i.ServingSize);
            double percentageSaturatedFat = Utilities.nutrientsPerGram(i.SaturatedFat, i.ServingSize);
            double percentageCholesterol = Utilities.nutrientsPerGram(i.Cholesterol, i.ServingSize);
            double percentageSodium = Utilities.nutrientsPerGram(i.Sodium, i.ServingSize);
            double percentageCarbohydrates = Utilities.nutrientsPerGram(i.Carbohydrates, i.ServingSize);
            double percentageFiber = Utilities.nutrientsPerGram(i.Fiber, i.ServingSize);
            double percentageProtein = Utilities.nutrientsPerGram(i.Protein, i.ServingSize);

            // calculate the percentage of each nutrient * the ingredient nutrient amount in grams
            i.Calories = Utilities.totalNutrientValueInRecipe(percentageCalories, amount);
            i.Fat = Utilities.totalNutrientValueInRecipe(percentageFat, amount);
            i.SaturatedFat = Utilities.totalNutrientValueInRecipe(percentageSaturatedFat, amount);
            i.Cholesterol = Utilities.totalNutrientValueInRecipe(percentageCholesterol, amount);
            i.Sodium = Utilities.totalNutrientValueInRecipe(percentageSodium, amount);
            i.Carbohydrates = Utilities.totalNutrientValueInRecipe(percentageCarbohydrates, amount);
            i.Fiber = Utilities.totalNutrientValueInRecipe(percentageFiber, amount);
            i.Protein = Utilities.totalNutrientValueInRecipe(percentageProtein, amount);

            // save ingredient list to string 
            list = i.ToString(); 
            displayArray[arrayIndex] = list;

            // reset text area for the whole array to reprint values
            labelIngredientList.Text = "";

            // display ingredients
            labelIngredientList.Visible = true;
            foreach (string value in displayArray)
            {
                if (value != null)
                    labelIngredientList.Text += value.ToString();
                else
                    labelIngredientList.Text += "";
            }

            // changes name of ingredient list to the recipe's name
            try
            {
                string recipeTitle = textBoxRecipeName.Text + " Ingredient List";
                labelRecipeIngredientList.Text = recipeTitle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            // increment array index with each "add" button event
            arrayIndex++;
        
            // calculate totals for display on right label
            string recipeName = textBoxRecipeName.Text;
            totalCal += i.Calories;
            labelCaloriesPerServing.Text = totalCal.ToString("F1");
            totalFat += i.Fat;
            labelFatPerServing.Text = totalFat.ToString("F1");
            totalSatFat += i.SaturatedFat;
            labelSatFatPerServing.Text = totalSatFat.ToString("F1");
            totalChol += i.Cholesterol;
            labelCholesterolPerServing.Text = totalChol.ToString("F1");
            totalSodium += i.Sodium;
            labelSodiumPerServing.Text = totalSodium.ToString("F1");
            totalCarbs += i.Carbohydrates;
            labelCarbsPerServing.Text = totalCarbs.ToString("F1");
            totalFiber += i.Fiber;
            labelFiberPerServing.Text = totalFiber.ToString("F1");
            totalProtein += i.Protein;
            labelProteinPerServing.Text = totalProtein.ToString("F1");

            // clear all values
            textBoxIngredient.Clear();
            textBoxRecipeAmt.Clear();
            textBoxServingSize.Clear();
            textBoxCalories.Clear();
            textBoxFat.Clear();
            textBoxSatFat.Clear();
            textBoxCholesterol.Clear();
            textBoxSodium.Clear();
            textBoxCarbohydrates.Clear();
            textBoxFiber.Clear();
            textBoxProtein.Clear();

            // turn on the Recipe Totals options
            textBoxNumOfServings.Text = "1";
            textBoxNumOfServings.Enabled = true;
            buttonNumOfServings.Enabled = true;
            buttonNumOfServings.Visible = true;
        }

        // 1 of 2: This was an accident. I'm too afraid to delete it yet due to design warnings!
        private void button1_Click(object sender, EventArgs e) { }
        // 2 of 2: This was an accident. I'm too afraid to delete it yet due to design warnings!
        private void FormNutritionCalculator_Load(object sender, EventArgs e)   {    }
    }
}

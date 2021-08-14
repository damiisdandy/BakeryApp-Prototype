using System;
using System.Collections.Generic;

namespace BakeryApp_Prototype
{   
    class MyParse
    {
        public static string StringInput(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        public static float FloatInput(string text, string nameOfIngredient="")
        {
            while (true)
            {
                try
                {
                    Console.Write(text, nameOfIngredient);
                    return float.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Numerical Values only e.g 1, 2, 5.45 etc.");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
        }
        public static int IntInput(string text)
        {
            while (true)
            {
                try
                {
                    Console.Write(text);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Numerical Values only e.g 1, 2, 5.45 etc.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
    class Ingredient
    {
        public static float FlourWeight { get; set; }
        public static float FlourCostPerBag { get; set; }
        public static float FlourWeightPerBag { get; set; }
        public string IngredientName { get; set; }
        public float IngredientPercentage { get; set; }
        public float IngredientQuantityPerBag { get; set; }
        public float IngredientCostPerBag { get; set; }
        public Ingredient(string ingredientName, float percentage, float quantityPerBag, float costPerBag)
        {
            IngredientName = ingredientName;
            IngredientPercentage = percentage;
            IngredientQuantityPerBag = quantityPerBag;
            IngredientCostPerBag = costPerBag;
            Console.WriteLine("\n{0} Created!\n", IngredientName);
        }
        
        public override string ToString()
        {
            return IngredientName;
        }

        public float IngredientWeight()
        {
            return (IngredientPercentage / 100) * FlourWeight;
        }

        public static float FlourCost()
        {
            return (FlourWeight / FlourWeightPerBag) * FlourCostPerBag;
        }

        public float DirectCost()
        {
            return (IngredientWeight() / IngredientQuantityPerBag) * IngredientCostPerBag;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte ingCounter = 1;
            int ingredientCount = 1;
            List<Ingredient> ingredients = new List<Ingredient>();

            Console.WriteLine("Ingredient Cost Calculation");
            Console.WriteLine("===========================\n");
            Console.WriteLine("This calculation is based on Baker's Percentage \n");

            ingredientCount = MyParse.IntInput("How many ingredients do you wish to input? ");

            Ingredient.FlourWeight = MyParse.FloatInput("What is your weight of flour? ");
            Ingredient.FlourWeightPerBag = MyParse.FloatInput("Flour's Weight per bag? ");
            Ingredient.FlourCostPerBag = MyParse.FloatInput("Flour's Cost per bag? ");


            while (ingCounter <= ingredientCount)
            {
                string ingName;
                float ingPercentage;
                float ingWeightPerBag;
                float ingCostPerBag;
                Ingredient newIngredient;

                Console.WriteLine("{0}/{1} Ingredients", ingCounter, ingredientCount);
                ingName = MyParse.StringInput("Name of Ingredient? ");
                ingPercentage = MyParse.FloatInput("What is the percentage weight of {0} to flour (0-100)? ", ingName);
                ingWeightPerBag = MyParse.FloatInput("{0}'s Weight per bag (in Kg)? ", ingName);
                ingCostPerBag = MyParse.FloatInput("{0}'s Cost per bag (in)? ", ingName);

                newIngredient = new Ingredient(ingName, ingPercentage, ingWeightPerBag, ingCostPerBag);
                ingredients.Add(newIngredient);
                ingCounter++;
            }

            float totalWeight = Ingredient.FlourWeight;
            float totalCost = Ingredient.FlourCost();

            foreach (Ingredient ingredient in ingredients)
            {
                totalWeight += ingredient.IngredientWeight();
                totalCost += ingredient.DirectCost();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Total weight of mixture is {0}kg and will cost {1}", totalWeight, totalCost);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

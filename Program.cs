using System;
using System.Collections.Generic;
using System.IO;


namespace MyFirstCoreApp
{
    public class Program
    {
     
        public static bool check_isNumeric(char val)
        {
            int x = 0;
            string s = val.ToString();
            bool isNum = int.TryParse(s, out x);
            return isNum;

        }
        public static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + "/budget.txt";
            string text = System.IO.File.ReadAllText(@$"{path}"); 
            decimal total_food_charges = 0.00M;

            for (int i = 0; i < text.Length; i++)
            {
                
                if (text[i] == '$')
                {
                    string value = "";
                    // Start of a dollar value
                    int j = i + 1; // Holds the index for start of the value
                    while ( text[j] == '.' || check_isNumeric(text[j]) == true)
                    {
                        value = String.Concat(value, text[j].ToString());
                        j++;
                        if (j == text.Length)
                        {
                            break;
                        }
                    }
                    if (value.Length == 2)
                    {
                        value = String.Concat(value, ".00");
                    }
                    // Convert the value to an int or decimal.
                    decimal food_charge;
                    Decimal.TryParse(value, out food_charge);
                    total_food_charges += food_charge;


                }

            }
            Console.WriteLine($"So far this month you have spent ${total_food_charges}.");

        }

     

    }
}
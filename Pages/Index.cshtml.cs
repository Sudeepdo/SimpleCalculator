using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace aspnetcoreapp.Pages
{
    public class IndexModel : PageModel
    {
        
        public static Func<double, double> Square = value => Math.Pow(value, 2);
        public static Func<double, double> Cube = value => Math.Pow(value, 3);

        public void OnGet()
        {
            
            ViewData["exponentiationResult"] = "";
            ViewData["squareResult"] = "";
            ViewData["cubeResult"] = "";
            ViewData["additionResult"] = "";
            ViewData["subtractionResult"] = "";
            ViewData["multiplicationResult"] = ""; 
            ViewData["divisionResult"] = ""; 
        }

        public void OnPost()
        {
            
            if (!string.IsNullOrEmpty(Request.Form["value"]) && !string.IsNullOrEmpty(Request.Form["exponent"]))
            {
                double value = double.Parse(Request.Form["value"]);
                double exponent = double.Parse(Request.Form["exponent"]);
                ViewData["exponentiationResult"] = Math.Pow(value, exponent); 
            }

        
            if (!string.IsNullOrEmpty(Request.Form["squareCubeValue"]))
            {
                double squareCubeValue = double.Parse(Request.Form["squareCubeValue"]);
                ViewData["squareResult"] = Square(squareCubeValue);  
                ViewData["cubeResult"] = Cube(squareCubeValue);      
            }

            if (!string.IsNullOrEmpty(Request.Form["num1"]) && !string.IsNullOrEmpty(Request.Form["num2"]) && Request.Form["add"] == "Add")
            {
                double num1 = double.Parse(Request.Form["num1"]);
                double num2 = double.Parse(Request.Form["num2"]);
                ViewData["additionResult"] = num1 + num2;  
            }

            if (!string.IsNullOrEmpty(Request.Form["num1"]) && !string.IsNullOrEmpty(Request.Form["num2"]) && Request.Form["subtract"] == "Subtract")
            {
                double num1 = double.Parse(Request.Form["num1"]);
                double num2 = double.Parse(Request.Form["num2"]);
                ViewData["subtractionResult"] = num1 - num2;  
            }

    
            if (!string.IsNullOrEmpty(Request.Form["num1"]) && !string.IsNullOrEmpty(Request.Form["num2"]) && Request.Form["multiply"] == "Multiply")
            {
                double num1 = double.Parse(Request.Form["num1"]);
                double num2 = double.Parse(Request.Form["num2"]);
                ViewData["multiplicationResult"] = num1 * num2;  
            }

            if (!string.IsNullOrEmpty(Request.Form["num1"]) && !string.IsNullOrEmpty(Request.Form["num2"]) && Request.Form["divide"] == "Divide")
            {
                double num1 = double.Parse(Request.Form["num1"]);
                double num2 = double.Parse(Request.Form["num2"]);
                
                if (num2 != 0)
                {
                    ViewData["divisionResult"] = num1 / num2; 
                }
                else
                {
                    ViewData["divisionResult"] = "Cannot divide by zero";  
                }
            }
        }
    }
}

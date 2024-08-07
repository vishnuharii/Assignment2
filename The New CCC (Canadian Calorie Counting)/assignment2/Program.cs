using System.Web.Http;

namespace Assignment2
{
    /// <summary>
    /// Controller for solving the J1 problem - The New CCC (Canadian Calorie Counting).
    /// </summary>
    [RoutePrefix("api/J1")]
    public class J1Controller : ApiController
    {
        // Calorie counts for each menu item
        // Burger calories: index 0 corresponds to choice 1, index 1 to choice 2, etc.
        int[] burgerCalories = { 461, 431, 420, 0 }; // Chicken Burger, Fish Burger, Veggie Burger, No Burger
        int[] drinkCalories = { 130, 160, 118, 0 }; // Soft Drink, Orange Juice, Milk, No Drink
        int[] sideCalories = { 100, 57, 70, 0 };    // Fries, Baked Potato, Chef Salad, No Side
        int[] dessertCalories = { 167, 266, 75, 0 }; // Apple Pie, Sundae, Fruit Cup, No Dessert

        /// <summary>
        /// Calculates the total calorie count based on the selected menu items.
        /// </summary>
        /// <param name="burger">Index of the burger choice (1-4).</param>
        /// <param name="drink">Index of the drink choice (1-4).</param>
        /// <param name="side">Index of the side choice (1-4).</param>
        /// <param name="dessert">Index of the dessert choice (1-4).</param>
        /// <returns>Total calorie count of the selected items.</returns>
        /// <example>
        /// GET ../api/J1/Menu/4/4/4/4 -> "Your total calorie count is 0"
        /// GET ../api/J1/Menu/1/2/3/4 -> "Your total calorie count is 691"
        /// </example>
        [HttpGet]
        [Route("Menu/{burger}/{drink}/{side}/{dessert}")]
        public string Get(int burger, int drink, int side, int dessert)
        {
            // Validate input to ensure all choices are between 1 and 4.
            if (burger < 1 || burger > 4 || drink < 1 || drink > 4 || side < 1 || side > 4 || dessert < 1 || dessert > 4)
            {
                return "Invalid input. Please ensure all choices are between 1 and 4.";
            }

            // Calculate total calories
            int totalCalories = burgerCalories[burger - 1] + drinkCalories[drink - 1] + sideCalories[side - 1] + dessertCalories[dessert - 1];

            // Return the total calorie count
            return $"Your total calorie count is {totalCalories}";
        }
    }
}

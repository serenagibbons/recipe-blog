using System;
using System.Collections.Generic;
using static System.Environment;

namespace RecipesBlog.Models
{
    
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
        public string Source { get; set; }

        public IEnumerable<string> IngredientsList
        {
            get { return (Ingredients ?? string.Empty).Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries); }
        }
        public IEnumerable<string> DirectionsList
        {
            get { return (Directions ?? string.Empty).Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries); }
        }
    }
}

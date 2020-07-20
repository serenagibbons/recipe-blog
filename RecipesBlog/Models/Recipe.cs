using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Environment;

namespace RecipesBlog.Models
{

    public partial class Recipe
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Directions { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Image_URL { get; set; }

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

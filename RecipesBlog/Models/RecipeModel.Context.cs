namespace RecipesBlog.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RecipesDBEntities : DbContext
    {
        public RecipesDBEntities()
            : base("name=RecipesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Recipe> Recipes { get; set; }
    }
}

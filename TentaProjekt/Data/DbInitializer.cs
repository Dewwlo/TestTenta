using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TentaProjekt.Models;

namespace TentaProjekt.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.AddRange(new ProductCategory{Name = "Tv"}, new ProductCategory { Name = "DVD" }, new ProductCategory { Name = "VHS" }); 
            context.SaveChanges();
        }
    }
}

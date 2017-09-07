using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TentaProjekt.Services
{
    public class ProductCategoryService
    {
        public List<SelectListItem> GetSelectList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = "TV"},
                new SelectListItem {Value = "2", Text = "DVD"},
                new SelectListItem {Value = "3", Text = "VHS"}
            };
        }
    }
}

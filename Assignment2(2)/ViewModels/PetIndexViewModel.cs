using Assignment2_2_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Assignment2_2_.ViewModels
{
    public class PetIndexViewModel
    {
        /*public IQueryable<Pet> Pets { get; set; }*/
        public IPagedList<Pet> Pets { get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        public string Category { get; set; }
        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }
    }
    public class CategoryWithCount
    {
        public int PetCount { get; set; }
        public string CategoryName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return CategoryName + " (" + PetCount.ToString() + ")";
            }
        }
    }
}
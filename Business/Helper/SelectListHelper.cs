using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using Microsoft.AspNetCore.Identity;

namespace Business.Helper
{
    public class SelectListHelper
    {

        public static SelectList StatusSelectList()
        {
            IEnumerable<Status> statuses;
            using FantastikContext db = new FantastikContext();
            statuses = db.Statuses.Where(s => s.StatusId != (int)Statuses.Deleted).ToList();
            

            SelectList statusList = new SelectList(statuses, "StatusId", "Title");
            return statusList;
        }
        public static SelectList CategorySelectList()
        {
            IEnumerable<Category> categories;
            using FantastikContext db = new FantastikContext();
                categories = db.Categories.Where(c => c.StatusId != (int)Statuses.Deleted).ToList();

            SelectList newsCategoryList = new SelectList(categories, "CategoryId", "Title");
            return newsCategoryList;
        }
        public static SelectList PostTypeSelectList()
        {
            IEnumerable<ProductionType> postTypes;
            using FantastikContext db = new FantastikContext();
                postTypes = db.ProductionTypes.ToList();
            

            SelectList postTypeSelectList = new SelectList(postTypes, "PostTypeId", "Title");
            return postTypeSelectList;
        }

    }
}

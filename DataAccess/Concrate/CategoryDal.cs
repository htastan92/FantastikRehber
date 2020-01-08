using System;
using System.Linq;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrate
{
    public class CategoryDal : Repository<Category,FantastikContext>,ICategoryDal
    {
        public bool Publish(int? id)
        {
            using var context = new FantastikContext();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category!=null)
            {
                category.StatusId = (int) Statuses.Active;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Draft(int? id)
        {
            using var context = new FantastikContext();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                category.StatusId = (int)Statuses.Passive;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(int? id)
        {
            using var context = new FantastikContext();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                category.StatusId = (int)Statuses.Deleted;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

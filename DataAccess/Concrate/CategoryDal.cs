using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate
{
    public class CategoryDal : Repository<Category,FantastikContext>,ICategoryDal
    {
        public IList<Category> GetAllByPostId(int? postId)
        {
            using var context = new FantastikContext();
            var post = context.Posts.Include(p => p.PostCategories).ThenInclude(pc=>pc.Category)
                .FirstOrDefault(p=>p.PostId==postId);
            if (post!=null)
            {
                var categories = post.PostCategories.Select(c => c.Category).ToList();
                return categories;
            }
            else
            {
                throw new Exception("Bu PostIdye ait bir kategori bulunamadı");
            }
        }

        public IList<Category> GetAllByProductionId(int? productionId)
        {
            using var context = new FantastikContext();
            var production = context.Productions.Include(p => p.ProductionCategories).ThenInclude(pc => pc.Category)
                .FirstOrDefault(p => p.ProductionId == productionId);
            if (production!=null)
            {
                var categories = production.ProductionCategories.Select(c => c.Category).ToList();
                return categories;
            }
            else
            {
                throw new Exception("Bu ProductionIdye ait bir kategori bulunamadı");
            }
        }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate
{
    public class ProductionDal : Repository<Production,FantastikContext>,IProductionDal
    {
        //ManyToMany Get 
        public Production GetProductionByCategoryWeb(string slug,int? categoryId)
        {
            using var context = new FantastikContext();
            //Verilen categoryId ile uyumlu kategori bulunur.
            var category =  context.Categories.Include(p => p.ProductionCategories).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.CategoryId == categoryId && p.StatusId == (int) Statuses.Active);
            if (category!=null)
            {
                //Bulunan kategoriye ait olan yapımlar listelenir. 
                var productions = category.ProductionCategories.Select(p => p.Production).ToList();
                //Bu yapımlar içinden slug'ı parametreden gelen slug ile eşleşen ve yayında olan yapım bulunur. 
                var production = productions.FirstOrDefault(p => p.Slug == slug && p.StatusId == (int)Statuses.Active);
                return production;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı... ");
            }

        }

        public Production GetProductionByPerformerWeb(string slug,int? performerId)
        {
            using var context = new FantastikContext();
            var performer = context.Performers.Include(p => p.ProductionPerformers).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.PerformerId == performerId);
            if (performer!=null)
            {
                var productions = performer.ProductionPerformers.Select(p => p.Production).ToList();
                var production = productions.FirstOrDefault(p => p.Slug == slug && p.StatusId == (int) Statuses.Active);
                return production;
            }
            else
            {
                throw new Exception("Verdiğiniz performerId ile uyuşan bir performer bulunamadı... ");
            }
        }

        public Production GetProductionByCategoryAdmin(string slug ,int? categoryId)
        {
            using var context = new FantastikContext();
            var category = context.Categories.Include(p => p.ProductionCategories).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.CategoryId == categoryId && p.StatusId != (int)Statuses.Deleted);
            if (category!=null)
            {
                var productions = category.ProductionCategories.Select(p => p.Production).ToList();
                var production =
                    productions.FirstOrDefault(p => p.Slug == slug && p.StatusId == (int) Statuses.Deleted);
                return production;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı... ");
            }
        }

        public Production GetProductionByPerformerAdmin(string slug,int? performerId)
        {
            using var context = new FantastikContext();
            var performer =  context.Performers.Include(p => p.ProductionPerformers).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.PerformerId == performerId);
            if (performer!=null)
            {
                return performer.ProductionPerformers.Select(p => p.Production).ToList()
                    .FirstOrDefault(p => p.Slug == slug && p.StatusId != (int) Statuses.Deleted);
            }
            else
            {
                throw new Exception("Verdiğiniz performerId ile uyuşan bir performer bulunamadı...");
            }
        }

        public IList<Production> GetAllProductionsByCategoryWeb(int? categoryId)
        {
            using var context = new FantastikContext();
            var category = context.Categories.Include(p => p.ProductionCategories).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.CategoryId == categoryId );
            if (category!=null)
            {
                var productions =  category.ProductionCategories.Select(p => p.Production).Where(p=>p.StatusId==(int)Statuses.Active).ToList();
                return productions;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı...");
            }
        }

        public IList<Production> GetAllProductionsByPerformerWeb(int? performerId)
        {
            using var context = new FantastikContext();
            var performer =  context.Performers.Include(p => p.ProductionPerformers).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.PerformerId == performerId );
            if (performer!=null)
            {
                var productions = performer.ProductionPerformers.Select(p => p.Production)
                    .Where(p => p.StatusId == (int) Statuses.Active).ToList();
                return productions;
            }
            else
            {
                throw new Exception("Verdiğiniz performerId ile uyuşan bir performer bulunamadı...");
            }
        }

        public IList<Production> GetAllProductionsByCategoryAdmin(int? categoryId)
        {
            using var context = new FantastikContext();
            var category = context.Categories.Include(p => p.ProductionCategories).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.CategoryId == categoryId);
            if (category!=null)
            {
                var productions = category.ProductionCategories.Select(p => p.Production)
                    .Where(p => p.StatusId != (int) Statuses.Deleted).ToList();
                return productions;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı...");
            }
        }

        public IList<Production> GetAllProductionsByPerformerAdmin(int? performerId)
        {
            using var context = new FantastikContext();
            var performer =  context.Performers.Include(p => p.ProductionPerformers).ThenInclude(pc => pc.Production)
                .FirstOrDefault(p => p.PerformerId == performerId);
            if (performer!=null)
            {
                var productions = performer.ProductionPerformers.Select(p => p.Production)
                    .Where(p => p.StatusId != (int) Statuses.Deleted).ToList();
                return productions;
            }
            else
            {
                throw new Exception("Verdiğiniz performerId ile uyuşan bir performer bulunamadı...");
            }
            
        }

        public void Publish(int? id)
        {
            using FantastikContext context = new FantastikContext();
            var production = context.Productions.FirstOrDefault(p => p.ProductionId == id);
            if (production != null)
            {
                production.StatusId = (int)Statuses.Active;
                context.SaveChanges();
            }
        }

        public void Draft(int? id)
        {
            using FantastikContext context = new FantastikContext();
            var production = context.Productions.FirstOrDefault(p => p.ProductionId == id);
            if (production != null)
            {
                production.StatusId = (int)Statuses.Passive;
                context.SaveChanges();
            }
        }

        public void Remove(int? id)
        {
            using FantastikContext context = new FantastikContext();
            var production = context.Productions.FirstOrDefault(p => p.ProductionId == id);
            if (production != null)
            {
                production.StatusId = (int)Statuses.Deleted;
                context.SaveChanges();
            }
        }
    }
}

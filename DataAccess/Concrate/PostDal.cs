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
    public class PostDal:Repository<Post,FantastikContext>,IPostDal
    {
        public Post GetPostByCategoryWeb(string slug,int? categoryId)
        {
            using var context = new FantastikContext(); 
            var category =  context.Categories.Include(c => c.PostCategories).ThenInclude(pc => pc.Post)
                .FirstOrDefault(c => c.CategoryId == categoryId && c.StatusId==(int)Statuses.Active);
            if (category!=null)
            {
                var posts = category.PostCategories.Select(p => p.Post).ToList();
                var post = posts.FirstOrDefault(p => p.Slug == slug && p.StatusId==(int)Statuses.Active);
                return post;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı... ");
            }
        }

        public Post GetPostByCategoryAdmin(string slug , int? categoryId)
        {
            using var context = new FantastikContext();
            var category = context.Categories.Include(c => c.PostCategories).ThenInclude(pc => pc.Post)
                .FirstOrDefault(c => c.CategoryId == categoryId && c.StatusId != (int)Statuses.Deleted);
            if (category != null)
            {
                var posts = category.PostCategories.Select(p => p.Post).ToList();
                var post = posts.FirstOrDefault(p => p.Slug == slug&&p.StatusId!=(int)Statuses.Deleted);
                return post;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı...");
            }
        }

        public IList<Post> GetAllPostsByCategoryWeb(int? categoryId)
        {
            using var context = new FantastikContext();
            var category = context.Categories.Include(c => c.PostCategories).ThenInclude(pc => pc.Post)
                .FirstOrDefault(c => c.CategoryId == categoryId && c.StatusId != (int)Statuses.Deleted);
            if (category != null)
            {
                var posts = category.PostCategories.Select(p => p.Post).Where(p=>p.StatusId==(int)Statuses.Active).ToList();
               
                return posts;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı...");
            }
        }

        public IList<Post> GetAllPostsByCategoryAdmin(int? categoryId)
        {
            using var context = new FantastikContext();
            var category =  context.Categories.Include(p => p.PostCategories).ThenInclude(pc => pc.Post)
                .FirstOrDefault(p => p.CategoryId == categoryId && p.StatusId != (int)Statuses.Deleted);
            if (category!= null)
            {
                var posts = category.PostCategories.Select(p => p.Post).ToList();
                return posts;
            }
            else
            {
                throw new Exception("Verdiğiniz categoryId ile uyuşan bir category bulunamadı...");
            }
        }

        public bool Publish(int? id)
        {
            using var context = new FantastikContext();
            var post = context.Posts.FirstOrDefault(c => c.PostId == id);
            if (post != null)
            {
                post.StatusId = (int)Statuses.Active;
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
            var post = context.Posts.FirstOrDefault(c => c.PostId == id);
            if (post != null)
            {
                post.StatusId = (int)Statuses.Passive;
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
            var post = context.Posts.FirstOrDefault(c => c.PostId == id);
            if (post != null)
            {
                post.StatusId = (int)Statuses.Deleted;
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

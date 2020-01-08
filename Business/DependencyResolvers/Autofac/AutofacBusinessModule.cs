using System;
using System.Reflection;
using Autofac;
using Business.Abstract;
using Business.Concrate;
using Business.EmailService;
using Core.DataAccess.Abstract;
using Core.DataAccess.Concrate;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrate;
using DataAccess.Context;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<CommentDal>().As<ICommentDal>();

            builder.RegisterType<PhotoManager>().As<IPhotoService>();
            builder.RegisterType<PhotoDal>().As<IPhotoDal>();

            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<PostDal>().As<IPostDal>();

            builder.RegisterType<PostTypeManager>().As<IPostTypeService>();
            builder.RegisterType<PostTypeDal>().As<IPostTypeDal>();

            builder.RegisterType<EmailSender>().As<IEmailSender>();

        }
    }
}

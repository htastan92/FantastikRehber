using Autofac;
using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate;

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
        }
    }
}

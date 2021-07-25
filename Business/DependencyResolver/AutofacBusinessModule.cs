using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Caching.Abstract;
using Caching.Concrete.MemoryCache;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DalLayers;

namespace Business.DependencyResolver
{
 public  class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<UserService>().As<IUserService>();


            builder.RegisterType<StudentDal>().As<IStudentDal>();
            builder.RegisterType<DepartmentDal>().As<IDepartmentDal>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<MemoryCacheService>().As<ICacheService>();




        }
    }
}

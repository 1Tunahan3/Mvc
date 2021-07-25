using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.DalLayers
{
    public class DepartmentDal:EfEntityRepositoryBase<Department,SchoolContext> ,IDepartmentDal
    {
       
    }
}

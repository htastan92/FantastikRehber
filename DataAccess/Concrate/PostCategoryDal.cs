﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrate
{
    public class PostCategoryDal : Repository<PostCategory,FantastikContext>,IPostCategoryDal
    {
    }
}

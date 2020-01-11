using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class ProductionTypeManager : IProductionTypeService
    {
        private readonly IProductTypeDal _postTypeDal;

        public ProductionTypeManager(IProductTypeDal postTypeDal)
        {
            _postTypeDal = postTypeDal;
        }

        public ProductionType Get(int? id)
        {
            return _postTypeDal.Get(pt=>pt.ProductionTypeId==id);
        }

        public IList<ProductionType> GetAll()
        {
            return _postTypeDal.GetAll();
        }

        public void Add(ProductionType post)
        {
            _postTypeDal.Add(post);
            
        }

        public void Update(ProductionType post)
        {
            _postTypeDal.Update(post);
        }

        public void Delete(ProductionType post)
        {
            _postTypeDal.Delete(post);
        }
    }
}

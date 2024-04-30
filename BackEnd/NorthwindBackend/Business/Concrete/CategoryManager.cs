using Business.Abstract;
using Business.Contants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var category = _categoryDal.Get(c => c.CategoryID == categoryId);
            return new SuccessDataResult<Category>(category);
        }

        public IDataResult<List<Category>> GetList()
        {
            var categoryList = _categoryDal.GetList().ToList();
            return new SuccessDataResult<List<Category>>(categoryList);
        }
    }
}

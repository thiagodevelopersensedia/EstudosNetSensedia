using Sensedia.Core.Entities;
using Sensedia.Core.Entities.Specifications;
using Sensedia.Core.Entities.Specifications.Params.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Sensedia.Core.Entities.Specifications.Products
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams = null)
              //: base(x =>
              //(string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
              //(!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
              //(!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
              //)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            //ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
            //    productParams.PageSize);

            //if (!string.IsNullOrEmpty(productParams.Sort))
            //{
            //    switch (productParams.Sort)
            //    {
            //        case "priceAsc":
            //            AddOrderBy(p => p.Price);
            //            break;
            //        case "priceDesc":
            //            AddOrderByDescending(p => p.Price);
            //            break;
            //        default:
            //            AddOrderBy(n => n.Name);
            //            break;
            //    }
            //}
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}

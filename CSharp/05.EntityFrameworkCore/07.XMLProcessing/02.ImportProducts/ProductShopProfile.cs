using _02.ImportProducts.DTOs.Import;
using AutoMapper;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}

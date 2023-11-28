using _03.ImportCategories.DTOs.Import;
using AutoMapper;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<CategoryDto, Category>();
        }
    }
}

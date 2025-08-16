using AzShop.BLL.Services.Interface;
using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using AzShop.DAL.Models;
using AzShop.DAL.Repository.Interface;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services.Classes
{
    public class ProductService : GenericService<ProductRequest,ProductResponse,Product> , IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IFileServices _fileServices;

        public ProductService(IProductRepository repository, IFileServices fileServices):base(repository)
        {
            _repository = repository;
            _fileServices = fileServices;
        }

        public async Task<int> CreateFile(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;
            if (request.MainImage != null)
            {
                var imagePath = await _fileServices.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }
            return _repository.Add(entity);
        }
    }
}

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
    public class BrandService : GenericService<BrandRequest,BrandResponse,Brand> , IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IFileServices _fileServices;

        public BrandService(IBrandRepository repository,IFileServices fileServices):base(repository)
        {
            _repository = repository;
            _fileServices = fileServices;
        }
        public async Task<int> CreateFile(BrandRequest request)
        {
            var entity = request.Adapt<Brand>();
            entity.CreatedAt = DateTime.UtcNow;
            if (request.Image != null)
            {
                var imagePath = await _fileServices.UploadAsync(request.Image);
                entity.Image = imagePath;
            }
            return _repository.Add(entity);
        }

    }
}

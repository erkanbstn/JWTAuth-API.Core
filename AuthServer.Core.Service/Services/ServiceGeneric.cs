using AuthServer.Core.Core.GenericService;
using AuthServer.Core.Core.Repositories;
using AuthServer.Core.Core.UnitOfWork;
using AuthServer.Core.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthServer.Core.Service.Services
{
    public class ServiceGeneric<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(newEntity), 200);
        }

        public async Task<Response<NoDataDto>> DeleteAsync(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id not found.", 404, true);
            }
            _genericRepository.DeleteAsync(isExistEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync()), 200);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);
            if (product == null)
            {
                return Response<TDto>.Fail("Id Not Found.", 404, true);
            }
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(product), 200);
        }

        public async Task<Response<NoDataDto>> Update(TDto entity, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id not found.", 404, true);
            }
            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            _genericRepository.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _genericRepository.Where(predicate);
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()),200);
        }
    }
}
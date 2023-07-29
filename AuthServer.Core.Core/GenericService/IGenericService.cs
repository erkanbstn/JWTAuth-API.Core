using AuthServer.Core.Shared.Dtos;
using System.Linq.Expressions;

namespace AuthServer.Core.Core.GenericService
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TDto>> AddAsync(TEntity entity);
        Task<Response<NoDataDto>> DeleteAsync(TEntity entity);
        Task<Response<NoDataDto>> Update(TEntity entity);
    }
}
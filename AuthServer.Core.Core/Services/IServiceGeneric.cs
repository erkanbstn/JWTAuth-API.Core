using AuthServer.Core.Shared.Dtos;
using System.Linq.Expressions;

namespace AuthServer.Core.Core.GenericService
{
    public interface IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<NoDataDto>> DeleteAsync(int id);
        Task<Response<NoDataDto>> Update(TDto entity, int id);
    }
}

using BLL.Services;
namespace BLL.Interfaces
{
    public interface IGenericService<T, Z>
    {
        public Task<Service> Create(T type);

        public Task<Service> Update(T type);

        public Task<Service> Delete(int id);

        public IQueryable<Z> Query();
    }
}

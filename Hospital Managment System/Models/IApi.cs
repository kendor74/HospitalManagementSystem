namespace Hospital_Managment_System.Models
{
    public interface IApi<T>
    {
        Task<List<T>> GetAll(string api);
        Task<T> GetById(string api, int id);
        Task<T> Create(string api, T entity);
        Task<T> Update(string api, T entity);
        Task<T> Delete(string api, int id);
    }
}

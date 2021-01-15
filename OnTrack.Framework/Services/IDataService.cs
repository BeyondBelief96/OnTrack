using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnTrack.Framework.Services
{
    public interface IDataService<T>
    {
        #region Methods

        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);

        #endregion
    }
}

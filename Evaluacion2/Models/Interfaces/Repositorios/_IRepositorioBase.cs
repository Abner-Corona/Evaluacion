using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces.Repositorios
{
    public interface _IRepositorioBase<T> where T : class
    {
        public Task<T?> GetByIdAsync(uint id, bool? active = true);
        public T? GetById(uint id, bool? active = true);

        public Task<IList<T>> GetAllAsync(bool? active = true);
        public IList<T> GetAll(bool? active = true);

        public Task<T> AddAsync(T item);
        public T Add(T item);

        public Task<T> UpdateAsync(T item);
        public T Update(T item);

        public Task<T> DeleteAsync(T item);
        public T Delete(T item);


    }
}

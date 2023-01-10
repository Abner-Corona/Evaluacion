using Microsoft.EntityFrameworkCore;
using Models.Interfaces.Repositorios;
using Models.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEF
{
    public class _RepositorioBase<T> : _IRepositorioBase<T> where T : _TablaBase
    {
        public _DatabaseContext _context;

        public _RepositorioBase(_DatabaseContext context)
        {
            _context = context;
        }

        public T Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> DeleteAsync(T item)
        {
            item.Activo = false;
            await this.UpdateAsync(item);
            return item;
        }

        public T Delete(T item)
        {
            item.Activo = false;
            this.Update(item);
            return item;
        }
        public IList<T> GetAll(bool? active = true)
        {

            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return entity.ToList();
        }
        public async Task<IList<T>> GetAllAsync(bool? active = true)
        {
            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return await entity.ToListAsync();
        }

        public T? GetById(uint id, bool? active = true)
        {
            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return entity.Where(i => i.Id == id).FirstOrDefault();
        }

        public async Task<T?> GetByIdAsync(uint id, bool? active = true)
        {
            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return await entity.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public T Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}

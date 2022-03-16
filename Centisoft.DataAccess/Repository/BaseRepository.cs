using Centisoft.DataAccess.Contract;
using Centisoft.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.DataAccess.Repository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseModel
    {
        protected DataContext context;
        public BaseRepository(DataContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            //do not saveChanges here if you are saving "child/nested" objects. This will cause the datacontext 
            //to be disposed and you will get an exception. EF is a Unit of Work (UoW) pattern and changes should
            //be saved when everything is done - as the last thing before exiting. Look in the controller for the
            //saveChanges()
            return entity;
        }

        public void DeleteAsync(int id)
        {
            context.Set<T>().Remove(context.Set<T>().FirstOrDefault(x => x.Id == id));
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public void UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}

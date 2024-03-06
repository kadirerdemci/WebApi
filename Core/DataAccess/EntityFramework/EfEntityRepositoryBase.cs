using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>
        where TEntity:class , IEntity,new()
        where TContext:DbContext,new()
    {



        public void Add(TEntity entity)
        {
            //bunu yazmasakta olurdu ama context nesnesi biraz pahalı olduğu için 
            //using dışına çıkılır çıkılmaz Çöp toplayıcı gelir kullanılan nesnesi siler
            //böylelikle performans iyileştirmesi olur.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);  //gelen entity db ile ile ilişkilendir
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;//sonra ekleme işlemini seç
                context.SaveChanges(); // ve kaydet

            }
        }

        public void Delete(TEntity entity)
        {
            //bunu yazmasakta olurdu ama context nesnesi biraz pahalı olduğu için 
            //using dışına çıkılır çıkılmaz Çöp toplayıcı gelir kullanılan nesnesi siler
            //böylelikle performans iyileştirmesi olur.
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);  //gelen entity db ile ile ilişkilendir
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;//sonra silme işlemini seç
                context.SaveChanges(); // ve kaydet



            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();


            }
        }

        public void Update(TEntity entity)
        {
            //bunu yazmasakta olurdu ama context nesnesi biraz pahalı olduğu için 
            //using dışına çıkılır çıkılmaz Çöp toplayıcı gelir kullanılan nesnesi siler
            //böylelikle performans iyileştirmesi olur.
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);  //gelen entity db ile ile ilişkilendir
                updateEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;//sonra modifiye işlemini seç
                context.SaveChanges(); // ve kaydet



            }
        }



    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
        //Where T:class demek generic constraint yapılmış demek 
        //class: demek referans tip demek yani T yerine int felan gelemez sadece referans tipler gelebilir
        //where T:class,IEntity demek T int olamaz referans tip olabilir ve bu referans tip ancak ve ancak
        // IEntity veya onun referansını tutan sınıflar olabilir.
        // where T:class,IEntity,new() ise IEntity referansını tutan newlenebilen sınıfları kabul eder.

    {
        //Burada filter null vermemizin nedeni filter verirse verilen filtrye göre filtrele getir
        //Verilmezsede tüm datayı getir.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

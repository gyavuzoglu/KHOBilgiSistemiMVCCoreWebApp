using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T? GetByID(int id);
        List<T> GetList(Expression<Func<T, bool>> filter);

        //Yeni metodları buraya tanımlayacağız. Diğer Dal lar buradan alacak.
        //dal lara birşey eklememize gerek kalmayacak.
    }
}

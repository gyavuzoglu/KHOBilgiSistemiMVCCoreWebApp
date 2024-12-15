using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfOgrencilerRepository : GenericRepository<OgrencilerTbl>,IOgrencilerDAL
    {

        //public List<OgrencilerTbl> OgrenciFilter(Expression<Func<OgrencilerTbl, bool>> filter)
        //{
        //    using var c = new Context();
        //    return c.Set<OgrencilerTbl>().Where(filter).ToList();
        //}
    }
}

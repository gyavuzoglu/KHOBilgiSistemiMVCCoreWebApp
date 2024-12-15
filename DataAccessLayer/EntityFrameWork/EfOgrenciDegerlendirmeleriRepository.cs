using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfOgrenciDegerlendirmeleriRepository : GenericRepository<OgrenciDegerlendirmeleriTbl>, IOgrenciDegerlendirmeleriDAL
    {
        public List<OgrenciDegerlendirmeleriTbl> DegerlendirmeFilter(Expression<Func<OgrenciDegerlendirmeleriTbl, bool>> filter)
        {
            using var c = new Context();
            return c.Set<OgrenciDegerlendirmeleriTbl>().Where(filter).ToList();
        }

        
    }
}

using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfPersonelRepository : GenericRepository<PersonelTbl>, IPersonelDAL
    {
        public List<PersonelTbl> GetPersonelListWithBirimler()
        {
            using (var c = new Context())
            {
                return c.PersonelTbl.Include(x=>x.BirimlerTbl).ToList();
            }
        }
    }
}

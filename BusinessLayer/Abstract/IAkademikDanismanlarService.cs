using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAkademikDanismanlarService
    {
        void AkademikDanismanAdd(AkademikDanismanlarTbl akademikDanismanlarTbl);
        void AkademikDanismanDelete(AkademikDanismanlarTbl akademikDanismanlarTbl);
        void AkademikDanismanUpdate(AkademikDanismanlarTbl akademikDanismanlarTbl);
        List<AkademikDanismanlarTbl> GetListAll();
        AkademikDanismanlarTbl GetByID(int id);
    }
}

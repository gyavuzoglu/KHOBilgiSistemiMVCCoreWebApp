using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAskeriSiniflarService
    {
        void AskeriSinifAdd(AskeriSiniflarTbl askeriSiniflarTbl);
        void AskeriSinifDelete(AskeriSiniflarTbl askeriSiniflarTbl);
        void AskeriSinifUpdate(AskeriSiniflarTbl askeriSiniflarTbl);
        List<AskeriSiniflarTbl> GetListAll();
        AskeriSiniflarTbl GetByID(int id);
    }
}

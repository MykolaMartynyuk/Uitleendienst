using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uitleendienst.ObjectClass;

namespace Uitleendienst
{
    internal interface InterfaceCRUD
    {
        List<IObject> GetAll();
        IObject GetById(int id);
        int Create(IObject @object);
        void Update(IObject @object);
        void Delete( int id);
    }
}

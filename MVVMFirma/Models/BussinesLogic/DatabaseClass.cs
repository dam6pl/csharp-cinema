using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BussinesLogic
{
    public class DatabaseClass
    {
        #region Fields
        protected FakturyEntities fakturyEntities;
        #endregion

        #region Constructor
        public DatabaseClass(FakturyEntities fakturyEntities)
        {
            this.fakturyEntities = fakturyEntities;
        }
        #endregion
    }
}

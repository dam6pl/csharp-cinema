using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class DatabaseClass
    {
        #region Fields
        protected KinoEntities kinoEntities;
        #endregion

        #region Constructor
        public DatabaseClass(KinoEntities kinoEntities)
        {
            this.kinoEntities = kinoEntities;
        }
        #endregion
    }
}

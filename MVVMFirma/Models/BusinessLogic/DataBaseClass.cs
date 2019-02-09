using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    // Wszystkie klasy logiki biznesowej powinny się znajdować w warstwie Models
    // To jest klasa bazowa, z której będą dziedziczyły wszystkie klasy logiki biznesowej używające bazy danych
    public class DataBaseClass
    {
        #region Fields
        // To jest obiekt odpowiedzialny za połączenie z bazą danych
        protected FakturyEntities fakturyEntities;
        #endregion Fields

        #region Constructor 
        public DataBaseClass(FakturyEntities fakturyEntities)
        {
            this.fakturyEntities = fakturyEntities;
        }
        #endregion Constructor
    }
}

using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class Customers : DatabaseClass
    {
        #region Constructor
        public Customers(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<Klienci> getAllCustomers()
        {
            return new ObservableCollection<Klienci>
                (
                from klient in kinoEntities.Klienci
                select klient
                );
        }
    }
}

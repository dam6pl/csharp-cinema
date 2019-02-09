using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class CustomersB : DatabaseClass
    {
        #region Constructor
        public CustomersB(KinoEntities kinoEntities)
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

        public bool removeCustomer(int klientId)
        {
            try
            {
                Klienci klienci = kinoEntities.Klienci.Find(klientId);
                kinoEntities.Klienci.Remove(klienci);
                kinoEntities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

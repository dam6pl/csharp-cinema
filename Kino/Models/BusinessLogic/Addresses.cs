using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class Addresses : DatabaseClass
    {
        #region Constructor
        public Addresses(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<Adresy> getAllAddresses()
        {
            return new ObservableCollection<Adresy>
                (
                from adres in kinoEntities.Adresy
                select adres
                );
        }
    }
}

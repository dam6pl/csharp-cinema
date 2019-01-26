using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class Rooms : DatabaseClass
    {
        #region Constructor
        public Rooms(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<Sale> getAllRooms()
        {
            return new ObservableCollection<Sale>
                (
                from sala in kinoEntities.Sale
                select sala
                );
        }

        public IQueryable<ComboboxKeyAndValue> getRoomsComboboxItems()
        {
            return
                (
                    from sala in kinoEntities.Sale
                    select new ComboboxKeyAndValue
                    {
                        Key = sala.IdSali,
                        Value = sala.Nazwa + " (ID: " + sala.IdSali + ")"
                    }
                ).ToList().AsQueryable();
        }
    }
}

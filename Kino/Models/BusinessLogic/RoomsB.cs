using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class RoomsB : DatabaseClass
    {
        #region Constructor
        public RoomsB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<Sale> getAllRooms()
        {
            return new ObservableCollection<Sale>
                (
                from sala in kinoEntities.Sale
                where sala.CzyAktywny == true
                select sala
                );
        }

        public IQueryable<ComboboxKeyAndValue> getRoomsComboboxItems()
        {
            return
                (
                    from sala in kinoEntities.Sale
                    where sala.CzyAktywny == true
                    select new ComboboxKeyAndValue
                    {
                        Key = sala.IdSali,
                        Value = sala.Nazwa + " (ID: " + sala.IdSali + ")"
                    }
                ).ToList().AsQueryable();
        }

        public bool removeRoom(int salaId)
        {
            try
            {
                Sale sale = kinoEntities.Sale.Find(salaId);
                sale.CzyAktywny = false;
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

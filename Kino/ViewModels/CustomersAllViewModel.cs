using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class CustomersAllViewModel : AllViewModel<Klienci>
    {
        #region Constructor
        public CustomersAllViewModel()
            : base()
        {
            base.DisplayName = "Wszyscy klienci";
        }
        #endregion Constructor

        #region Properties
        public IQueryable<ComboboxKeyAndValue> GenreComboboxItems
        {
            get
            {
                return
                    (
                        from gatunek in kinoEntities.Gatunki
                        select new ComboboxKeyAndValue
                        {
                            Key = gatunek.IdGatunku,
                            Value = gatunek.Nazwa
                        }
                    ).ToList().AsQueryable();

            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Klienci>
                (
                from klient in kinoEntities.Klienci
                select klient
                );
        }
        #endregion Helpers
    }
}

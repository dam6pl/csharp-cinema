using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
            : base()
        {
            base.DisplayName = "Faktury";
        }
        #endregion Constructor

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (
                from faktura in fakturyEntities.Fakturies
                select new FakturaForAllView
                {
                    IdFaktury = faktura.IdFaktury,
                    Numer = faktura.Numer,
                    DataWystawienia = faktura.DataWystawienia,
                    KontrahentKod = faktura.Kontrahenci.Kod,
                    KontrahentNazwa = faktura.Kontrahenci.Nazwa,
                    KontrahentNip = faktura.Kontrahenci.NIP,
                    TerminPlatnosci = faktura.TerminPlatnosci,
                    SposobPlatnosciNazwa = faktura.SposobyPlatnosci.Nazwa
                }
                );
        }
        #endregion Helpers
    }
}

using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validators;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{   
    // NowyTowarViewModel jest zakladka, a zatem dziedziczy po
    // WorkspaceViewModel
    public class NowaPozycjaFakturyViewModel : JedenViewModel<PozycjeFaktury>    // pod typ generyczny T podstawiono typ Towary
    {
        #region Constructor
        public NowaPozycjaFakturyViewModel()
            :base()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Nowa pozycja faktury";
            // tworzymy nowy pusty obiekt
            this.item = new PozycjeFaktury();
        }
        #endregion Constructor

        #region Properties
        public int? IdTowaru
        {
            get
            {
                return item.IdTowaru;
            }
            set
            {
                if(item.IdTowaru != value)
                {
                    item.IdTowaru = IdTowaru;
                    OnPropertyChanged(() => IdTowaru);
                }
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    OnPropertyChanged(() => Cena);
                }
            }
        }
        public decimal? Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                if (item.Ilosc != value)
                {
                    item.Ilosc = value;
                    OnPropertyChanged(() => Ilosc); 
                }
            }
        }
        public decimal? Rabat
        {
            get
            {
                return item.Rabat;
            }
            set
            {
                if (item.Rabat != value)
                {
                    item.Rabat = value;
                    OnPropertyChanged(() => Rabat);
                }
            }
        }
        #endregion Properties

        #region Helpers
        // To jest metoda która zapisuje rekord
        public override void Save()
        {
            Messenger.Default.Send<PozycjeFaktury>(item);
        }
        #endregion Helpers
    }
}

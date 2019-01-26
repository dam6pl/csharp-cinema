using Kino.Models;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class AddressesNewViewModel : SingleViewModel<Adresy>
    {
        #region Construktor
        public AddressesNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy adres";
            base.ViewType = "Addresses";

            this.item = new Adresy();
        }
        #endregion Constructor

        #region Properties
        public String Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (item.Ulica != value)
                {
                    item.Ulica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }

        public string NrDomu
        {
            get
            {
                return item.NrDomu;
            }
            set
            {
                if (item.NrDomu != value)
                {
                    item.NrDomu = value;
                    OnPropertyChanged(() => NrDomu);
                }
            }
        }

        public string NrLokalu
        {
            get
            {
                return item.NrLokalu;
            }
            set
            {
                if (item.NrLokalu != value)
                {
                    item.NrLokalu = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }

        public string Miejscowosc
        {
            get
            {
                return item.Miejscowosc;
            }
            set
            {
                if (item.Miejscowosc != value)
                {
                    item.Miejscowosc = value;
                    OnPropertyChanged(() => Miejscowosc);
                }
            }
        }

        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }

        public string Poczta
        {
            get
            {
                return item.Poczta;
            }
            set
            {
                if (item.Poczta != value)
                {
                    item.Poczta = value;
                    OnPropertyChanged(() => Poczta);
                }
            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Adresy.Add(item);
            kinoEntities.SaveChanges();
        }
        #endregion Helpers
    }
}

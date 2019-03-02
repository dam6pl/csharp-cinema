using Kino.Models;
using Kino.Models.Validators;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class AddressesNewViewModel : SingleViewModel<Adresy>, IDataErrorInfo
    {
        #region Construktor
        public AddressesNewViewModel(int? id = null)
            : base()
        {
            base.DisplayName = "Nowy adres";
            base.ViewType = "Addresses";

            if (id == null)
                this.item = new Adresy();
            else
                this.item = kinoEntities.Adresy.Find(id);
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
            if (this.item.IdAdresu == 0)
                kinoEntities.Adresy.Add(item);
            else
            {
                Adresy adresy = kinoEntities.Adresy.Find(this.item.IdAdresu);
                adresy = item;
            }

            kinoEntities.SaveChanges();
        }
        #endregion Helpers

        #region Validations
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Ulica")
                    komunikat = StringValidator.IsNotEmpty(this.Ulica) ?? StringValidator.IsStartFromUpper(this.Ulica);
                if (name == "NrDomu")
                    komunikat = StringValidator.IsNotEmpty(this.NrDomu);
                if (name == "Miejscowosc")
                    komunikat = StringValidator.IsNotEmpty(this.Miejscowosc);
                if (name == "KodPocztowy")
                    komunikat = StringValidator.IsNotEmpty(this.KodPocztowy);
                if (name == "Poczta")
                    komunikat = StringValidator.IsNotEmpty(this.Poczta);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Ulica"] == null
                && this["NrDomu"] == null
                && this["Miejscowosc"] == null
                && this["KodPocztowy"] == null
                && this["Poczta"] == null;
        }
        #endregion
    }
}

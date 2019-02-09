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
    class TicketTypesNewViewModel : SingleViewModel<TypyBiletow>, IDataErrorInfo
    {
        #region Construktor
        public TicketTypesNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy typ biletow";
            base.ViewType = "TicketTypes";

            this.item = new TypyBiletow();
        }
        #endregion Constructor

        #region Properties
        public String Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
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
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.TypyBiletow.Add(item);
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
                if (name == "Nazwa")
                    komunikat = StringValidator.IsNotEmpty(this.Nazwa) ?? StringValidator.IsStartFromUpper(this.Nazwa);
                else if (name == "Cena")
                    komunikat = DecimalValidation.IsNotEmpty(this.Cena) ?? DecimalValidation.IsPositive(this.Cena);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Nazwa"] == null
                && this["Cena"] == null;
        }
        #endregion
    }
}

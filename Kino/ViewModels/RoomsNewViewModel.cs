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
    class RoomsNewViewModel : SingleViewModel<Sale>, IDataErrorInfo
    {
        #region Construktor
        public RoomsNewViewModel()
            : base()
        {
            base.DisplayName = "Nowa sala";
            base.ViewType = "Rooms";

            this.item = new Sale();
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
        public int? Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }
        public int? LiczbaMiejsc
        {
            get
            {
                return item.LiczbaMiejsc;
            }
            set
            {
                if (item.LiczbaMiejsc != value)
                {
                    item.LiczbaMiejsc = value;
                    OnPropertyChanged(() => LiczbaMiejsc);
                }
            }
        }
        public bool? Sala3D
        {
            get
            {
                return item.Sala3D;
            }
            set
            {
                if (item.Sala3D != value)
                {
                    item.Sala3D = value;
                    OnPropertyChanged(() => Sala3D);
                }
            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Sale.Add(item);
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
                else if (name == "Numer")
                    komunikat = IntegerValidation.IsNotEmpty(this.Numer) ?? IntegerValidation.IsPositive(this.Numer);
                else if (name == "LiczbaMiejsc")
                    komunikat = IntegerValidation.IsNotEmpty(this.LiczbaMiejsc) ?? IntegerValidation.IsPositive(this.LiczbaMiejsc);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Nazwa"] == null
                && this["Numer"] == null
                && this["LiczbaMiejsc"] == null;
        }
        #endregion
    }
}

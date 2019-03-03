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
    class GenreNewViewModel : SingleViewModel<Gatunki>, IDataErrorInfo
    {
        #region Construktor
        public GenreNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy gatunek";
            base.ViewType = "Genre";

            this.item = new Gatunki();
            this.item.CzyAktywny = true;
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
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Gatunki.Add(item);
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

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Nazwa"] == null;
        }
        #endregion
    }
}

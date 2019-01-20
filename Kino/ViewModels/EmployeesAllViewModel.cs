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
    class EmployeesAllViewModel : AllViewModel<EmployeesForAllView>
    {
        #region Constructor
        public EmployeesAllViewModel()
            : base()
        {
            base.DisplayName = "Wszyscy pracownicy";
        }
        #endregion Constructor

        #region Properties
        #endregion

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<EmployeesForAllView>
                (
                from pracownik in kinoEntities.Pracownicy
                select new EmployeesForAllView
                    {
                        IdPracownika = pracownik.IdPracownika,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        Stanowisko = pracownik.Stanowisko,
                        Telefon = pracownik.Telefon,
                        Adres = pracownik.Adresy.Ulica + " " + pracownik.Adresy.NrDomu + ", " 
                            + pracownik.Adresy.Miejscowosc + " " + pracownik.Adresy.KodPocztowy
                    }
                );
        }
        #endregion Helpers
    }
}

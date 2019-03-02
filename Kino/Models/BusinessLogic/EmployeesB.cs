using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class EmployeesB : DatabaseClass
    {
        #region Constructor
        public EmployeesB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<EmployeesForAllView> getAllEmployees()
        {
            return new ObservableCollection<EmployeesForAllView>
                (
                from pracownik in kinoEntities.Pracownicy
                where pracownik.CzyAktywny == true
                select new EmployeesForAllView
                    {
                        IdPracownika = pracownik.IdPracownika,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        Stanowisko = pracownik.Stanowisko,
                        Telefon = pracownik.Telefon,
                        Adres = pracownik.Adresy.Ulica + " " + pracownik.Adresy.NrDomu + ", " 
                            + " " + pracownik.Adresy.KodPocztowy + " " + pracownik.Adresy.Miejscowosc
                }
                );
        }

        public IQueryable<ComboboxKeyAndValue> getEmployeeComboboxItems()
        {
            return
                (
                    from pracownik in kinoEntities.Pracownicy
                    where pracownik.CzyAktywny == true
                    select new ComboboxKeyAndValue
                    {
                        Key = pracownik.IdPracownika,
                        Value = pracownik.Imie + " " + pracownik.Nazwisko
                            + " (Stanowisko: " + pracownik.Stanowisko + ")"
                    }
                ).ToList().AsQueryable();
        }

        public bool removeEmployee(int pracownikId)
        {
            try
            {
                Pracownicy pracownicy = kinoEntities.Pracownicy.Find(pracownikId);
                pracownicy.CzyAktywny = false;
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

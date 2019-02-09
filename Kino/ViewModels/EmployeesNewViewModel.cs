using GalaSoft.MvvmLight.Messaging;
using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.Models.Validators;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kino.ViewModels
{
    
    public class EmployeesNewViewModel : SingleViewModel<Pracownicy>, IDataErrorInfo
    {
        #region Fields
        private BaseCommand _ShowAddressesCommand;
        #endregion

        #region Construktor
        public EmployeesNewViewModel(int? id = null)
            : base()
        {
            base.DisplayName = "Nowy pracownik";
            base.ViewType = "Empoyees";

            if (id == null)
                this.item = new Pracownicy();
            else
            {
                this.item = kinoEntities.Pracownicy.Find(id);
                this.IdAdresu = this.item.Adresy.IdAdresu;
                this.AdresUlica = this.item.Adresy.Ulica;
                this.AdresNrDomu = this.item.Adresy.NrDomu;
                this.AdresMiejscowosc = this.item.Adresy.Miejscowosc;
                this.AdresKodPocztowy = this.item.Adresy.KodPocztowy;
            }

            Messenger.Default.Register<Adresy>(this, getSelectedAddress);
        }
        #endregion Constructor

        #region Command
        public ICommand ShowAddressesCommand
        {
            get
            {
                if (_ShowAddressesCommand == null)
                    _ShowAddressesCommand = new BaseCommand(() => Messenger.Default.Send("AddressesAll"));

                return _ShowAddressesCommand;
            }
        }
        #endregion

        #region Properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }

        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }

        public string Stanowisko
        {
            get
            {
                return item.Stanowisko;
            }
            set
            {
                if (item.Stanowisko != value)
                {
                    item.Stanowisko = value;
                    OnPropertyChanged(() => Stanowisko);
                }
            }
        }
       
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    OnPropertyChanged(() => Telefon);
                }
            }
        }

        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                if (item.IdAdresu != value)
                {
                    item.IdAdresu = value;
                    OnPropertyChanged(() => IdAdresu);
                }
            }
        }

        private string _AdresUlica;
        public string AdresUlica
        {
            get
            {
                return _AdresUlica;
            }
            set
            {
                if (_AdresUlica != value)
                {
                    _AdresUlica = value;
                    OnPropertyChanged(() => _AdresUlica);
                }
            }
        }

        private string _AdresNrDomu;
        public string AdresNrDomu
        {
            get
            {
                return _AdresNrDomu;
            }
            set
            {
                if (_AdresNrDomu != value)
                {
                    _AdresNrDomu = value;
                    OnPropertyChanged(() => _AdresNrDomu);
                }
            }
        }

        private string _AdresMiejscowosc;
        public string AdresMiejscowosc
        {
            get
            {
                return _AdresMiejscowosc;
            }
            set
            {
                if (_AdresMiejscowosc != value)
                {
                    _AdresMiejscowosc = value;
                    OnPropertyChanged(() => _AdresMiejscowosc);
                }
            }
        }

        private string _AdresKodPocztowy;
        public string AdresKodPocztowy
        {
            get
            {
                return _AdresKodPocztowy;
            }
            set
            {
                if (_AdresKodPocztowy != value)
                {
                    _AdresKodPocztowy = value;
                    OnPropertyChanged(() => _AdresKodPocztowy);
                }
            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            if (this.item.IdPracownika == 0)
                kinoEntities.Pracownicy.Add(item);
            else
            {
                Pracownicy pracownicy = kinoEntities.Pracownicy.Find(this.item.IdPracownika);
                pracownicy = item;
            }

            kinoEntities.SaveChanges();
        }

        private void getSelectedAddress(Adresy adres)
        {
            IdAdresu = adres.IdAdresu;
            AdresUlica = adres.Ulica;
            AdresNrDomu = adres.NrDomu;
            AdresMiejscowosc = adres.Miejscowosc;
            AdresKodPocztowy = adres.KodPocztowy;
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
                if (name == "Imie")
                    komunikat = StringValidator.IsNotEmpty(this.Imie) ?? StringValidator.IsStartFromUpper(this.Imie);
                if (name == "Nazwisko")
                    komunikat = StringValidator.IsNotEmpty(this.Nazwisko) ?? StringValidator.IsStartFromUpper(this.Nazwisko);
                if (name == "Stanowisko")
                    komunikat = StringValidator.IsNotEmpty(this.Stanowisko);
                if (name == "Telefon")
                    komunikat = StringValidator.IsNotEmpty(this.Telefon) ?? BussinesValidator.IsValidPhoneNumber(this.Telefon);
                if (name == "AdresUlica" || name == "AdresKodPocztowy" || name == "AdresMiejscowosc" || name == "AdresNrDomu")
                    komunikat = StringValidator.IsNotEmpty(this.AdresUlica);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Imie"] == null
                && this["Nazwisko"] == null
                && this["Stanowisko"] == null
                && this["Telefon"] == null
                && this["AdresUlica"] == null
                && this["AdresKodPocztowy"] == null
                && this["AdresMiejscowosc"] == null
                && this["AdresNrDomu"] == null;
        }
        #endregion
    }
}

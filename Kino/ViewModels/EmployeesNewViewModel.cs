using GalaSoft.MvvmLight.Messaging;
using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kino.ViewModels
{
    
    public class EmployeesNewViewModel : SingleViewModel<Pracownicy>
    {
        #region Fields
        private BaseCommand _ShowAddressesCommand;
        #endregion

        #region Construktor
        public EmployeesNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy pracownik";
            base.ViewType = "Empoyees";

            this.item = new Pracownicy();
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
            kinoEntities.Pracownicy.Add(item);
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
    }
}

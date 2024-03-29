﻿using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class AddressesB : DatabaseClass
    {
        #region Constructor
        public AddressesB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<Adresy> getAllAddresses()
        {
            return new ObservableCollection<Adresy>
                (
                from adres in kinoEntities.Adresy
                where adres.CzyAktywny == true
                select adres
                );
        }

        public bool removeAddress(int adresId)
        {
            try
            {
                Adresy adresy = kinoEntities.Adresy.Find(adresId);
                adresy.CzyAktywny = false;
                kinoEntities.SaveChanges();
            } catch(Exception)
            {
                return false;
            }

            return true;
        }
    }
}

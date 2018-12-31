﻿using Kino.Models;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class GenreNewView : SingleViewModel<Gatunki>
    {
        #region Construktor
        public GenreNewView()
            : base()
        {
            base.DisplayName = "Nowy gatunek";

            this.item = new Gatunki();
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
    }
}
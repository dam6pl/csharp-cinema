using Kino.Models;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class ShowingTypesNewViewModel : SingleViewModel<TypySeansow>
    {
        #region Construktor
        public ShowingTypesNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy typ seansu";

            this.item = new TypySeansow();
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

        public bool? WymaganeOkulary3D
        {
            get
            {
                return item.WymaganeOkulary3D;
            }
            set
            {
                if (item.WymaganeOkulary3D != value)
                {
                    item.WymaganeOkulary3D = value;
                    OnPropertyChanged(() => WymaganeOkulary3D);
                }
            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.TypySeansow.Add(item);
            kinoEntities.SaveChanges();
        }
        #endregion Helpers
    }
}

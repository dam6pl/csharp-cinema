using Kino.Models;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class RoomsNewViewModel : SingleViewModel<Sale>
    {
        #region Construktor
        public RoomsNewViewModel()
            : base()
        {
            base.DisplayName = "Nowa Sala";

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
    }
}

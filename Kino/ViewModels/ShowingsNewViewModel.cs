using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    
    public class ShowingsNewViewModel : SingleViewModel<Seanse>
    { 
        #region Construktor
        public ShowingsNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy Seans";

            this.item = new Seanse();
        }
        #endregion Constructor

        #region Properties
        public int? IdSali
        {
            get
            {
                return item.IdSali;
            }
            set
            {
                if (item.IdSali != value)
                {
                    item.IdSali = value;
                    OnPropertyChanged(() => IdSali);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> SaleComboboxItems
        {
            get
            {
                return
                    (
                        from sala in kinoEntities.Sale
                        select new ComboboxKeyAndValue
                        {
                            Key = sala.IdSali,
                            Value = sala.Nazwa + " (ID: " + sala.IdSali + ")"
                        }
                    ).ToList().AsQueryable();

            }
        }
        public int? IdFilmu
        {
            get
            {
                return item.IdFilmu;
            }
            set
            {
                if (item.IdFilmu != value)
                {
                    item.IdFilmu = value;
                    OnPropertyChanged(() => IdFilmu);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> FilmyComboboxItems
        {
            get
            {
                return
                    (
                        from film in kinoEntities.Filmy
                        select new ComboboxKeyAndValue
                        {
                            Key = film.IdFilmu,
                            Value = film.Tytuł
                        }
                    ).ToList().AsQueryable();

            }
        }
        public DateTime? Data
        {
            get
            {
                return item.Data;
            }
            set
            {
                if (item.Data != value)
                {
                    item.Data = value;
                    OnPropertyChanged(() => Data);
                }
            }
        }
        public int? IdTypuSeansu
        {
            get
            {
                return item.IdTypuSeansu;
            }
            set
            {
                if (item.IdTypuSeansu != value)
                {
                    item.IdTypuSeansu = value;
                    OnPropertyChanged(() => IdTypuSeansu);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> TypySeansowComboboxItems
        {
            get
            {
                return
                    (
                        from typSeansu in kinoEntities.TypySeansow
                        select new ComboboxKeyAndValue
                        {
                            Key = typSeansu.IdTypuSeansu,
                            Value = typSeansu.Nazwa
                        }
                    ).ToList().AsQueryable();

            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Seanse.Add(item);
            kinoEntities.SaveChanges();
        }
        #endregion Helpers
    }
}

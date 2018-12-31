using Kino.Models;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class RoomsAllViewModel : AllViewModel<Sale>
    {
        #region Constructor
        public RoomsAllViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie sale";
        }
        #endregion Constructor

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Sale>
                (
                from sala in kinoEntities.Sale
                select sala
                );
        }
        #endregion Helpers
    }
}

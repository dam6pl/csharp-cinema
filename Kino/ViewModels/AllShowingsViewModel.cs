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
    class AllShowingsViewModel : AllViewModel<Seanse>
    {
        #region Constructor
        public AllShowingsViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie seanse";
        }
        #endregion Constructor

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Seanse>
                (
                from seans in kinoEntities.Seanse
                select seans
                );
        }
        #endregion Helpers
    }
}

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
    class FilmsAllViewModel : AllViewModel<Filmy>
    {
        #region Constructor
        public FilmsAllViewModel()
            : base()
        {
            base.DisplayName = "Filmy";
        }
        #endregion Constructor

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Filmy>
                (
                from film in kinoEntities.Filmy
                select film
                );
        }
        #endregion Helpers
    }
}

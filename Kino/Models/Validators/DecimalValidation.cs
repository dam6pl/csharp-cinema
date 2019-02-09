using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.Validators
{
    class DecimalValidation
    {
        public static string IsNotEmpty(decimal? value)
        {
            if (value == null)
                return "Pole musi zostać uzupełnione!";

            return null;
        }

        public static string IsPositive(decimal? value)
        {
            if (value <= 0)
                return "Pole musi być większe od 0!";

            return null;
        }
    }
}

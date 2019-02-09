using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.Validators
{
    class IntegerValidation
    {
        public static string IsNotEmpty(int? value)
        {
            if (value == null)
                return "Pole musi zostać uzupełnione!";

            return null;
        }

        public static string IsPositive(int? value)
        {
            if (value <= 0)
                return "Pole musi być większe od 0!";

            return null;
        }

        public static string IsYearInPast(int? value)
        {
            if (value < 0 || value > DateTime.Now.Year)
                return "Pole musi być rokiem z przeszłości!";

            return null;
        }
    }
}

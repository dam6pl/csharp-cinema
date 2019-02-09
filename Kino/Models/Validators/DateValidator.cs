using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.Validators
{
    class DateValidator : Validator
    {
        public static string IsNotEmpty(DateTime? date)
        {
            if (date == null)
                return "Data musi zostać wybrana!";

            return null;
        }

        public static string IsInPast(DateTime? date)
        {
            if (date < DateTime.Now)
                return "Data musi być z przyszłości!";

            return null;
        }
    }
}

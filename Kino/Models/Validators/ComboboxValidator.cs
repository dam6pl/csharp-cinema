using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.Validators
{
    class ComboboxValidator
    {
        public static string IsNotEmpty(int? value)
        {
            if (value == null)
                return "Pole musi zostać wybrane!";

            return null;
        }
    }
}

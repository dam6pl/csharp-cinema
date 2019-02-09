using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.Validators
{
    class StringValidator: Validator
    {
        public static string IsNotEmpty(string value)
        {
            if (value == null || value == "")
                return "Pole musi zostać uzuepłnione!";

            return null;
        }

        public static string IsStartFromUpper(string value)
        {
            try
            {
                if (!char.IsUpper(value, 0))
                    return "Pole musi zaczynać się od dużej litery!";
            }
            catch (Exception) { }

            return null;
        }
    }
}

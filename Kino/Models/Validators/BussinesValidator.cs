using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kino.Models.Validators
{
    class BussinesValidator
    {
        public static string IsValidEmail(string value)
        {
            if (!(new EmailAddressAttribute()).IsValid(value))
                return "Pole musi być poprawnym adresem email!";

            return null;
        }

        public static string IsValidPhoneNumber(string value)
        {
            if (!Regex.Match(value, @"^([0-9]{9})$").Success)
                return "Pole musi być poprawnym numerem telefonu!";

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validators
{
    class StringValidator : Validator
    {

        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))
                    return "Rozpocznij dużą literą!";
            }
            catch (Exception)
            {}
            
            return null;
        }
    }
}

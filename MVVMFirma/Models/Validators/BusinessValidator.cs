using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validators
{
    public class BusinessValidator: Validator
    {
        #region Business function
        public static string SprawdzVat(int? vat)
        {
            if (vat < 0 || vat > 100)
                return "VAT powinien byc z przedzialu od 0 do 100";

            return null;
        }
        #endregion
    }
}

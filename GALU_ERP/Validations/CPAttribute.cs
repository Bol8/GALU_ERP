using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GALU_ERP.Validations
{
    public class CPAttribute:ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var CP = Convert.ToString(value);

            if (String.IsNullOrEmpty(CP))
            {
                return true;
            }

            if (!Regex.IsMatch(value.ToString(), "^(([0-9]{5}))$"))
            {
                return false;
            }

            return true;
        }



    }
}
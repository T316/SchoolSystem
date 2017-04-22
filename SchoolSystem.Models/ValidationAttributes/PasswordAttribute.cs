using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = (String)value;

            Regex regex = new Regex("[A-Z]");
            if (!regex.IsMatch(password))
            {
                return false;
            }

            regex = new Regex("[a-z]");
            if (!regex.IsMatch(password))
            {
                return false;
            }

            regex = new Regex("\\d");
            if (!regex.IsMatch(password))
            {
                return false;
            }

            return true;
        }
    }
}

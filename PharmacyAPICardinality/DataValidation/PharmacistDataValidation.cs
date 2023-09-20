
using System.Text.RegularExpressions;

namespace PharmacyAPICardinality.DataValidation
{
    public static class PharmacistDataValidation
    {
        public static string ValidatePharmacistData(string FirstName, string LastName)
        {
            string ErrorMessage = string.Empty;
            if (FirstName.Length == 0)
            {
                ErrorMessage = "Please enter First Name.";
            }
            else if (!Regex.IsMatch(FirstName, @"^[a-zA-Z]+$"))
            {
                ErrorMessage = "First Name must consist of letters only. Invalid input: " + FirstName;
            }
            if (LastName.Length == 0)
            {
                ErrorMessage += "\nPlease enter Last Name.";
            }
            else if (!Regex.IsMatch(LastName, @"^[a-zA-Z]+$"))
            {
                ErrorMessage += "\nLast Name must consist of letters only. Invalid input: " + LastName;
            }
            return ErrorMessage;
        }
        
    }
}

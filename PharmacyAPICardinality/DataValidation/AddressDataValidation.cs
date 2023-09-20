using System.Text.RegularExpressions;

namespace PharmacyAPICardinality.DataValidation
{
    public static class AddressDataValidation
    {
        public static string ValidateAddressData(
            string Street,
            string City,
            string State,
            string Zip)
        {
            string ErrorMessage = string.Empty;
            if (Street.Length == 0)
            {
                ErrorMessage = "Please enter Street Address.";
            }
            else if (!Regex.IsMatch(Street, @"\d{1,5}([0-9]{1,2}[a-z]{2})?[A-Za-z\s]{1,}"))
            {
                ErrorMessage = "Please enter valid street address. Invalid input: " + Street;
            }
            if (City.Length == 0)
            {
                ErrorMessage += "\nPlease enter City.";
            }
            else if (!Regex.IsMatch(City, @"^[A-Za-z',.\s-]{1,25}$"))
            {
                ErrorMessage += "\nPlease enter city. Invalid input: " + City;
            }
            if (State.Length == 0)
            {
                ErrorMessage += "\nPlease enter State.";
            }
            else if (!Regex.IsMatch(State, @"^[A-Z]{2}$"))
            {
                ErrorMessage += "\nPlease enter 2 letter state abbreviation. Invalid input: " + State;
            }
            if (Zip.Length == 0)
            {
                ErrorMessage += "\nPlease enter Zip code.";
            }
            else if (!Regex.IsMatch(Zip, @"^[0-9]{5}(?:-[0-9]{4})?$"))
            {
                ErrorMessage += "\nPlease enter valid Zip code. Invalid input: " + Zip;
            }
            return ErrorMessage;
        }
    }
}

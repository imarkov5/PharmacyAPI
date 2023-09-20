
namespace PharmacyAPICardinality.DataValidation
{
    public static class PharmacyDataValidation
    {
        public static string ValidatePharmacyData(string Name)
        {
            string ErrorMessage = string.Empty;
            if (Name.Length == 0)
            {
                ErrorMessage = "Please enter Pharmacy Name.\n";
            }
            return ErrorMessage;
        }
    }
}

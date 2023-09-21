using System.Text.RegularExpressions;

namespace PharmacyAPICardinality.DataValidation
{
    public static class PrescriptionDataValidation
    {
        public static string ValidateAddPrescriptionData(
            string PatientName,
            string DrugName,
            string DrugStrength,
            string Dosage,
            string Quantity,
            int IsDispensed)
        {
            string ErrorMessage = string.Empty;
            if (PatientName.Length == 0)
            {
                ErrorMessage = "Please enter Patient's Name.";
            }
            else if (!Regex.IsMatch(PatientName, @"^[A-Z][a-z]+\s[A-Z][a-z]+$"))
            {
                ErrorMessage = "Patient's Name must consist of letters only. First Name followed by Last Name with single space in between. Invalid input: " + PatientName;
            }
            if (DrugName.Length == 0 || 
                DrugStrength.Length == 0 || 
                Dosage.Length == 0 ||
                Quantity.Length == 0)
            {
                ErrorMessage += "\nAll fields must be filled.";
            }
            if (IsDispensed > 1 || IsDispensed < 0)
            {
                ErrorMessage += "\nPlease enter 0 if not dispensed, 1 - if dispensed.";
            }
            return ErrorMessage;
        }
        public static string ValidateUpdatePrescriptionData(int IsDispensed)
        {
            string ErrorMessage = string.Empty;
            if (IsDispensed > 1 || IsDispensed < 0)
            {
                ErrorMessage += "\nPlease enter 0 if not dispensed, 1 - if dispensed.";
            }
            return ErrorMessage;
        }
    }
}

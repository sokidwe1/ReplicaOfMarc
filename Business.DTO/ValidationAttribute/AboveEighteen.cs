using System.ComponentModel.DataAnnotations;

namespace Business.DTO.ValidationAttribute
{
    public class AboveEighteen : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult(ErrorMessage ?? "Date is required"); ;
            DateTimeOffset dt = (DateTimeOffset)value;
            var compareTo = new DateTimeOffset(DateTimeOffset.Now.Year - 18, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, 0, 0, 0, TimeSpan.Zero);
            if (dt.CompareTo(compareTo) < 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "You are not 18");
        }
    }
}

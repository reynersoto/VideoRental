using System.ComponentModel.DataAnnotations;
using WebMvcPruebaMosh.DTOs;

namespace WebMvcPruebaMosh.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypesId == MembershipTypes.Uknown || 
                customer.MembershipTypesId == MembershipTypes.PayAsYouGo) 
            {
                return ValidationResult.Success;
            }
            if(customer.Birthday == null)
            {  return new ValidationResult("Birthday is required"); }

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18) ? 
                ValidationResult.Success : 
                new ValidationResult("Customer should be at least 18 years old");
        }
    }
}

using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.UserId).NotNull();
            RuleFor(customer => customer.CompanyName).NotEmpty();
            RuleFor(customer => customer.CompanyName).Must(NotContainNumbers).WithMessage("Şirket ismi numara içeremez.");
        }
        private bool NotContainNumbers(string input)
        {
            return !input.Any(char.IsDigit);
        }
    }
}

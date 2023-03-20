using EntityFrameworkExample.Data.Entities;
using FluentValidation;

namespace EntityFrameworkExample.Service
{
    public class UserValidator : AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(x => x.USER_NAME).NotEmpty().WithMessage("Kullanıcı Adını boş geçemezsiniz!");
        }
    }
}

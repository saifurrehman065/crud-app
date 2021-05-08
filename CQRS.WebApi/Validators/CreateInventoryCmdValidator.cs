using MyCrudAppAspDotNetCore.WebApi.Application.Features.InventoryFeatures.Commands;
using FluentValidation;

namespace MyCrudAppAspDotNetCore.WebApi.Validators
{
    public class CreateInventoryCmdValidator : AbstractValidator<CreateInventoryCmd>
    {
        public CreateInventoryCmdValidator()
        {
            RuleFor(c => c.Name)
                    .NotEmpty();

            RuleFor(c => c.Price)
                    .NotEmpty();

        }
    }
}

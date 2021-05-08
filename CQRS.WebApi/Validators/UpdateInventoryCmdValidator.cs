using FluentValidation;
using MyCrudAppAspDotNetCore.WebApi.Features.InventoryFeatures.Commands;

namespace MyCrudAppAspDotNetCore.WebApi.Validators
{
    public class UpdateInventoryCmdValidator : AbstractValidator<UpdateInventoryCmd>
    {
        public UpdateInventoryCmdValidator()
        {
            RuleFor(c => c.Name)
                    .NotEmpty();

            RuleFor(c => c.Price)
                    .NotEmpty();

        }
    }
}

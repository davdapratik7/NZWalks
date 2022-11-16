using FluentValidation;

namespace NZWalks.API.Validators
{
    public class UpdateWalkDifficultyValidator : AbstractValidator<Models.DTO.UpdateWalkDifficulty>
    {
        public UpdateWalkDifficultyValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}

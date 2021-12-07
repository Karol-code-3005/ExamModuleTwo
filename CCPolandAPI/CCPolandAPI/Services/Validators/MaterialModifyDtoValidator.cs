using CCPolandAPI.Models.DTOS.Material;
using CCPolandAPI.Models.EntityModels;
using FluentValidation;
using System;

namespace CCPolandAPI.Services.Validators
{
    public class MaterialModifyDtoValidator : AbstractValidator<MaterialModifyDto>
    {
        [System.Obsolete]
        public MaterialModifyDtoValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("{PropertyName} cant be empty.")
                .Length(2, 50).WithMessage("{PropertyName} length must fit in range {MinLength} - {MaxLength} characters.");

            RuleFor(m => m.MaterialDescription)
                .NotEmpty().WithMessage("{PropertyName} cant be empty.")
                .Length(2, 300).WithMessage("{PropertyName} length must fit in range {MinLength} - {MaxLength} characters.");

            RuleFor(m => m.Location)
                .NotEmpty().WithMessage("{PropertyName} cant be empty.")
                .Length(10, 100).WithMessage("{PropertyName} length must fit in range {MinLength} - {MaxLength} characters.");

            RuleFor(m => m.DateOfPublishing)
                .Must(BeAValideDate).WithMessage("Invalid {PropertyName}");
        }

        private bool BeAValideDate(DateTime publishingDate)
        {
            DateTime currentDate = DateTime.Now.Date;

            if(currentDate <= publishingDate)
            {
                return false;
            }

            return true;
        }
    }
}

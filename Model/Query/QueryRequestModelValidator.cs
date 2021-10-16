using FluentValidation;

namespace EarthQuake.Model
{
    public class
    QueryRequestModelValidator
    : AbstractValidator<QueryRequestModel>
    {
        public QueryRequestModelValidator()
        {
            Latitude();
            Longitude();
            StartDate();
            EndDate();
        }

        public void Latitude() =>
            RuleFor(query => query.Latitude)
                .NotEmpty()
                .WithMessage("Latitude is required")
                .Must(x => double.TryParse(x, out var val))
                .WithMessage("Invalid Latitude.");

        public void Longitude() =>
            RuleFor(query => query.Longitude)
                .NotEmpty()
                .WithMessage("Longitude is required")
                .Must(x => double.TryParse(x, out var val))
                .WithMessage("Invalid Longitude.");

        public void StartDate() =>
            RuleFor(query => query.StartDate)
                .NotEmpty()
                .WithMessage("Start Date is required");

        public void EndDate() =>
            RuleFor(query => query.EndDate)
                .NotEmpty()
                .WithMessage("End Date is required");
    }
}

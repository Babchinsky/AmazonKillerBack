using FluentValidation;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Common;

public abstract class UpsertCollectionValidator<T> : AbstractValidator<T>
    where T : UpsertCollectionModel
{
    protected UpsertCollectionValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(120);

        RuleForEach(x => x.ParsedFilters).ChildRules(filter =>
        {
            filter.RuleFor(f => f.Key)
                .NotEmpty()
                .MaximumLength(30);

            filter.RuleFor(f => f.Value)
                .NotEmpty()
                .MaximumLength(30);
        });
    }
}
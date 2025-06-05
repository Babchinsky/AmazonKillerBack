using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Admin.Commands.DeleteReviewByAdmin;

public record DeleteReviewByAdminCommand(Guid Id) : IRequest<bool>;
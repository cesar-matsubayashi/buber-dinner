using BuberDinner.Domain.Dinner;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Queries.ListDinner
{
    public record ListDinnersQuery : IRequest<ErrorOr<List<Dinner>>>;
}

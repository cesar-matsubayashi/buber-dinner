using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Queries.GetDinner
{
    public record GetDinnerQuery(DinnerId Id) : IRequest<ErrorOr<Dinner>>;
}

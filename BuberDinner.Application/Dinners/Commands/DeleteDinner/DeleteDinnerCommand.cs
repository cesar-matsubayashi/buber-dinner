using BuberDinner.Domain.Dinner.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.DeleteDinner
{
    public record DeleteDinnerCommand(DinnerId Id) : IRequest<ErrorOr<Deleted>>;
}

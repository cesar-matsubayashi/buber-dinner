using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Guest.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.UnitTests.Bills.Queries.GetBillsByGuestId
{
    public record ListBillsByGuestIdQuery(GuestId GuestId) 
        : IRequest<ErrorOr<List<Bill>>>;
}

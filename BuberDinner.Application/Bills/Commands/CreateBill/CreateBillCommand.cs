using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Commands.CreateBill
{
    public record CreateBillCommand(
        GuestId GuestId,
        DinnerId DinnerId,
        HostId HostId,
        CreatePriceCommand Price) : IRequest<ErrorOr<Bill>>;

    public record CreatePriceCommand(
        decimal Amount,
        string Currency);
}

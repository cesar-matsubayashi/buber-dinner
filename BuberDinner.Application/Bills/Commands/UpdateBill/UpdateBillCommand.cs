using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Commands.UpdateBill
{
    public record UpdateBillCommand(
        BillId Id,
        UpdatePriceCommand Price) : IRequest<ErrorOr<Bill>>;

    public record UpdatePriceCommand(
        decimal Amount,
        string Currency);
}

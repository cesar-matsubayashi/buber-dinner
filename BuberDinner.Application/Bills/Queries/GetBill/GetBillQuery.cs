using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Queries.GetBill
{
    public record GetBillQuery(BillId Id) : IRequest<ErrorOr<Bill>>;
}

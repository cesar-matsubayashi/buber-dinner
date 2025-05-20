using BuberDinner.Domain.Bill.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Commands.DeleteBill
{
    public record DeleteBillCommand(BillId Id) : IRequest<ErrorOr<Deleted>>;
}

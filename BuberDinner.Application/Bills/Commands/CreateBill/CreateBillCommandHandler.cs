using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Common.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Commands.CreateBill
{
    public class CreateBillCommandHandler
        : IRequestHandler<CreateBillCommand, ErrorOr<Bill>>
    {
        private readonly IBillRepository _billRepository;

        public CreateBillCommandHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<ErrorOr<Bill>> Handle(
            CreateBillCommand request, 
            CancellationToken cancellationToken)
        {
            var price = Price.Create(
                request.Price.Amount,
                request.Price.Currency);

            var bill = Bill.Create(
                request.DinnerId,
                request.GuestId,
                request.HostId,
                price);

            await _billRepository.AddAsync(bill);

            return bill;
        }
    }
}

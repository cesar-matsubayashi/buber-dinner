using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Common.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Commands.UpdateBill
{
    public class UpdateBillCommandHandler
        : IRequestHandler<UpdateBillCommand, ErrorOr<Bill>>
    {
        private readonly IBillRepository _billRepository;

        public UpdateBillCommandHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<ErrorOr<Bill>> Handle(
            UpdateBillCommand request, 
            CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetAsync(request.Id);

            if (bill is null)
            {
                return Errors.Bill.NotFound;
            }

            var price = Price.Create(
                request.Price.Amount,
                request.Price.Currency);

            bill.Update(price);

            await _billRepository.UpdateAsync(bill);

            return bill;
        }
    }
}

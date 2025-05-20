using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Commands.DeleteBill
{
    public class DeleteBillCommandHandler
        : IRequestHandler<DeleteBillCommand, ErrorOr<Deleted>>
    {
        private readonly IBillRepository _billRepository;

        public DeleteBillCommandHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteBillCommand request, 
            CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetAsync(request.Id);

            if (bill is null)
            {
                return Errors.Bill.NotFound;
            }

            await _billRepository.DeleteAsync(bill);

            return new Deleted();
        }
    }
}

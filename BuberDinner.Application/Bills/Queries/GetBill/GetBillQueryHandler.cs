using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Bills.Queries.GetBill
{
    public class GetBillQueryHandler
        : IRequestHandler<GetBillQuery, ErrorOr<Bill>>
    {
        private readonly IBillRepository _billRepository;

        public GetBillQueryHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<ErrorOr<Bill>> Handle(
            GetBillQuery request, 
            CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetAsync(request.Id);

            if (bill is null)
            {
                return Errors.Bill.NotFound;
            }

            return bill;
        }
    }
}

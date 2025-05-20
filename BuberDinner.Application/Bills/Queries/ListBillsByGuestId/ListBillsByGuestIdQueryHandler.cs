using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.UnitTests.Bills.Queries.GetBillsByGuestId;
using BuberDinner.Domain.Bill;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.UnitTests.Bills.Queries.ListBillsByGuestId
{
    public class ListBillsByGuestIdQueryHandler
        : IRequestHandler<ListBillsByGuestIdQuery, ErrorOr<List<Bill>>>
    {
        private readonly IBillRepository _billRepository;

        public ListBillsByGuestIdQueryHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<ErrorOr<List<Bill>>> Handle(
            ListBillsByGuestIdQuery request, 
            CancellationToken cancellationToken)
        {
            var bills = await _billRepository.GetAllByGuestIdAsync(request.GuestId);

            return bills;
        }
    }
}

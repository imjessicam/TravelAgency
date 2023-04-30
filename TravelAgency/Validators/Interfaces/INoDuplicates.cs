using DTO.Models.Cruise;
using DTO.Models.Customer;
using DTO.Models.Fleet;
using DTO.Models.Skipper;
using DTO.Models.Crew;
using DTO.Models.Offer;
using DTO.Models.Order;

namespace TravelAgency.Validators.Interfaces
{
    public interface INoDuplicates
    {
        // Customer
        bool IsValid(CreateCustomerModel customer);
        bool IsValid(UpdateCustomerModel customer);

        // Fleet
        bool IsValid(CreateFleetModel customer);
        bool IsValid(UpdateFleetModel customer);

        // Skipper
        bool IsValid(CreateSkipperModel skipper);
        bool IsValid(UpdateSkipperModel skipper);

        // Cruise
        bool IsValid(CreateCruiseModel skipper);
        bool IsValid(UpdateCruiseModel skipper);

        // Crew
        bool IsValid(CreateCrewModel crew);
        bool IsValid(UpdateCrewModel crew);

        // Offer
        bool IsValid(CreateOfferModel crew);
        bool IsValid(UpdateOfferModel crew);

        // Order
        bool IsValid(CreateOrderModel crew);
        bool IsValid(UpdateOrderModel crew);

    }
}

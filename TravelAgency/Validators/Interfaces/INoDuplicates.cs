using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_1.Skipper;
using DTO.Models.Group_2.Crew;
using DTO.Models.Group_2.Offer;
using DTO.Models.Group_2.OfferCustomer;
using DTO.Models.Group_2.Order;

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

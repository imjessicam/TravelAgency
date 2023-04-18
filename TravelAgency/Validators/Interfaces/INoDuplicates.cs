using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_1.Skipper;
using DTO.Models.Group_2.Crew;

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

        //// Crew
        //bool IsValid(CreateCrewModel crew);
        //bool IsValid(UpdateCrewModel crew);


    }
}

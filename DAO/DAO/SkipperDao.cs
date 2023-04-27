using AutoMapper;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Skipper;
using TravelAgency.Models;
using TravelAgency.Repositories;
using TravelAgency.Validators.Interfaces;

namespace DAO.Group_1
{
    public class SkipperDao
    {
        private readonly SkipperRepository _skipperRepository;
        private readonly IMapper _mapper;

        // Validators
        private readonly ISkipperExist _skipperExist;
        private readonly INoDuplicates _skipperNoDuplicates;

        // Constructor
        public SkipperDao(SkipperRepository skipperRepository, IMapper mapper, ISkipperExist skipperExist, INoDuplicates skipperNoDuplicates)
        {
            _skipperRepository = skipperRepository;
            _mapper = mapper;

            // Validators
            _skipperExist = skipperExist;
            _skipperNoDuplicates = skipperNoDuplicates;
        }

        // Post
        public Guid Create(CreateSkipperModel skipper)
        {
            // Mapping
            var newSkipper = _mapper.Map<Skipper>(skipper);

            // Check if item already exists
            var noDuplicates = _skipperNoDuplicates.IsValid(skipper);
            if (!noDuplicates)
            {
                throw new ArgumentOutOfRangeException("The skipper already exists, please enter valid data.", innerException: null);
            }
            return _skipperRepository.Create(newSkipper);
        }

        // Get
        public SkipperDetails Find(Guid externalId)
        {
            // Find item                       
            var foundSkipper = _skipperRepository.Find(externalId);

            // Check if item exists
            var isExist = _skipperExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The skipper does not exist, please create.", innerException: null);
            }

            return _mapper.Map<SkipperDetails>(foundSkipper);
        }

        public IReadOnlyList<SkipperDetails> GetAll()
        {
            var skippers = _skipperRepository.GetAll();

            return _mapper.Map<IReadOnlyList<SkipperDetails>>(skippers);
        }

        // Put
        public Guid Update(UpdateSkipperModel skipperToUpdate)
        {
            // Mapping
            var skipper = _mapper.Map<Skipper>(skipperToUpdate);

            // Check if item exists
            var isExist = _skipperExist.IsExist(skipperToUpdate.ExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The customer does not exist, please create.", innerException: null);
            }

            return _skipperRepository.Update(skipper);
        }

        // Delete
        public void Delete(Guid externalId)
        {
            // Find item
            var skipperToDelete = _skipperRepository.Find(externalId);

            // Check if item exists
            var isExist = _skipperExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The customer you want to remove does not exist.", innerException: null);
            }

            _skipperRepository.Delete(skipperToDelete.ExternalId);
        }
    }
}

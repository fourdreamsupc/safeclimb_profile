using AutoMapper;
using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Agencies.Domain.Repositories;
using Go2Climb.API.Agencies.Domain.Services;
using Go2Climb.API.Agencies.Domain.Services.Communication;
using Go2Climb.API.Resources;
using Go2Climb.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Go2Climb.API.Agencies.Services
{
    public class AgencyService
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgencyService(IAgencyRepository agencyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _agencyRepository = agencyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Agency>> ListAsync()
        {
            return await _agencyRepository.ListAsync();
        }
        
        public async Task<IEnumerable<Agency>> ListByName(string name)
        {
            return await _agencyRepository.ListByName(name);
        }
        
        public async Task<Agency> GetByIdAsync(int id)
        {
            var agency = await _agencyRepository.FindByIdAsync(id);
            if (agency == null) throw new KeyNotFoundException("Agency not found.");
            return agency;
        }
        
        public async Task<AgencyResponse> FindById(int id)
        {
            var existingAgency = await _agencyRepository.FindByIdAsync(id);

            if (existingAgency == null)
                return new AgencyResponse("Agency not found.");

            return new AgencyResponse(existingAgency);
        }

        //Helper method
        private Agency GetById(int id)
        {
            var agency = _agencyRepository.FindById(id);
            if (agency == null) throw new KeyNotFoundException("Agency not found.");
            return agency;
        }
    }
}
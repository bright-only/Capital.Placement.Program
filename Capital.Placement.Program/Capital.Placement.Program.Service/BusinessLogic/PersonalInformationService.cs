using AutoMapper;

using Capital.Placement.Program.Data.DTOs;
using Capital.Placement.Program.Data.Helper;
using Capital.Placement.Program.Data.Model;
using Capital.Placement.Program.Data.Repositories;

namespace Capital.Placement.Program.Service.BusinessLogic
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly IGenericRepository<PersonalInformation> _personalInformationRepository;
        private readonly IMapper _mapper;

        public PersonalInformationService( IGenericRepository<PersonalInformation> personalInformationRepository, IMapper mapper )
        {
            _personalInformationRepository = personalInformationRepository ?? throw new ArgumentNullException(nameof(personalInformationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PersonalInformationDTO> AddPersonalInformationAsync( AddPersonalInformationRequestDTO request )
        {
            var personalInformation = new PersonalInformation
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                CurrentResidence = request.CurrentResidence,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Gender = request.Gender,
                IdNumber = request.IdNumber,
                Nationality = request.Nationality,
                QuestionType = request.QuestionType.ToString(),
                CustomQuestions = HelperService.MapCustomQuestions(request.CustomQuestions, request)
            };
            var detail = _mapper.Map<PersonalInformation>(personalInformation);
            await _personalInformationRepository.AddAsync(detail);
            return _mapper.Map<PersonalInformationDTO>(detail);
        }

        public async Task<IEnumerable<PersonalInformationDTO>> GetAllPersonalInformationsAsync()
        {
            var details = await _personalInformationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonalInformationDTO>>(details);
        }

        public async Task<PersonalInformationDTO> GetPersonalInformationByIdAsync( Guid id )
        {
            var detail = await _personalInformationRepository.GetByIdAsync(id);
            return _mapper.Map<PersonalInformationDTO>(detail);
        }

        public async Task<PersonalInformationDTO> UpdatePersonalInformationAsync( Guid id, UpdatePersonalInformationRequestDTO request )
        {
            var existingDetail = await _personalInformationRepository.GetByIdAsync(id);
            if (existingDetail == null)
            {
                return null;
            }
            var detail = new UpdatePersonalInformationRequestDTO()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Nationality = request.Nationality,
                QuestionType = request.QuestionType,
                CustomQuestions = HelperService.MapCustomQuestions(request.CustomQuestions, request)
            };
            _mapper.Map(detail, existingDetail);
            await _personalInformationRepository.UpdateAsync(existingDetail);
            return _mapper.Map<PersonalInformationDTO>(existingDetail);
        }

        public async Task<bool> DeletePersonalInformationAsync( Guid id )
        {
            var detail = await _personalInformationRepository.GetByIdAsync(id);
            if (detail == null)
            {
                return false;
            }

            await _personalInformationRepository.DeleteAsync(detail);
            return true;
        }

        public async Task<IEnumerable<PersonalInformationDTO>> GetPaginatedAsync( int pageNumber, int pageSize )
        {
            //ensuring that the pagesize does not excess 5
            pageNumber = Math.Min(pageNumber, 2);
            pageSize = Math.Min(pageSize, 10);
            var filteredResult = await _personalInformationRepository.GetPaginatedAsync(pageNumber, pageSize);
            if (filteredResult.Count() > 0)
                return _mapper.Map<IEnumerable<PersonalInformationDTO>>(filteredResult);
            return null;
        }
    }
}

using Capital.Placement.Program.Data.DTOs;

namespace Capital.Placement.Program.Service.BusinessLogic
{
    public interface IPersonalInformationService
    {
        Task<IEnumerable<PersonalInformationDTO>> GetAllPersonalInformationsAsync();
        Task<PersonalInformationDTO> GetPersonalInformationByIdAsync( Guid id );
        Task<PersonalInformationDTO> AddPersonalInformationAsync( AddPersonalInformationRequestDTO request );
        Task<PersonalInformationDTO> UpdatePersonalInformationAsync( Guid id, UpdatePersonalInformationRequestDTO request );
        Task<bool> DeletePersonalInformationAsync( Guid id );
        Task<IEnumerable<PersonalInformationDTO>> GetPaginatedAsync( int pageNumber, int pageSize );
    }
}

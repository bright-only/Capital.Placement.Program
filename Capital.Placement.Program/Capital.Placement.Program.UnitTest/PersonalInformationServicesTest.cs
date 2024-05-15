using AutoMapper;
using Capital.Placement.Program.Data.DTOs;
using Capital.Placement.Program.Data.Helper;
using Capital.Placement.Program.Data.Model;
using Capital.Placement.Program.Data.Repositories;
using Capital.Placement.Program.Service.BusinessLogic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Placement.Program.UnitTest
{
    public class PersonalInformationServicesTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IGenericRepository<PersonalInformation>> _PersonalInformationMock;
        private PersonalInformationService _personalInformationService;
        private readonly Guid _id = Guid.NewGuid();
        public PersonalInformationServicesTest()
        {
            _mapperMock = new Mock<IMapper>();
            _PersonalInformationMock = new Mock<IGenericRepository<PersonalInformation>>();
            _personalInformationService = new PersonalInformationService(_PersonalInformationMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task AddInformationAsync_ShouldReturnMappedDTO()
        {
            // Arrange
            var requestDto = new AddPersonalInformationRequestDTO
            {
                FirstName = "John",
                LastName = "Doe",
                // Populate other properties as needed
            };

            var personalInformation = new PersonalInformation
            {
                Id = _id,
                // Populate other properties based on requestDto
            };

            var mappedDto = new PersonalInformationDTO
            {
                // Populate with expected mapped DTO based on personalInformation
            };

            // Mocking repository to return a completed task when adding personal information
            _PersonalInformationMock
                .Setup(repo => repo.AddAsync(It.IsAny<PersonalInformation>()))
                .Returns(Task.CompletedTask);

            // Mocking mapper to return the mapped DTO
            _mapperMock
                .Setup(mapper => mapper.Map<PersonalInformation>(It.IsAny<PersonalInformation>()))
                .Returns(personalInformation);

            _mapperMock
                .Setup(mapper => mapper.Map<PersonalInformationDTO>(personalInformation))
                .Returns(mappedDto);

            // Act
            var result = await _personalInformationService.AddPersonalInformationAsync(requestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mappedDto, result);
        }

        [Fact]
        public async Task GetAllInformationsAsync_ShouldReturnMappedDTOs()
        {
            // Arrange
            var mockPersonalInformations = new List<PersonalInformation>
            {
                // Populate with mock data
                new PersonalInformation { Id = _id, FirstName = "John", LastName = "Doe" },
                new PersonalInformation { Id = _id, FirstName = "Jane", LastName = "Smith" }
            };

            // Mocking repository to return the list of personal informations
            _PersonalInformationMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockPersonalInformations);

            var expectedMappedDtoList = new List<PersonalInformationDTO>
            {
                // Populate with expected mapped DTOs based on mock data
                new PersonalInformationDTO { Id = _id, FirstName = "John", LastName = "Doe" },
                new PersonalInformationDTO { Id = _id, FirstName = "Jane", LastName = "Smith" }
            };

            // Mocking mapper to return the list of mapped DTOs
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<PersonalInformationDTO>>(mockPersonalInformations))
                .Returns(expectedMappedDtoList);

            // Act
            var result = await _personalInformationService.GetAllPersonalInformationsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMappedDtoList, result);
        }

        [Fact]
        public async Task GetInformationByIdAsync_ShouldReturnMappedDTO()
        {
            // Arrange

            var id = _id;
            var mockPersonalInformation = new PersonalInformation
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                // Populate other properties as needed
            };

            // Mocking repository to return the mock personal information
            _PersonalInformationMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(mockPersonalInformation);

            var expectedMappedDto = new PersonalInformationDTO
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                // Populate other properties as needed
            };

            // Mocking mapper to return the mapped DTO
            _mapperMock.Setup(mapper => mapper.Map<PersonalInformationDTO>(mockPersonalInformation))
                .Returns(expectedMappedDto);

            // Act
            var result = await _personalInformationService.GetPersonalInformationByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMappedDto, result);
        }

        [Fact]
        public async Task UpdateInformationAsync_ShouldReturnMappedDTO()
        {
            // Arrange
            var id = _id;
            var requestDto = new UpdatePersonalInformationRequestDTO
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                // Populate other properties as needed
            };

            var existingPersonalInformation = new PersonalInformation
            {
                Id = id,
                // Populate other properties
            };

            // Mocking repository to return the existing personal information
            _PersonalInformationMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(existingPersonalInformation);

            var mappedDto = new PersonalInformationDTO
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                // Populate other properties as needed
            };

            // Mocking mapper to return the mapped DTO
            _mapperMock.Setup(mapper => mapper.Map(requestDto, existingPersonalInformation)).Returns(existingPersonalInformation);
            _mapperMock.Setup(mapper => mapper.Map<PersonalInformationDTO>(existingPersonalInformation)).Returns(mappedDto);

            // Act
            var result = await _personalInformationService.UpdatePersonalInformationAsync(id, requestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mappedDto, result);
        }

        [Fact]
        public async Task UpdateInformationAsync_ShouldReturnNull_WhenExistingDetailIsNull()
        {
            // Arrange
            var id = _id;

            // Mocking repository to return null for the existing personal information
            _PersonalInformationMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync((PersonalInformation)null);

            // Act
            var result = await _personalInformationService.UpdatePersonalInformationAsync(id, It.IsAny<UpdatePersonalInformationRequestDTO>());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeletePersonalInformationAsync_ShouldReturnTrue_WhenDetailExists()
        {
            // Arrange
            var id = _id;
            var existingPersonalInformation = new PersonalInformation
            {
                Id = id,
                // Populate other properties as needed
            };

            // Mocking repository to return the existing personal information
            _PersonalInformationMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(existingPersonalInformation);
            _PersonalInformationMock.Setup(repo => repo.DeleteAsync(existingPersonalInformation)).Returns(Task.CompletedTask);

            // Act
            var result = await _personalInformationService.DeletePersonalInformationAsync(id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeletePersonalInformationAsync_ShouldReturnFalse_WhenDetailDoesNotExist()
        {
            // Arrange
            var id = _id;

            // Mocking repository to return null for the existing personal information
            _PersonalInformationMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync((PersonalInformation)null);

            // Act
            var result = await _personalInformationService.DeletePersonalInformationAsync(id);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetPaginatedAsync_ShouldReturnMappedDTOs_WhenFilteredResultNotEmpty()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 5;
            var Id = _id;

            var mockPersonalInformations = new List<PersonalInformation>
            {
                // Populate with mock data
                new PersonalInformation { Id = Id , FirstName = "John", LastName = "Doe" },
                new PersonalInformation { Id = Id , FirstName = "Jane", LastName = "Smith" }
            };

            // Mocking repository to return the mock list of personal informations
            _PersonalInformationMock
                .Setup(repo => repo.GetPaginatedAsync(pageNumber, pageSize))
                .ReturnsAsync(mockPersonalInformations);

            var expectedMappedDtoList = new List<PersonalInformationDTO>
            {
                // Populate with expected mapped DTOs based on mock data
                new PersonalInformationDTO { Id = Id, FirstName = "John", LastName = "Doe" },
                new PersonalInformationDTO { Id = Id, FirstName = "Jane", LastName = "Smith" }
            };

            // Mocking mapper to return the list of mapped DTOs
            _mapperMock
                .Setup(mapper => mapper.Map<IEnumerable<PersonalInformationDTO>>(mockPersonalInformations))
                .Returns(expectedMappedDtoList);

            // Act
            var result = await _personalInformationService.GetPaginatedAsync(pageNumber, pageSize);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMappedDtoList, result);
        }

        [Fact]
        public async Task GetPaginatedAsync_ShouldReturnNull_WhenFilteredResultEmpty()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 5;

            var mockPersonalInformations = Enumerable.Empty<PersonalInformation>();

            // Mocking repository to return an empty list of personal informations
            _PersonalInformationMock
                .Setup(repo => repo.GetPaginatedAsync(pageNumber, pageSize))
                .ReturnsAsync(mockPersonalInformations);

            // Act
            var result = await _personalInformationService.GetPaginatedAsync(pageNumber, pageSize);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdatePersonalInformationAsync_ExistingId_ReturnsUpdatedDto()
        {
            // Arrange
            var existingId = _id;
            var existingDetail = new PersonalInformation { Id = existingId, FirstName = "John", LastName = "Doe" };

            var updatedRequest = new UpdatePersonalInformationRequestDTO { FirstName = "Jane" };

            var updatedDetail = new PersonalInformationDTO { Id = existingId, FirstName = "Jane", LastName = "Doe" };

            _PersonalInformationMock.Setup(repo => repo.GetByIdAsync(existingId)).ReturnsAsync(existingDetail);

            _mapperMock.Setup(mapper => mapper.Map<PersonalInformation>(updatedRequest)).Returns(existingDetail);
            _mapperMock.Setup(mapper => mapper.Map<PersonalInformationDTO>(existingDetail)).Returns(updatedDetail);

           
            // Act
            var result = await _personalInformationService.UpdatePersonalInformationAsync(existingId, updatedRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedDetail.Id, result.Id);
            Assert.Equal(updatedDetail.FirstName, result.FirstName);
            Assert.Equal(updatedDetail.LastName, result.LastName);
            // Add more assertions as needed for other properties
        }

        [Fact]
        public async Task UpdatePersonalInformationAsync_NonExistingId_ReturnsNull()
        {
            // Arrange
            var nonExistingId = _id;

            // Act
            var result = await _personalInformationService.UpdatePersonalInformationAsync(nonExistingId, new UpdatePersonalInformationRequestDTO());

            // Assert
            Assert.Null(result);
        }

    }
}

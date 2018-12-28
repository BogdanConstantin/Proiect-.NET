namespace BusinessLogic.ClassesManagement.Implementations
{
    using BusinessLogic.ClassesManagement.Abstractions;

    using DataAccess.ClassesManagement.Abstractions;

    using Entities.ClassesManagement;

    using Models.ClassesManagement;
    using System;
    using System.Collections.Generic;

    public class LaboratoryManagementLogic : BaseLogic, ILaboratoryManagementLogic
    {
        public LaboratoryManagementLogic(IRepository repository)
            : base(repository)
        {
        }

        public void Create(ManagementDto laboratoryDto)
        {
            var newLaboratory = new LaboratoryManagement()
            {
                ClassId = laboratoryDto.ClassId,
                EntityId = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                UserId = laboratoryDto.UserId,
                UserPosition = laboratoryDto.UserPosition
                // load managed course when read is done
            };

            _repository.Insert(newLaboratory);
            _repository.Save();
        }

        public LaboratoryManagement Update(ManagementDto laboratoryManagementDto, Guid laboratoryManagementEntityId)
        {
            var laboratoryManagement = _repository.GetLastByFilter<LaboratoryManagement>(c => c.EntityId == laboratoryManagementEntityId);

            if (laboratoryManagement == null || laboratoryManagement.DeletedDate != null)
            {
                return null;
            }

            laboratoryManagement.Id = Guid.NewGuid();
            laboratoryManagement.AuthorId = Guid.NewGuid();
            laboratoryManagement.ClassId = laboratoryManagementDto.ClassId;
            laboratoryManagement.UserId = laboratoryManagementDto.UserId;
            laboratoryManagement.UserPosition = laboratoryManagementDto.UserPosition;

            _repository.Insert(laboratoryManagement);
            _repository.Save();

            return laboratoryManagement;
        }

        public LaboratoryManagement Delete(Guid laboratoryManagementEntityId)
        {
            var laboratoryManagement = _repository.GetLastByFilter<LaboratoryManagement>(c => c.EntityId == laboratoryManagementEntityId);

            if (laboratoryManagement == null || laboratoryManagement.DeletedDate != null)
            {
                return null;
            }

            laboratoryManagement.Id = Guid.NewGuid();
            laboratoryManagement.AuthorId = Guid.NewGuid();
            laboratoryManagement.DeletedDate = DateTime.Now;

            _repository.Insert(laboratoryManagement);
            _repository.Save();

            return laboratoryManagement;
        }

        public ManagementDto GetById(Guid laboratoryManagementEntityId)
        {
            var laboratoryManagement = _repository.GetLastByFilter<LaboratoryManagement>(c => c.EntityId == laboratoryManagementEntityId);

            if (laboratoryManagement == null || laboratoryManagement.DeletedDate != null)
            {
                return null;
            }

            var laboratoryManagementDto = new ManagementDto
            {
                ClassId = laboratoryManagement.ClassId,
                UserId = laboratoryManagement.UserId,
                UserPosition = laboratoryManagement.UserPosition
            };

            return laboratoryManagementDto;
        }

        public ICollection<ManagementDto> GetAll()
        {
            List<ManagementDto> laboratoryManagementDtos = new List<ManagementDto>();

            var laboratoryManagements = _repository.GetAll<LaboratoryManagement>();

            foreach (var laboratoryManagement in laboratoryManagements)
            {
                var laboratoryManagementDto = new ManagementDto
                                              {
                                                  ClassId = laboratoryManagement.ClassId,
                                                  UserId = laboratoryManagement.UserId,
                                                  UserPosition = laboratoryManagement.UserPosition
                                              };

                laboratoryManagementDtos.Add(laboratoryManagementDto);

            }


            return laboratoryManagementDtos;
        }
    }
}

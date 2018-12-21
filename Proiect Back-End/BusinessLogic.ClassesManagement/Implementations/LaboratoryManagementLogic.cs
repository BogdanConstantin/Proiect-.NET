namespace BusinessLogic.ClassesManagement.Implementations
{
    using BusinessLogic.ClassesManagement.Abstractions;

    using DataAccess.ClassesManagement.Abstractions;

    using Entities.ClassesManagement;

    using Models.ClassesManagement;
    using System;

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

        public void Update(ManagementDto laboratoryManagementDto, Guid laboratoryManagementEntityId)
        {
            var laboratoryManagement = _repository.GetLastByFilter<LaboratoryManagement>(c => c.EntityId == laboratoryManagementEntityId);

            if (laboratoryManagement.DeletedDate != null)
            {
                return;
            }

            laboratoryManagement.Id = Guid.NewGuid();
            laboratoryManagement.AuthorId = Guid.NewGuid();
            laboratoryManagement.ClassId = laboratoryManagementDto.ClassId;
            laboratoryManagement.UserId = laboratoryManagementDto.UserId;
            laboratoryManagement.UserPosition = laboratoryManagementDto.UserPosition;

            _repository.Insert(laboratoryManagement);
            _repository.Save();
        }

        public void Delete(Guid laboratoryManagementEntityId)
        {
            var laboratoryManagement = _repository.GetLastByFilter<LaboratoryManagement>(c => c.EntityId == laboratoryManagementEntityId);

            laboratoryManagement.Id = Guid.NewGuid();
            laboratoryManagement.AuthorId = Guid.NewGuid();
            laboratoryManagement.DeletedDate = DateTime.Now;

            _repository.Insert(laboratoryManagement);
            _repository.Save();
        }
    }
}

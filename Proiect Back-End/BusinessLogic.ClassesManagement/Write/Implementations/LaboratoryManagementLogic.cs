namespace BusinessLogic.ClassesManagement.Write.Implementations
{
    using BusinessLogic.ClassesManagement.Write.Abstractions;

    using DataAccess.ClassesManagement.Write.Abstractions;

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
    }
}

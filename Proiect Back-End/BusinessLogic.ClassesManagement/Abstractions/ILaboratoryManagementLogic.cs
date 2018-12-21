

namespace BusinessLogic.ClassesManagement.Abstractions
{
    using Models.ClassesManagement;
    using Entities.ClassesManagement;
    using System;

    public interface ILaboratoryManagementLogic
    {
        void Create(ManagementDto laboratoryManagementDto);

        LaboratoryManagement Update(ManagementDto laboratoryManagementDto, Guid laboratoryManagementEntityId);

        LaboratoryManagement Delete(Guid laboratoryManagementEntityId);

        ManagementDto GetById(Guid laboratoryManagementEntityId);
    }
}

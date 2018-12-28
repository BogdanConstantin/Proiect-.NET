

namespace BusinessLogic.ClassesManagement.Abstractions
{
    using Models.ClassesManagement;
    using Entities.ClassesManagement;
    using System;
    using System.Collections.Generic;

    public interface ILaboratoryManagementLogic
    {
        void Create(ManagementDto laboratoryManagementDto);

        LaboratoryManagement Update(ManagementDto laboratoryManagementDto, Guid laboratoryManagementEntityId);

        LaboratoryManagement Delete(Guid laboratoryManagementEntityId);

        ManagementDto GetById(Guid laboratoryManagementEntityId);

        ICollection<ManagementDto> GetAll();
    }
}

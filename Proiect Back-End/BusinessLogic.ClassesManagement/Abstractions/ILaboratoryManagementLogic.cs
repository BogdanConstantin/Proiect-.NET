
namespace BusinessLogic.ClassesManagement.Abstractions
{
    using Models.ClassesManagement;
    using System;

    public interface ILaboratoryManagementLogic
    {
        void Create(ManagementDto laboratoryManagementDto);

        void Update(ManagementDto laboratoryManagementDto, Guid laboratoryManagementEntityId);

        void Delete(Guid laboratoryManagementEntityId);
    }
}


namespace BusinessLogic.ClassesManagement.Abstractions
{
    using Models.ClassesManagement;
    using System;

    public interface ICourseManagementLogic
    {
        void Create(ManagementDto courseManagementDto);

        void Update(ManagementDto courseManagementDto, Guid courseManagementEntityId);

        void Delete(Guid courseManagementEntityId);
    }
}


namespace BusinessLogic.ClassesManagement.Abstractions
{
    using Entities.ClassesManagement;
    using Models.ClassesManagement;
    using System;
    using System.Collections.Generic;

    public interface ICourseManagementLogic
    {
        CourseManagement Create(ManagementDto courseManagementDto);

        CourseManagement Update(ManagementDto courseManagementDto, Guid courseManagementEntityId);

        CourseManagement Delete(Guid courseManagementEntityId);

        ManagementDto GetById(Guid courseManagementEntityId);

        ICollection<ManagementDto> GetAll();
    }
}

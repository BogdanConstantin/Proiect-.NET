namespace BusinessLogic.ClassesManagement.Abstractions
{
    using System;
    using System.Collections.Generic;
    using Entities.ClassesManagement;
    using Models.ClassesManagement;

    public interface ICourseLogic
    {
        Course Create(CourseDto courseDto);

        Course Update(CourseDto courseDto, Guid courseEntityId);

        Course Delete(Guid courseEntityId);

        CourseDto GetById(Guid courseEntityId);

        ICollection<CourseDto> GetAll();
    }
}

namespace BusinessLogic.ClassesManagement.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.ClassesManagement;
    using Models.ClassesManagement;

    public interface ICourseLogic
    {
        void Create(CourseDto courseDto);

        void Update(CourseDto courseDto, Guid courseEntityId);

        void Delete(Guid courseEntityId);

        CourseDto GetById(Guid courseEntityId);

        ICollection<CourseDto> GetAll();
    }
}

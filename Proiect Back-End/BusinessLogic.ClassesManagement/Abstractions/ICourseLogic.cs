namespace BusinessLogic.ClassesManagement.Abstractions
{
    using System;

    using Models.ClassesManagement;

    public interface ICourseLogic
    {
        void Create(CourseDto courseDto);

        void Update(CourseDto courseDto, Guid courseEntityId);

        void Delete(Guid courseEntityId);
    }
}

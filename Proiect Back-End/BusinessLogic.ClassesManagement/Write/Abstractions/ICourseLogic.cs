namespace BusinessLogic.ClassesManagement.Write.Abstractions
{
    using Models.ClassesManagement;

    public interface ICourseLogic
    {
        void Create(CourseDto courseDto);
    }
}

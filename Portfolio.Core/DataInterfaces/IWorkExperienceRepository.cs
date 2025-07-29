namespace Portfolio.Core.DataInterfaces
{
    public interface IWorkExperienceRepository
    {
        Task CreateWorkExperienceAsync(WorkExperience workExperience);
        Task UpdateWorkExperienceAsync(WorkExperience workExperience);
        Task GetWorkExperienceById( Guid id );
        Task<bool> DeleteExperienceAsync(Guid id);
    }
}

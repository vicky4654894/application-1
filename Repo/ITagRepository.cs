using _1_Application.Models.Domain;
using _1_Application.Models.ViewModels;

namespace _1_Application.Repo;
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();

         Task<Tag> AddTagAsync(Tag tag);

         Task<Tag?> DeleteTagAsync(EditTagRequest editTagRequest);
        
        Task<Tag?> EditTagAysnc(EditTagRequest editTagRequest);

        Task<Tag?> FindByIdAsync(long id);


    }



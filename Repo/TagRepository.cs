using _1_Application.Models.ViewModels;
using _1_Application.Data;
using _1_Application.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace _1_Application.Repo
{
    public class TagRepository : ITagRepository
    {
        
        private readonly DBContext dBContext;
        public TagRepository(DBContext dBContext)
        {
        this.dBContext=dBContext;
    }

        public async Task<Tag> FindByIdAsync(long id)
        {
            return await dBContext.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            
            return await dBContext.Tags.ToListAsync();;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
             await dBContext.Tags.AddAsync(tag);
             await dBContext.SaveChangesAsync();
             return tag;
        }

         public async Task<Tag?> DeleteTagAsync(EditTagRequest editTagRequest)
        {
            var tag = new Tag
        {
            Id = editTagRequest.Id,
            Name = editTagRequest.Name,
            DisplayName = editTagRequest.DisplayName
        };

        var existingTag = await dBContext.Tags.FindAsync(tag.Id);

        if(existingTag != null)
        {
             dBContext.Tags.Remove(existingTag);
            await dBContext.SaveChangesAsync();
        }
        return tag;
        }
        
        public  async Task<Tag?> EditTagAysnc(EditTagRequest editTagRequest)
        {
            var tag = new Tag
        {
            Id = editTagRequest.Id,
            Name = editTagRequest.Name,
            DisplayName = editTagRequest.DisplayName
        };

        var existingTag = await dBContext.Tags.FindAsync(tag.Id);

        if(existingTag != null)
        {
            existingTag.Id=tag.Id;
            existingTag.DisplayName=tag.DisplayName;
            await dBContext.SaveChangesAsync();
        }
        return tag;
        }


    }
}
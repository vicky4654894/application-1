namespace _1_Application.Models.Domain;

public class Tag
{
    public long Id{set;get;}

    public string Name{set;get;}

    public string DisplayName{set;get;}

        public ICollection<BlogPost> Tags{set;get;}

}
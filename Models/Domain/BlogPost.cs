namespace _1_Application.Models.Domain;

public class BlogPost
{
    public long Id {set;get;}

    public string Heading{set;get;}

    public string PageTitle{set;get;}

    public string Content{set;get;}

    public string ShortDescription{set;get;}

    public string FeaturedImageUrl{set;get;}

    public string UrlHandler{set;get;}

    public DateTime PublishedDate{set;get;}

    public string Author{set;get;}

    public bool Visible{set;get;}

    public ICollection<Tag> Tags{set;get;}



}
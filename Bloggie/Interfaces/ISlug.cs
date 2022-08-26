namespace Bloggie.Interfaces
{
    public interface ISlug
    {
        string Slug { get; set; }

        string GetSlugText();
    }
}

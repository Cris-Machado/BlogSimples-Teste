
namespace BlogSimples.API.Domain.Services
{
    public class Post
    {
        public Post(Guid userId, string title, string description)
        {
            UserId = userId;
            Title = title;
            Description = description;
            Date = DateTime.Now;
        }
        public Post(Guid id, Guid userId, string title, string description)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            Date = DateTime.Now;
        }

        public virtual Guid Id { get; protected set; }
        public virtual Guid UserId { get; protected set; }
        public virtual string Title { get; protected set; } = string.Empty;
        public virtual string Description { get; protected set; } = string.Empty;
        public virtual DateTime Date { get; protected set; } = DateTime.MinValue;
    }
}

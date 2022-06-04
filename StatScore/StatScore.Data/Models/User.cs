namespace StatScore.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.Favorites = new HashSet<Favorites>();
        }

        public virtual ICollection<Favorites> Favorites { get; init; }
    }
}

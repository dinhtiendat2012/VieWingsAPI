namespace VieWingsAPI.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using VieWingsAPI.Model;

    public class DataContext : DbContext
    {
        // Constructor that accepts DbContextOptions
        public DataContext(DbContextOptions<DataContext> options): base(options){}

        // Define your DbSets (tables) here
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Emotion> Emotion { get; set; }
        public DbSet<EmotionOfPost> EmotionOfPost { get; set; }
        public DbSet<EmotionOfComment> EmotionOfComment { get; set; }
        public DbSet<RequestFriend> RequestFriend { get; set; }


        // Additional configuration or methods (if needed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestFriend>()
                .HasNoKey();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Sử dụng chuỗi kết nối nếu nó chưa được cấu hình
                optionsBuilder.UseSqlServer("YourConnectionStringHere");
            }
        }

    }


}

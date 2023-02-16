using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class AppDbContext: DbContext {
    const string databaseName = "database.db";

    public DbSet<User> users { get; set; }

    public DbSet<Post> posts { get; set; }

    public DbSet<Comment> comments { get; set; }

    public DbSet<Like> likes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        System.Environment.SpecialFolder folder = System.Environment.SpecialFolder.LocalApplicationData;
        string path = System.Environment.GetFolderPath(folder);
        string dbPath = System.IO.Path.Join(path, databaseName);

        optionsBuilder.UseSqlite($"Data source = {dbPath}");
        optionsBuilder.EnableSensitiveDataLogging();

        Console.WriteLine($"Using {dbPath} as database.");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasData(
            new User(1, "admin", "admin"),
            new User(2, "user", "user")
        );

    //     modelBuilder.Entity<Book>()
    //         .HasMany<Author>(b => b.Authors)
    //         .WithMany(a => a.Books)
    //         .UsingEntity(join => join.HasData(
    //             new {BooksId = 1, AuthorsId = 1},
    //             new {BooksId = 2, AuthorsId = 3},
    //             new {BooksId = 3, AuthorsId = 2}
    //             ));

    //     modelBuilder.Entity<Book>()
    //         .Property(b => b.Created)
    //         .HasDefaultValueSql("datetime()");
    }
}
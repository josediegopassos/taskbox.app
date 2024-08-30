using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context.Configurations;

namespace TaskBox.Infra.Data.Context
{
    public class TaskBoxDbContext : DbContext
    {
        public TaskBoxDbContext(DbContextOptions<TaskBoxDbContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<ListTask> ListTasks { get; set; }
        public DbSet<Marker> Markers { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        public DbSet<TaskMarker> TaskMarkers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["TaskBoxDatabase"].ConnectionString);
            //}

            //optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BoardConfiguration());
            modelBuilder.ApplyConfiguration(new ListTaskConfiguration());
            modelBuilder.ApplyConfiguration(new MarkerConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskMarkerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Model.GetEntityTypes().ToList().ForEach(entityType =>
            {
                entityType.SetTableName(entityType.DisplayName());

                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

                entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(string))
                    .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))
                    .ToList()
                    .ForEach(property =>
                    {
                        property.IsUnicode(false);
                        property.HasMaxLength(2000);
                    });
            });

            SeedData(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskBoxDbContext).Assembly);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
              User.Create("Pedro", "test+1@mail.com"),
              User.Create("Tiago", "test+2@mail.com"),
              User.Create("João", "test+3@mail.com")
           );

            modelBuilder.Entity<ListTask>().HasData(
               ListTask.Create("A fazer", "Tarefas pendentes"),
               ListTask.Create("Fazendo", "Tarefas em andamento"),
               ListTask.Create("Feito", "Tarefas realizadas")
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Context
{
    public class ChatServiceDbContext(DbContextOptions<ChatServiceDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<ConversationEntity> Conversations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.User)
                .WithMany(u => u.Contacts)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.ContactUser)
                .WithMany()
                .HasForeignKey(c => c.ContactUserId);

            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId);

            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId);
        }
    }
}
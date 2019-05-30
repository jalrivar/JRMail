namespace JRMail.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelJRMail : DbContext
    {
        public ModelJRMail()
            : base("name=ModelJRMail")
        {
        }

        public virtual DbSet<MailBox> MailBox { get; set; }
        public virtual DbSet<MailClassification> MailClassification { get; set; }
        public virtual DbSet<MailMessage> MailMessage { get; set; }
        public virtual DbSet<MailMessageClassifaction> MailMessageClassifaction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailBox>()
                .Property(e => e.MailBoxName)
                .IsUnicode(false);

            modelBuilder.Entity<MailBox>()
                .HasMany(e => e.MailMessage)
                .WithRequired(e => e.MailBox)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MailClassification>()
                .Property(e => e.MailClassificationName)
                .IsUnicode(false);

            modelBuilder.Entity<MailClassification>()
                .HasMany(e => e.MailMessageClassifaction)
                .WithRequired(e => e.MailClassification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MailMessage>()
                .Property(e => e.To)
                .IsUnicode(false);

            modelBuilder.Entity<MailMessage>()
                .Property(e => e.CC)
                .IsUnicode(false);

            modelBuilder.Entity<MailMessage>()
                .Property(e => e.BCC)
                .IsUnicode(false);

            modelBuilder.Entity<MailMessage>()
                .Property(e => e.From)
                .IsUnicode(false);

            modelBuilder.Entity<MailMessage>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<MailMessage>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<MailMessage>()
                .HasMany(e => e.MailMessageClassifaction)
                .WithRequired(e => e.MailMessage)
                .WillCascadeOnDelete(false);
        }
    }
}

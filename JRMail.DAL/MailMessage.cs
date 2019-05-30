namespace JRMail.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JRM.MailMessage")]
    public partial class MailMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MailMessage()
        {
            MailMessageClassifaction = new HashSet<MailMessageClassifaction>();
        }

        public int MailMessageId { get; set; }

        public int MailBoxId { get; set; }

        public int MailMessageStatusId { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(250)]
        public string To { get; set; }

        [Required]
        [StringLength(250)]
        public string CC { get; set; }

        [Required]
        [StringLength(250)]
        public string BCC { get; set; }

        [Required]
        [StringLength(250)]
        public string From { get; set; }

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        [Required]
        [StringLength(3999)]
        public string Body { get; set; }

        public DateTime Date { get; set; }

        public bool Readed { get; set; }

        public virtual MailBox MailBox { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailMessageClassifaction> MailMessageClassifaction { get; set; }

        public virtual MailMessageStatus MailMessageStatus { get; set; }
    }
}

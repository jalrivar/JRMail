namespace JRMail.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JRM.MailMessageStatus")]
    public partial class MailMessageStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MailMessageStatus()
        {
            MailMessage = new HashSet<MailMessage>();
        }

        public int MailMessageStatusId { get; set; }

        [Required]
        [StringLength(25)]
        public string MailMessageStatusName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailMessage> MailMessage { get; set; }
    }
}

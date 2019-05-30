namespace JRMail.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JRM.MailBox")]
    public partial class MailBox
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MailBox()
        {
            MailMessage = new HashSet<MailMessage>();
        }

        public int MailBoxId { get; set; }

        [StringLength(50)]
        public string MailBoxName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailMessage> MailMessage { get; set; }
    }
}

namespace JRMail.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JRM.MailMessageClassifaction")]
    public partial class MailMessageClassifaction
    {
        public int MailMessageClassifactionId { get; set; }

        public int MailMessageId { get; set; }

        public int MailClassificationId { get; set; }

        public virtual MailClassification MailClassification { get; set; }

        public virtual MailMessage MailMessage { get; set; }
    }
}

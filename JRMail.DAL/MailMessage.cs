//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JRMail.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MailMessage
    {
        public int MailMessageId { get; set; }
        public int MailBoxId { get; set; }
        public string UserName { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public System.DateTime Date { get; set; }
        public int MailStatus { get; set; }
    
        public virtual MailBox MailBox { get; set; }
    }
}

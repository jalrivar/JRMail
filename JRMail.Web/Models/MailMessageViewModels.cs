using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JRMail.DAL;

namespace JRMail.Web.Models
{
    public class MailMessageViewModel : DAL.MailMessage
    {
        private MailMessage mailMessage;

        public MailMessageViewModel()
        {
        }

        public MailMessageViewModel(MailMessage mailMessage)
        {
            this.mailMessage = mailMessage;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public new DateTime Date { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public new string To { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public new string CC { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public new string BCC { get; set; }
    }
}
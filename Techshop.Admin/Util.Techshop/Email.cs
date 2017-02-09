using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Configuration;
using System.Configuration;

namespace Util.Techshop
{
    public class Email
    {
          
        public void EnviaEmail(string Para, string de, string assunto, String Mensagem, string Senha)
        {
             MailMessage msg = new MailMessage();
            msg.From = new MailAddress("contato@rezendesolucoes.com");
            msg.To.Add(new MailAddress("contato@rezendesolucoes.com"));
            msg.Subject = assunto;
            msg.Body =  de+"<br><br>"+ Mensagem;
            SmtpClient sc = new SmtpClient("mail.rezendesolucoes.com", 587);
            //sc.EnableSsl = true;
            //sc.UseDefaultCredentials = false;
            sc.Credentials = new NetworkCredential("contato@rezendesolucoes.com", "Rezende#4545");
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Send(msg);

        }
    }
}
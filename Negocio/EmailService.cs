using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

//es un plus, hacerlo despues de que tengamos todo lo BASICO
namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("api", "********598e");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "live.smtp.mailtrap.io";
            //modificar para q funcione
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@clinica.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1>Reporte de materias a las que se ha inscripto</h1> <br>Hola, te inscribiste.... bla bla";
            email.Body = cuerpo;

        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

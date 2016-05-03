using FinalWebAPI.Models;
using FinalWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FinalWebAPI.APIHelper
{
    public class Gmailer
    {

        public bool sendEmail(String email, List<PurchaseDTO> movies)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("w0573147@selu.edu");
                mail.Subject = "Hello";
               // string[] fsa = getName(products);


                int count = 1;
                foreach (var item in movies)
                {
                    mail.Body += " **Movie " + count + "  **Name: " + "  " + item.Name + " **Quantity:  " + item.InventoryCount + " **Time: " + item.time + " **Date: " + item.date + " **Screen: " + item.ScreenNumber + " **Price:   " + item.Price + "   " + "\r\n" + Environment.NewLine;
                    count++;
                    // mail.Body = print(product.Name);
                }



                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("convergent.origin@gmail.com", "Dangtest78");// Enter senders User name and password
                smtp.EnableSsl = true;
                Console.WriteLine("Sending email .... ");
                smtp.Send(mail);
                return true;
            }
            catch (Exception e)
            {
               
                return false;
            }
           
        }
    }
}
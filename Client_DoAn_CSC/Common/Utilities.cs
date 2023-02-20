using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Common
{
    public class Utilities
    {
        public static string ServiceURL { get; set; }

        //

        public static T SendDataRequest<T>(string APIUrl, object input = null)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri("https://localhost:44345/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync(APIUrl, input).Result;
            T kq = default(T);
            if (response.IsSuccessStatusCode)
                kq = response.Content.ReadFromJsonAsync<T>().Result;
            return kq;
        }
        public class PropertyCopier<TParent, TChild> where TParent : class
                                    where TChild : class
        {
            public static void Copy(TParent parent, TChild child)
            {
                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();

                foreach (var parentProperty in parentProperties)
                {
                    if (parentProperty.Name.ToLower() == "id") continue;
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name &&
                            parentProperty.PropertyType == childProperty.PropertyType &&
                            childProperty.SetMethod != null)
                        {
                            if (parentProperty.GetValue(parent) != null)
                                childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }
            }
        }
        public static bool SendMail(string subject, string message, string email)
        {
            try
            {
                var mailMsg = new MailMessage();

                mailMsg.To.Add(new MailAddress(email, ""));
                mailMsg.From = new MailAddress("shopptdidong@gmail.com", "Tinh Nguyen");

                mailMsg.Subject = subject;
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null,
                                                                           MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null,
                                                                            MediaTypeNames.Text.Html));

                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                var credentials = new System.Net.NetworkCredential("shopptdidong@gmail.com", "Tinh29740");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMsg);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebClient.Connections
{
    class ConnectorToUrl
    {
        public static string POSTConnectionToUrl(string url, CustomerCreateRequest customer)
        {
            string response;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            var postData = "firstname=" + Uri.EscapeDataString(customer.Firstname);
            postData += "&lastname=" + Uri.EscapeDataString(customer.Lastname);

            var data = Encoding.ASCII.GetBytes(postData);

            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = data.Length;

            using (var stream = httpWebRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            return response;
        }

        public static string GETConnectionToUrl(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            return response;
        }
    }
}

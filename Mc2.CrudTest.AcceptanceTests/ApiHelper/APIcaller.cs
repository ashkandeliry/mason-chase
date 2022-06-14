using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.ApiHelper
{
    public class APIcaller
    {
        public static class CsWebApiHelper
        {
            public async static Task<HttpResponseMessage> CallPostMethod(string uri, string parameters)
            {
                try
                {
                    var stringContent = new StringContent(parameters, System.Text.Encoding.UTF8, "application/json");
                    HttpClient httpClient = new HttpClient();
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (ServicePointManager, cer, chin, sslerror) => { return true; };
                    var response = await httpClient.PostAsync(uri, stringContent);
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    //return responseContent;
                    return response;
                }
                catch (Exception ex)
                { throw ex; }

            }

            public static string CallPostMethod(string uri, string username, string password)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (ServicePointManager, cer, chin, sslerror) => { return true; };

                    var bytearray = ASCIIEncoding.ASCII.GetBytes(username + ":" + password);
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytearray));

                    var response = httpClient.GetAsync(uri).Result;
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    return responseContent;
                }
                catch (Exception ex)
                { throw ex; }

            }
            public static string CallPostMethodWithBasic(string uri, string parameters)
            {
                try
                {
                    var stringContent = new StringContent(parameters, System.Text.Encoding.UTF8, "application/json");
                    HttpClient httpClient = new HttpClient();
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (ServicePointManager, cer, chin, sslerror) => { return true; };
                    //var bytearray = ASCIIEncoding.ASCII.GetBytes(username + ":" + password);
                    //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytearray));
                    var response = httpClient.PostAsync(uri, stringContent).Result;


                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    return responseContent;
                }
                catch (Exception ex)
                { throw ex; }

            }

            public static string CallPostMethodWithHeader(string uri, string parameters, string Token)
            {
                try
                {
                    var stringContent = new StringContent(parameters, System.Text.Encoding.UTF8, "application/json");
                    HttpClient httpClient = new HttpClient();
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (ServicePointManager, cer, chin, sslerror) => { return true; };

                    httpClient.DefaultRequestHeaders.Add("AuthorizationToken", Token);
                    //var bytearray = ASCIIEncoding.ASCII.GetBytes(username + ":" + password);
                    //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytearray));
                    var response = httpClient.PostAsync(uri, stringContent).Result;


                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    return responseContent;
                }
                catch (Exception ex)
                { throw ex; }

            }

            public static string CallPostMethodWithHeader(string uri, string parameters, string username, string password)
            {
                try
                {
                    var stringContent = new StringContent(parameters, System.Text.Encoding.UTF8, "application/json");
                    HttpClient httpClient = new HttpClient();
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (ServicePointManager, cer, chin, sslerror) => { return true; };

                    httpClient.DefaultRequestHeaders.Add("username", username);
                    httpClient.DefaultRequestHeaders.Add("password", password);
                    var response = httpClient.PostAsync(uri, stringContent).Result;

                    string responseContent = null;
                    try
                    {
                        responseContent = response.Content.ReadAsStringAsync().Result;
                    }
                    catch (Exception)
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    return responseContent;
                }
                catch (Exception ex)
                { throw ex; }

            }

            public static string CallPostMethodWithBasic(string uri, string parameters, string username, string password)
            {
                try
                {
                    var stringContent = new StringContent(parameters, System.Text.Encoding.UTF8, "application/json");
                    HttpClient httpClient = new HttpClient();
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (ServicePointManager, cer, chin, sslerror) => { return true; };


                    var bytearray = ASCIIEncoding.ASCII.GetBytes(username + ":" + password);
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytearray));
                    var response = httpClient.PostAsync(uri, stringContent).Result;

                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    return responseContent;
                }
                catch (Exception ex)
                { throw ex; }

            }

            public static string CallGetMethodWithBasic(string uri)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (ServicePointManager, cer, chin, sslerror) => { return true; };

                    //var bytearray = ASCIIEncoding.ASCII.GetBytes(username + ":" + password);
                    //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytearray));
                    var response = httpClient.GetAsync(uri).Result;

                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    return responseContent;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CallRequestResponseService
{

    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    public class Program
    {
        static void Test(string[] args)
        {
            InvokeRequestResponseService("61","80","1.015","2","0","abnormal","abnormal","notpresent", "notpresent","173","148","3.9","135","5.2","7.7","24","9200","3.2","yes","yes","yes","poor","yes","yes").Wait();
        }

        public static async Task<string> InvokeRequestResponseService(string age, string bp, string sg, string al, string su, string rbc, string pc, string pcc, string ba, string bgr, string bu, string sc, string sod, string pot, string hemo, string pcv, string wbcc, string rbcc, string htn, string dm, string cad, string appet, string pe, string ane)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[]
                                {
                                    "age",
                                    "bp",
                                    "sg",
                                    "al",
                                    "su",
                                    "rbc",
                                    "pc",
                                    "pcc",
                                    "ba",
                                    "bgr",
                                    "bu",
                                    "sc",
                                    "sod",
                                    "pot",
                                    "hemo",
                                    "pcv",
                                    "wbcc",
                                    "rbcc",
                                    "htn",
                                    "dm",
                                    "cad",
                                    "appet",
                                    "pe",
                                    "ane",
                                    "class"
                                },
                                Values = new string[,] {{

                                        age,
                                        bp,
                                        sg,
                                        al,
                                        su,
                                        rbc,
                                        pc,
                                        pcc,
                                        ba,
                                        bgr,
                                        bu,
                                        sc,
                                        sod,
                                        pot,
                                        hemo,
                                        pcv,
                                        wbcc,
                                        rbcc,
                                        htn,
                                        dm,
                                        cad,
                                        appet,
                                        pe,
                                        ane,
                                        "value"
                                    }
                                 }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "3hR/CNBu38FJHzFcEQyn8+8QZnj6ncseP6qyggZ+5gDBHOlSVUtUQ15QHe5NcaP3r0wfK8d7GVB0+AMC8fP8CA=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/42323bea124744bfb354d12506b69c9e/services/47890c2b3fdf4841ab3b376c12794b20/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Console.WriteLine(result);
                    return result;

                }
                else
                {
                    return "0";

                   /* Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);*/
                }
            }
        }
    }
}

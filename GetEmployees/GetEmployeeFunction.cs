using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using StudentService.Models;

namespace GetEmployees
{
    public static class GetEmployeeFunction
    {
        [FunctionName("GetEmployeeFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5033/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/student/1");
               // if (response.IsSuccessStatusCode)
                //{
                    Student student = await response.Content.ReadAsAsync<Student> ();
                    Console.WriteLine("{0}\t${1}\t{2}", student.English, student.Hindi, student.Maths);
                    int sum = student.English + student.Hindi + student.Maths;
                    double percentage =  (sum/300) * 100;
                // }
                return new OkObjectResult(percentage);
            }
            
        }
    }
}

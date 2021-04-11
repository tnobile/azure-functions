using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MyFunctions.Models;

namespace My.Functions
{
    public static class CovidFaq
    {
        [FunctionName("CovidFaq")]
        public static async Task<IActionResult> Run(
         [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
         [CosmosDB(
            databaseName:"FaqDB",
            collectionName:"FaqContainer",
            ConnectionStringSetting = "DBConnectionString"
            )] IEnumerable<Faq> questionSet,
         ILogger log)
        {
            log.LogInformation("Data fetched from FaqContainer");
            return new OkObjectResult(questionSet);
        }
    }
}

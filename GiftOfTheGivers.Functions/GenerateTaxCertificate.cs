using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GiftOfTheGivers.Functions
{
    public class GenerateTaxCertificate
    {
        private readonly ILogger _logger;

        public GenerateTaxCertificate(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GenerateTaxCertificate>();
        }

        [Function("GenerateTaxCertificate")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("Generating tax certificate.");

            string donorName = req.Query["donorName"];
            string amount = req.Query["amount"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            donorName = donorName ?? data?.donorName;
            amount = amount ?? data?.amount;

            if (string.IsNullOrEmpty(donorName) || string.IsNullOrEmpty(amount))
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteStringAsync("Please pass a donorName and amount in the query string or body.");
                return badResponse;
            }

            string certificateNumber = $"GOTG-TAX-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

            var responseObj = new
            {
                Status = "Success",
                CertificateNumber = certificateNumber,
                Donor = donorName,
                Amount = amount,
                IssueDate = DateTime.UtcNow
            };

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(responseObj);
            return response;
        }
    }
}
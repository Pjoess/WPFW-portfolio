using System.Net;
using System.Threading.Tasks;
using RestSharp;
using Xunit;
using TechTalk.SpecFlow;
using Planner.Tests.Hooks;
using Planner.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Planner.Tests.Steps;

[Binding]
public sealed class GastStepDefinitions
{
    private readonly RestClient _client;
    private readonly DatabaseData _databaseData;
    private RestResponse? response;

    public GastStepDefinitions(DatabaseData databaseData)
    {
        _databaseData = databaseData;
        _client = new RestClient("http://localhost:5001/");

        // Het HTTPS certificaat hoeft niet gevalideerd te worden, dus return true
        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
    }
    
    //GAST BESTAAT NIET
    
    [Given("gast (.*) bestaat niet")]
    public async Task GastBestaatNiet(string naam)
    {
        //geen gast aanmaken
    }

    [When(@"gast Tim word verwijdert")]
    public void WhenGastTimWordVerwijdert()
    {
        var request = new RestRequest("api/Gast/1", Method.Delete);

        response = _client.Execute(request);
    }
    
    [Then("komt er een error (.*)")]
    public void Error3(int httpCode)
    {
        Assert.Equal(httpCode, (int)response!.StatusCode);
    }
}
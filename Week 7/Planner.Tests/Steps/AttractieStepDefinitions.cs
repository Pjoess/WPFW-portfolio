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
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Planner.Controllers;

namespace Planner.Tests.Steps;

[Binding]
public sealed class AttractieStepDefinitions
{
    private readonly RestClient _client;
    private readonly DatabaseData _databaseData;
    private RestResponse? response;

    public AttractieStepDefinitions(DatabaseData databaseData)
    {
        _databaseData = databaseData;
        _client = new RestClient("http://localhost:5001/");

        // Het HTTPS certificaat hoeft niet gevalideerd te worden, dus return true
        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
    }

    //BESTAAT AL
    [Given("attractie (.*) bestaat")]
    public async Task AttractieBestaat(string naam)
    {
        await _databaseData.Context.Attractie.AddAsync(new Attractie { Naam = naam });
        await _databaseData.Context.SaveChangesAsync();
    }

    [When("attractie (.*) wordt toegevoegd")]
    public async Task AttractieToevoegen(string naam)
    {
        var request = new RestRequest("api/Attracties").AddJsonBody(new { Naam = naam, Reserveringen = new List<string>() });
        response = await _client.ExecutePostAsync(request);
    }

    // [Then("moet er een error (.*) komen")]
    // public void Error2(int httpCode)
    // {
    //     Assert.Equal(httpCode, (int)response!.StatusCode);
    // }
    
    
    
    
    
    //BESTAAN NIET
    [Given(@"attractie Reuzenrad bestaat niet")]
    public void GivenAttractieReuzenradBestaatNiet()
    {
        // Geen attractie toevoegen
    }
    [When(@"attractie (.*) wordt verwijdert")]
    public async void WhenAttractieReuzenradWordtVerwijdert(string naam)
    {
        var request = new RestRequest("api/Attracties/1", Method.Delete);

        response = _client.Execute(request);
    }
    [Then(@"moet er een error (.*) komen")]
    public void Error(int httpCode)
    {
        Assert.Equal(httpCode, (int)response!.StatusCode);
    }
    
}

class AttractieToegevoegd
{
    public int Id { get; set; }
}
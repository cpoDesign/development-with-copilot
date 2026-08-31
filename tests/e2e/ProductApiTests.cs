using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TemplateProject.Tests.E2E;

[TestFixture]
public class ProductApiTests : PageTest
{
    [Test]
    public async Task CreateProduct_And_Verify_Via_Api()
    {
        // We can use the API directly or via UI if a UI is implemented
        // Since we only have an API, we use the request context
        var request = new { Name = "Playwright Product", Description = "E2E Description", Price = 99.99m };
        
        var response = await Page.APIRequest.PostAsync("http://localhost:5000/products", new() {
            Data = request
        });

        Assert.IsTrue(response.Ok);
        var body = await response.JsonAsync();
        Assert.IsNotNull(body);
        
        var id = (Guid)body.GetProperty("Id");

        var getResponse = await Page.APIRequest.GetAsync($"http://localhost:5000/products/{id}");
        Assert.IsTrue(getResponse.Ok);
        var getBody = await getResponse.JsonAsync();
        Assert.AreEqual(request.Name, getBody.GetProperty("Name").ToString());
    }
}

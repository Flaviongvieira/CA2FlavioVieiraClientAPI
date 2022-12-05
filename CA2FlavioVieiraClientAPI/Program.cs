// See https://aka.ms/new-console-template for more information
using System.Text;

try
{
    // 1. Create an instance of HttpClient
    using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
    {
        // 2. Init the base address of the WebService we are calling
        client.BaseAddress = new Uri("https://localhost:7001");

        // 3. Set the media types this client will accepct (in this case, for webservice, JSON)
        // application/json or application/xml
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        // 4. Call the WebApi using a get Http Request - we pass in the URL (without the base address part as we already set that)

        // Get Requests
        // Request All Products: https://localhost:7001/Products/AllProducts
        HttpResponseMessage response = await client.GetAsync("api/Products/AllProducts");
        // Request Product Category "Hurling" with Product Rating 5: https://localhost:7001/Products/Hurling/5
        HttpResponseMessage response1 = await client.GetAsync("api/Products/Hurling/5");
        // Request Products with Price between 39.80 and 59.90: https://localhost:7001/Products/Price/19/59.90
        HttpResponseMessage response2 = await client.GetAsync("api/Products/Price/19/59.90");



        // 5. Read the response
        Console.WriteLine("");
        Console.WriteLine("Request All Products:");
        checkResponse(response);
        Console.WriteLine("");
        Console.WriteLine("Request Product Category \"Hurling\" with Product Rating 5:");
        checkResponse(response1);
        Console.WriteLine("");
        Console.WriteLine("Request Products with Price between 19 and 59.90:");
        checkResponse(response2);

    }

}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}


// Function to show results in console app
void checkResponse(HttpResponseMessage response)
{
    if (response.IsSuccessStatusCode)
    {
        string message = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(message);
    }
    else
    {
        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
    }
}

using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
	public class ExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
				Headers =
	{
		{ "X-RapidAPI-Key", "be10ea9273msh0c47970528acd0cp1eeda5jsn6816d182d867" },
		{ "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				ViewBag.UsdToTry = body;
			}
			return View();
		}
	}
}

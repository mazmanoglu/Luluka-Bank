using Microsoft.AspNetCore.Mvc;
using System;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
	public class ExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{
         #region usd-tl
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
				ViewBag.UsdToTry = body.Substring(0, 6);
			}
         #endregion

         #region euro-tl
         var client2 = new HttpClient();
         var request2 = new HttpRequestMessage
         {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
            Headers =
   {
      { "X-RapidAPI-Key", "be10ea9273msh0c47970528acd0cp1eeda5jsn6816d182d867" },
      { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
   },
         };
         using (var response2 = await client2.SendAsync(request2))
         {
            response2.EnsureSuccessStatusCode();
            var body2 = await response2.Content.ReadAsStringAsync();
            ViewBag.EurToTry = body2.Substring(0, 6);
         }
         #endregion

         #region sterlin-tl
         var client3 = new HttpClient();
         var request3 = new HttpRequestMessage
         {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
            Headers =
   {
      { "X-RapidAPI-Key", "be10ea9273msh0c47970528acd0cp1eeda5jsn6816d182d867" },
      { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
   },
         };
         using (var response3 = await client3.SendAsync(request3))
         {
            response3.EnsureSuccessStatusCode();
            var body3 = await response3.Content.ReadAsStringAsync();
            ViewBag.GbpToTry = body3.Substring(0, 6);
         }
         #endregion

         #region usd-euro
         var client4 = new HttpClient();
         var request4 = new HttpRequestMessage
         {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=EUR&q=1.0"),
            Headers =
   {
      { "X-RapidAPI-Key", "be10ea9273msh0c47970528acd0cp1eeda5jsn6816d182d867" },
      { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
   },
         };
         using (var response4 = await client4.SendAsync(request4))
         {
            response4.EnsureSuccessStatusCode();
            var body4 = await response4.Content.ReadAsStringAsync();
            ViewBag.UsdToEur = body4.Substring(0, 6);
         }
         #endregion

         return View();
		}
	}
}

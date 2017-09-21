async void DoLogin(string username, string pass)
{
	using (var client = new HttpClient())
	{
		var values = new Dictionary<string, string> {
			{ "username", username },
			{ "password", pass },
		};

		var content = new FormUrlEncodedContent(values);
		var response = await client.PostAsync("http://www.roblox.com/Login", content);
		var responseString = await response.Content.ReadAsStringAsync();
    }
}

 async void LoginBot(string user, string password)
{
	HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://www.roblox.com");
	request.CookieContainer = new CookieContainer();

	if (request.CookieContainer.GetCookies("http://www.roblox.com") == null || request.CookieContainer.GetCookies("http://www.roblox.com")[0].Expired == true)
	{
		DoLogin(user, password);

		request.Method = "POST";

		HttpWebResponse resp = (HttpWebResponse)await request.GetResponseAsync();
		foreach (Cookie cookie in resp.Cookies)
		{
			if (cookie.Name.ToString() == ".ROBLOSECURITY")
			{
				request.CookieContainer.Add(new Uri("http://www.roblox.com"), new Cookie("SecurityCookie", cookie.Value));
			};
		}

		var cookie = request.CookieContainer.GetCookies("http://www.roblox.com")["SecurityCookie"];
		request.Headers["Cookie"] = ".ROBLOSECURITY=" + cookie.Value;

		} 
	else if (requets.CookieContainer.GetCookie("http://www.roblox.com") != null || request.CookieContainer.GetCookies("http://www.roblox.com")[0].Expired == false)
	{
		request.Method = "POST";

		var cookie = request.CookieContainer.GetCookies("http://www.roblox.com")["SecurityCookie"];
		request.Headers["Cookie"] = ".ROBLOSECURITY=" + cookie.Value;
	}
}

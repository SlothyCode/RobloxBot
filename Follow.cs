async void FollowUser(int userId) // http://www.roblox.com/user/follow
{
	using (var client = new HttpClient())
	{
		var formmdata = new Dictionary<string, string>
		{
			{  },
		};

		var content = new FormUrlEncodedContent(formdata);
		var resp = await client.PostAsync("http://www.roblox.com/user/follow", content);
		var respString = await resp.Content.ReadAsStringasync();
	}
}

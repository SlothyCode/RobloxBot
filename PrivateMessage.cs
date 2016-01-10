async void PM(int recipient, string subject, string body)
{
    LoginBot("accountname", "accountpassword");
    using (var client = new HttpClient())
    {
        var message_details = new Dictionary<string, string>
        {
            { "subject", subject },
            { "body", body },
            { "recipientId", recipient.ToString() },
            { "cacheBuster", DateTime.Now.ToString("HH:mm:ss") },
        };

        var content = new FormUrlEncodedContent(message_details);
        var response = await client.PostAsync("http://www.roblox.com/messages/send/", content);
        var responseString = await response.Content.ReadAsStringAsync();
    }
}

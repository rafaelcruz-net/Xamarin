using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GitHubApi
{
	public class GitHubApi
	{
		private const string GitHubUserRepositoryUrl = "https://api.github.com/users/{0}/repos";


		public async Task<List<string>> GetUserRepository(String user)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Add("User-Agent", "Others");

			var response = await client.GetAsync(String.Format(GitHubUserRepositoryUrl, user));
			var content = response.Content.ReadAsStringAsync().Result;

			var json = JArray.Parse(content);

			var result = new List<String>();
			foreach (var item in json)
				result.Add(item.Value<String>("full_name"));
				           
			return result;
		}
	}
}


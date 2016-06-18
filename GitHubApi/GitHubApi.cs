using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace GitHubApi
{
	public class GitHubApi
	{
		private const string GitHubUserRepositoryUrl = "https://api.github.com/users/{0}/repos";


		public async Task<List<string>> GetUserRepository(String user)
		{
			var client = new HttpClient();
			var response = await client.GetAsync(String.Format(GitHubUserRepositoryUrl, user));
			var json = response.Content.ReadAsStringAsync().Result;

			var result = JsonConvert.DeserializeObject<List<String>>(json);

			return result;
		}
	}
}


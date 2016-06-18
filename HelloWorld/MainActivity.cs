using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloWorld
{
	[Activity(Label = "HelloWorld", MainLauncher = true )]
	public class MainActivity : Activity
	{
		protected int count = 0;

		protected GitHubApi.GitHubApi api = new GitHubApi.GitHubApi(); 

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button helloWordBnt = FindViewById<Button>(Resource.Id.BtnClick);



			helloWordBnt.Click +=  async (object sender, System.EventArgs e) =>
			{
				var repositories = await api.GetUserRepository("rafaelcruz-net");

				System.Diagnostics.Trace.WriteLine(repositories);

			};

		}
	}
}



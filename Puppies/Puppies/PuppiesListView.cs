using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace Puppies
{
	public class PuppiesListView : ContentPage
	{
		ListView myListview;

		public PuppiesListView ()
		{
			//SAMPLE DATA
			var dog1 = new Dog {
				Id = "5",
				Name = "Oliver",
				FurColor = "Black"
			};

			List<Dog> myListDog = new List<Dog> () { dog1, dog1, dog1 };

			//LABEL
			Label myLabel = new Label ();
			myLabel.Text = "Puppies";

			//LISTVIEW
			myListview = new ListView ();

			var template = new DataTemplate (typeof (TextCell));
			template.SetBinding (TextCell.TextProperty, "Name");
			template.SetBinding (TextCell.DetailProperty, "FurColor");

			myListview.ItemTemplate = template;

			//LOCAL DATA 1
			//myListview.ItemsSource = myListDog;

			//method 1
			Device.BeginInvokeOnMainThread (async () => {
				var didTapYes = await DisplayAlert ("Tap yes or no", "", "Yes", "No");

				if (didTapYes)
					//do somehing

			});

			//method 2
			var goodies2 = await CosmosDBService.GetDogByIdAsync ("1");
			Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);

			//method 3
			//GET ONE ID
			var goodies = CosmosDBService.GetDogByIdAsync ("1");
			myListview.ItemsSource = goodies.Result;


			//method 4 - part 1
			UpdateListViewItemSource ();
			//Task.Run (async () => await UpdateListViewItemSourceAsync ());

			//method 5 - part 1
			Task.Run (async () => await UpdateListViewItemSourceAsync ());




			this.Title = "Puppies";

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
						myListview
					}
			};
		}

		//method 4 - part 2
		void UpdateListViewItemSource ()
		{
			Task.Run (async () => await UpdateListViewItemSourceAsync ());
		}

		//method 5 - part 2 (and method 4 - part 3)
		async Task UpdateListViewItemSourceAsync ()
		{
			var goodies2 = await CosmosDBService.GetDogByIdAsync ("1");

			Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);
		}
	}
}

using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;
using System.Linq;

namespace Puppies
{
	public class PuppiesListView : ContentPage
	{
		ListView myListview;



		public PuppiesListView ()
		{
			System.Random random = new Random ();
			string randomNumber = string.Join (string.Empty, Enumerable.Range (0, 10).Select (number => random.Next (0, 5).ToString ()));





			//SAMPLE DATA

			var dogRandom = new Dog {
				Id = randomNumber,
				Name = "Oliver",
				FurColor = "Black"
			};


			var dog5 = new Dog {
				Id = "5",
				Name = "Oliver",
				FurColor = "Black"
			};


			var dog1 = new Dog {
				Id = "1",
				Name = "Oliver",
				FurColor = "Black"
			};


			var dog1Replace = new Dog {
				Id = "1",
				Name = "New-Oliver",
				FurColor = "New-Black"
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


			////////////////////////
			// LOCAL DATA
			////////////////////////
			//
			//LOCAL DATA 1
			//myListview.ItemsSource = myListDog;
			//
			//method 0
			//Device.BeginInvokeOnMainThread (async () => {
			//	var didTapYes = await DisplayAlert ("Tap yes or no", "", "Yes", "No");
			//	if (didTapYes)
			//		//do somehing
			//});


			////////////////////////
			// GET
			////////////////////////
			//
			////method 1
			////GET ONE ID
			//var goodies = CosmosDBService.GetDogByIdAsync ("1");
			//myListview.ItemsSource = goodies.Result;

			//method 2
			//var goodies2 = Task.Run(async () => await CosmosDBService.GetDogByIdAsync ("1")).Result;
			//Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);

			//method 3 - part 1 //this isn't good because you don't know it is async/await
			//UpdateListViewItemSource ();

			//method 4 - part 1
			//Task.Run (async () => await UpdateListViewItemSourceAsync ());

			////////////////////////
			// POST with single Item Get
			////////////////////////
			/// 
			/// 
			/// 
			//Method 1
			//Task.Run (async () => await CosmosDBService.PostDogAsync (dog1));
			////Method 2
			//CosmosDBService.PostDogAsync (dog1);
			////
			////use this in the Post
			//var goodies2 = Task.Run (async () => await CosmosDBService.GetDogByIdAsync ("1")).Result;
			//Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);


			////////////////////////
			// PUT
			////////////////////////
			/// 
			/// 
			///
			///
			//Method 1
			//Task.Run (async () => await CosmosDBService.PutDogAsync (dog1Replace));
			//var goodies2 = Task.Run (async () => await CosmosDBService.GetDogByIdAsync ("1")).Result;
			//Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);


			////////////////////////
			// DELETE
			////////////////////////
			/// 
			/// 
			///
			///
			//Method 1
			//Task.Run (async () => await CosmosDBService.DeleteDogAsync (dog1));
			//var goodies2 = Task.Run (async () => await CosmosDBService.GetDogByIdAsync ("1")).Result;
			//Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);

			////////////////////////
			// GET ALL
			////////////////////////
			/// 
			/// 
			///
			///
			//Method 1
			//Task.Run (async () => await CosmosDBService.GetAllDogs());
			var goodies2 = Task.Run (async () => await CosmosDBService.GetAllDogs()).Result;
			Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);


			this.Title = "Puppies";
			//
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
						myListview
					}
			};
		}

		//method 3 - part 2
		//void UpdateListViewItemSource ()
		//{
		//	Task.Run (async () => await UpdateListViewItemSourceAsync ());
		//}

		//method 4 - part 2 (and method 3 - part 3)
		//async Task UpdateListViewItemSourceAsync ()
		//{
		//	var goodies2 = await CosmosDBService.GetDogByIdAsync ("1");
		//	Device.BeginInvokeOnMainThread (() => myListview.ItemsSource = goodies2);
		//}
	}
}

using System;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using System.Diagnostics;
using Microsoft.Azure.Documents.Linq;

namespace Puppies
{
	public static class CosmosDBService
	{
		//RELEVANT URLS
		static readonly String myEndPoint = "";
		static readonly String myKey = "";

		//CLIENT
		static readonly DocumentClient myDocumentClient = new DocumentClient (new Uri (myEndPoint), myKey);

		//DBS - Collections - Documents
		static readonly string DatabaseId = "Xamarin";
		static readonly string CollectionId = "Dog";


		public static List<Dog> MyListOfDogs;

		//GETALL
		public static async Task<List<Dog>> GetAllDogs ()
		{
			MyListOfDogs = new List<Dog> ();
			try {

				var query = myDocumentClient.CreateDocumentQuery<Dog> (UriFactory.CreateDocumentCollectionUri (DatabaseId, CollectionId))
				                            .AsDocumentQuery ();
				while (query.HasMoreResults) {
					MyListOfDogs.AddRange (await query.ExecuteNextAsync<Dog> ());
				}
			} catch (DocumentClientException ex) {
				Debug.WriteLine ("Error: ", ex.Message);
			}
			return MyListOfDogs;
		}
	

	//GET
	public static async Task<List<Dog>> GetDogByIdAsync (string id)
	{
		var result = await myDocumentClient.ReadDocumentAsync<Dog> (UriFactory.CreateDocumentUri (DatabaseId, CollectionId, id));

		if (result.StatusCode != System.Net.HttpStatusCode.OK) {
			return null;
		}

		List<Dog> returnedListDog = new List<Dog> ();
		returnedListDog.Add (result);

		return returnedListDog;

	}

	//POST
	public static async Task PostDogAsync (Dog dog)
	{
		await myDocumentClient.CreateDocumentAsync (UriFactory.CreateDocumentCollectionUri (DatabaseId, CollectionId), dog);

	}

	//PUT
	public static async Task PutDogAsync (Dog dog2)
	{
		await myDocumentClient.ReplaceDocumentAsync (UriFactory.CreateDocumentUri (DatabaseId, CollectionId, dog2.Id), dog2);

	}

	//DELETE
	public static async Task DeleteDogAsync (Dog deleteDog)
	{
		await myDocumentClient.DeleteDocumentAsync (UriFactory.CreateDocumentUri (DatabaseId, CollectionId, deleteDog.Id));

	}

}
}

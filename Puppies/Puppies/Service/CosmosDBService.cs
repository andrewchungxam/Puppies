using System;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;
using System.Collections.Generic;

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

		//GETALL


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

		//PUT

		//DELETE

	}
}

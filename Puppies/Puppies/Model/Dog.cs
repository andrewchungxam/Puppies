﻿using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Puppies
{
	public class Dog
	{
		[JsonProperty(PropertyName="id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set;}

		[JsonProperty(PropertyName = "furColor")]
		public string FurColor { get; set;}

	}
}

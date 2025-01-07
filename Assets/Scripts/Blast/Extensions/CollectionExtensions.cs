
using System.Collections.Generic;
using UnityEngine;

namespace Blast.Extensions
{
	public static class CollectionExtensions
	{
		public static T GetRandom<T>(this IList<T> collection)
		{
			var rndIndex = Random.Range(0, collection.Count - 1);
			return collection[rndIndex];
		}
	}
}
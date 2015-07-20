namespace Constellation.Umbraco
{
	using Constellation.Umbraco.Models;
	using global::Umbraco.Core.Models;
	using System.Collections.Generic;
	using System.Linq;

	public static class ContentCollectionExtensions
	{

		/// <summary>
		/// Given a list of content, returns the list with each member converted to the appropriate View Model.
		/// Content items with no supporting view model will be omitted from the output.
		/// </summary>
		/// <param name="list">The list to convert.</param>
		/// <returns>An array of converted content.</returns>
		public static IEnumerable<ContentViewModel> AsViewModels(this IEnumerable<IPublishedContent> list)
		{
			return list.Select(c => c.AsViewModel()).Where(x => x != null).ToArray();
		}

		/// <summary>
		/// Given a list of content, returns the list with each member converted to the provided View Model type.
		/// Content items which cannot support the selected type will be omitted from the output.
		/// </summary>
		/// <param name="list">The list to convert.</param>
		/// <returns>An array of converted content.</returns>
		public static IEnumerable<TContent> As<TContent>(this IEnumerable<IPublishedContent> list)
			where TContent : ContentViewModel
		{
			return list.Select(c => c.As<TContent>()).Where(x => x != null).ToArray();
		}
	}
}

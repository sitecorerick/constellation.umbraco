namespace Constellation.Umbraco
{
	using Constellation.Umbraco.Models;

	using global::Umbraco.Core.Models;

	public static class IPublishedContentExtensions
	{
		/// <summary>
		/// Returns a ContentViewModel based on the supplied IPublishedContent item.
		/// </summary>
		/// <param name="content">The item to transform.</param>
		/// <returns>A ViewModel or null.</returns>
		public static ContentViewModel AsViewModel(this IPublishedContent content)
		{
			return content == null ? null : ViewModelFactory.GetViewModel(content);
		}

		/// <summary>
		/// Returns a ContentViewModel of the supplied type based on the supplied IPublishedContent item.
		/// </summary>
		/// <typeparam name="TContent">The ContentViewModel type</typeparam>
		/// <param name="content">The item to transform.</param>
		/// <returns>A ViewModel or null.</returns>
		public static TContent As<TContent>(this IPublishedContent content)
			where TContent : ContentViewModel
		{
			return content == null ? null : content.AsViewModel() as TContent;
		}
	}
}

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
		public static TModel As<TModel>(this IPublishedContent content)
			where TModel : ContentViewModel
		{
			return content == null ? null : ViewModelFactory.GetViewModel<TModel>(content);
		}
	}
}

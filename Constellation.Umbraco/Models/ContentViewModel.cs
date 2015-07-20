namespace Constellation.Umbraco.Models
{
	using global::Umbraco.Core.Models;
	using global::Umbraco.Core.Models.PublishedContent;
	using System;
	using System.Collections.Generic;

	public class ContentViewModel : IPublishedContent
	{
		#region Constructors

		public ContentViewModel(IPublishedContent content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content", "ContentViewModel requires a non-null instance of IPublishedContent");
			}

			InnerContent = content;
		}
		#endregion

		#region Properties
		public IPublishedContent InnerContent { get; private set; }

		/// <summary>
		/// Gets the index of the published content within its current owning content set.
		/// </summary>
		/// <returns>
		/// The index of the published content within its current owning content set.
		/// </returns>
		public int GetIndex()
		{
			return InnerContent.GetIndex();
		}

		/// <summary>
		/// Gets a property identified by its alias.
		/// </summary>
		/// <param name="alias">The property alias.</param>
		/// <returns>
		/// The property identified by the alias.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the content type has no property with that alias, including inherited properties, returns <c>null</c>,
		/// </para>
		/// <para>
		/// otherwise return a property -- that may have no value (ie <c>HasValue</c> is <c>false</c>).
		/// </para>
		/// <para>
		/// The alias is case-insensitive.
		/// </para>
		/// </remarks>
		public IPublishedProperty GetProperty(string alias)
		{
			return InnerContent.GetProperty(alias);
		}

		/// <summary>
		/// Gets a property identified by its alias.
		/// </summary>
		/// <param name="alias">The property alias.</param><param name="recurse">A value indicating whether to navigate the tree upwards until a property with a value is found.</param>
		/// <returns>
		/// The property identified by the alias.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Navigate the tree upwards and look for a property with that alias and with a value (ie <c>HasValue</c> is <c>true</c>).
		///             If found, return the property. If no property with that alias is found, having a value or not, return <c>null</c>. Otherwise
		///             return the first property that was found with the alias but had no value (ie <c>HasValue</c> is <c>false</c>).
		/// </para>
		/// <para>
		/// The alias is case-insensitive.
		/// </para>
		/// </remarks>
		public IPublishedProperty GetProperty(string alias, bool recurse)
		{
			return InnerContent.GetProperty(alias, recurse);
		}

		public IEnumerable<IPublishedContent> ContentSet
		{
			get
			{
				return InnerContent.ContentSet;
			}
		}

		public PublishedContentType ContentType
		{
			get
			{
				return InnerContent.ContentType;
			}
		}

		public int Id
		{
			get
			{
				return InnerContent.Id;
			}
		}

		public int TemplateId
		{
			get
			{
				return InnerContent.TemplateId;
			}
		}

		public int SortOrder
		{
			get
			{
				return InnerContent.SortOrder;
			}
		}

		public string Name
		{
			get
			{
				return InnerContent.Name;
			}
		}

		public string UrlName
		{
			get
			{
				return InnerContent.UrlName;
			}
		}

		public string DocumentTypeAlias
		{
			get
			{
				return InnerContent.DocumentTypeAlias;
			}
		}

		public int DocumentTypeId
		{
			get
			{
				return InnerContent.DocumentTypeId;
			}
		}

		public string WriterName
		{
			get
			{
				return InnerContent.WriterName;
			}
		}

		public string CreatorName
		{
			get
			{
				return InnerContent.CreatorName;
			}
		}

		public int WriterId
		{
			get
			{
				return InnerContent.WriterId;
			}
		}

		public int CreatorId
		{
			get
			{
				return InnerContent.CreatorId;
			}
		}

		public string Path
		{
			get
			{
				return InnerContent.Path;
			}
		}

		public DateTime CreateDate
		{
			get
			{
				return InnerContent.CreateDate;
			}
		}

		public DateTime UpdateDate
		{
			get
			{
				return InnerContent.UpdateDate;
			}
		}

		public Guid Version
		{
			get
			{
				return InnerContent.Version;
			}
		}

		public int Level
		{
			get
			{
				return InnerContent.Level;
			}
		}

		public string Url
		{
			get
			{
				return InnerContent.Url;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the content is a content (aka a document) or a media.
		/// </summary>
		public PublishedItemType ItemType
		{
			get
			{
				return InnerContent.ItemType;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the content is draft.
		/// </summary>
		/// <remarks>
		/// A content is draft when it is the unpublished version of a content, which may
		///             have a published version, or not.
		/// </remarks>
		public bool IsDraft
		{
			get
			{
				return InnerContent.IsDraft;
			}
		}

		/// <summary>
		/// Gets the parent of the content.
		/// </summary>
		/// <remarks>
		/// The parent of root content is <c>null</c>.
		/// </remarks>
		public IPublishedContent Parent
		{
			get
			{
				return InnerContent.Parent;
			}
		}

		/// <summary>
		/// Gets the children of the content.
		/// </summary>
		/// <remarks>
		/// Children are sorted by their sortOrder.
		/// </remarks>
		public IEnumerable<IPublishedContent> Children
		{
			get
			{
				return InnerContent.Children;
			}
		}

		/// <summary>
		/// Gets the properties of the content.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Contains one <c>IPublishedProperty</c> for each property defined for the content type, including
		///             inherited properties. Some properties may have no value.
		/// </para>
		/// <para>
		/// The properties collection of an IPublishedContent instance should be read-only ie it is illegal
		///             to add properties to the collection.
		/// </para>
		/// </remarks>
		public ICollection<IPublishedProperty> Properties
		{
			get
			{
				return InnerContent.Properties;
			}
		}

		/// <summary>
		/// Gets the value of a property identified by its alias.
		/// </summary>
		/// <param name="alias">The property alias.</param>
		/// <returns>
		/// The value of the property identified by the alias.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If <c>GetProperty(alias)</c> is <c>null</c> then returns <c>null</c> else return <c>GetProperty(alias).Value</c>.
		/// </para>
		/// <para>
		/// So if the property has no value, returns the default value for that property type.
		/// </para>
		/// <para>
		/// This one is defined here really because we cannot define index extension methods, but all it should do is:
		/// <code>
		/// var p = GetProperty(alias); return p == null ? null : p.Value;
		/// </code>
		///  and nothing else.
		/// </para>
		/// <para>
		/// The recursive syntax (eg "_title") is _not_ supported here.
		/// </para>
		/// <para>
		/// The alias is case-insensitive.
		/// </para>
		/// </remarks>
		public object this[string alias]
		{
			get
			{
				return InnerContent[alias];
			}
		}

		#endregion
	}
}

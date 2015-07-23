namespace Constellation.Umbraco.Models
{
	using System;

	/// <summary>
	/// Allows a class to be labelled as representing a specific Umbraco Content Type.
	/// </summary>
	public class ContentTypeAttribute : Attribute
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of  the <see cref="ContentTypeAttribute"/> class.
		/// </summary>
		/// <param name="aliasName"></param>
		public ContentTypeAttribute(string aliasName)
		{
			AliasName = aliasName;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the Umbraco content type name for this instance.
		/// </summary>
		public string AliasName { get; set; }
		#endregion
	}
}

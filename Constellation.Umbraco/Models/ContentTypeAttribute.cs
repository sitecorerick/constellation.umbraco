namespace Constellation.Umbraco.Models
{
	/// <summary>
	/// Allows a class to be labelled as representing a specific Umbraco Content Type.
	/// </summary>
	public class ContentTypeAttribute
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of  the <see cref="ContentTypeAttribute"/> class.
		/// </summary>
		/// <param name="typeName"></param>
		public ContentTypeAttribute(string typeName)
		{
			TypeName = typeName;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the Umbraco content type name for this instance.
		/// </summary>
		public string TypeName { get; set; }
		#endregion
	}
}

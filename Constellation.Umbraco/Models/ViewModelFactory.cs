namespace Constellation.Umbraco.Models
{
	using global::Umbraco.Core.Models;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Reflection;

	internal static class ViewModelFactory
	{
		private static IDictionary<string, Type> candidateClasses;

		#region Properties

		internal static IDictionary<string, Type> CandidateClasses
		{
			get
			{
				return candidateClasses ?? (candidateClasses = CreateCandidateClassesList());
			}
		}
		#endregion


		#region Methods

		internal static TModel GetViewModel<TModel>(IPublishedContent content)
			where TModel : ContentViewModel
		{
			var model = Activator.CreateInstance(typeof(TModel), content) as TModel;

			// TODO: figure out how to handle inheritance and/or abstract classes, or Interfaces!!!

			if (model == null)
			{
				return model;
			}

			PopulateModel(model, content);

			return model;
		}

		internal static ContentViewModel GetViewModel(IPublishedContent content)
		{
			ContentViewModel model = new ContentViewModel(content);
			Type type;
			if (CandidateClasses.TryGetValue(content.DocumentTypeAlias, out type))
			{
				model = Activator.CreateInstance(type, content) as ContentViewModel;
			}

			if (model == null)
			{
				return model;
			}

			PopulateModel(model, content);

			return model;
		}

		private static void PopulateModel(ContentViewModel model, IPublishedContent content)
		{
			var type = model.GetType();
			var properties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);

			foreach (var property in type.GetProperties())
			{
				if (!property.CanWrite)
				{
					continue;
				}

				if (properties.ContainsKey(property.Name))
				{
					continue;
				}

				properties.Add(property.Name, property);
			}

			foreach (var field in content.Properties)
			{
				var property = properties[field.PropertyTypeAlias];

				if (property == null)
				{
					continue;
				}

				var fieldType = field.Value.GetType();

				if (!property.PropertyType.IsAssignableFrom(fieldType))
				{
					continue;
				}

				property.SetValue(model, field.Value);
			}
		}

		private static IDictionary<string, Type> CreateCandidateClassesList()
		{
			var list = new Dictionary<string, Type>();

			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

			foreach (Assembly assembly in assemblies)
			{
				var types = GetLoadableTypes(assembly);

				foreach (Type type in types)
				{
					if (type.IsClass)
					{
						string alias = GetContentTypeFromAttribute(type);

						if (!string.IsNullOrEmpty(alias))
						{
							list.Add(alias, type);
						}
					}
				}
			}

			return list;
		}

		private static string GetContentTypeFromAttribute(Type type)
		{
			try
			{
				// Get the TypeName property
				var attributes = type.GetCustomAttributes(typeof(ContentTypeAttribute), false);

				if (attributes.Length > 0)
				{
					var attribute = attributes[0] as ContentTypeAttribute;

					if (attribute != null && !string.IsNullOrEmpty(attribute.AliasName))
					{
						return attribute.AliasName;
					}
				}
			}
			catch
			{
				return null;
			}

			return null;
		}

		/// <summary>
		/// Inspects the provided assembly and returns only a list of types that are capable
		/// of being loaded by the current application.
		/// </summary>
		/// <remarks>
		/// See http://haacked.com/archive/2012/07/23/get-all-types-in-an-assembly.aspx for 
		/// details on why this is required.
		/// </remarks>
		/// <param name="assembly">The assembly to parse.</param>
		/// <returns>A list of loadable types.</returns>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Stylecop hates URLs.")]
		private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
		{
			try
			{
				return assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException e)
			{
				return e.Types.Where(t => t != null);
			}
		}
		#endregion
	}
}

namespace GISParser.Models.Binding
{
	#region Library Imports

	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Xml;
	using Enumerators;
	using Helpers;

	#endregion

	public class MetadataFile : ImportFile
	{
		public MetadataFile()
		{
			Attributes = new HashSet<MetadataAttribute>();
		}

		public MetadataFile(FileInfo file)
			: base(file)
		{
			Attributes = new HashSet<MetadataAttribute>();

			if (!file.Exists || !Exists)
				return;

			// TODO: Get generated class to use for processing the file to have an object to return
			//if (XMLHelper.ProcessFile(file))
			ImportFromFile(file);
		}

		public string TableName { get; set; }
		public ImportFileType ImportType { get; set; }
		public string Definition { get; set; }
		public string Source { get; set; }
		public ICollection<MetadataAttribute> Attributes { get; set; }

		public void ImportFromFile(FileInfo file)
		{
			try
			{
				XmlDocument document = new XmlDocument();
				document.Load(file.FullName);

				XmlNode entityNode = document.SelectSingleNode("metadata/eainfo/detailed/enttyp");
				XmlNode entityLabelNode = entityNode?.SelectSingleNode("enttypl");
				XmlNode entityDefinitionNode = entityNode?.SelectSingleNode("enttypd");
				XmlNode entitySourceNode = entityNode?.SelectSingleNode("enttypds");

				string label = entityLabelNode?.InnerText.Trim();
				string[] labelSplit = label?.Split('.');

				TableName = labelSplit?[0];
				ImportType = labelSplit?[1].ToLower() == "shp"
					? ImportFileType.Shape
					: labelSplit?[1].ToLower() == "dbf" ? ImportFileType.Attribute : ImportFileType.Unknown;
				Definition = entityDefinitionNode?.InnerText.Trim();
				Source = entitySourceNode?.InnerText.Trim();

				XmlNodeList attributeNodes = document.SelectNodes("metadata/eainfo/detailed/attr");

				if (attributeNodes == null || !(attributeNodes.Count > 0))
					return;

				foreach (XmlNode attributeNode in attributeNodes)
				{
					MetadataAttribute attribute = new MetadataAttribute();

					XmlNode labelNode = attributeNode.SelectSingleNode("attrlabl");
					XmlNode definitionNode = attributeNode.SelectSingleNode("attrdef");
					XmlNode sourceNode = attributeNode.SelectSingleNode("attrdefs");

					attribute.ColumnName = labelNode?.InnerText.Trim();
					attribute.Definition = definitionNode?.InnerText.Trim();
					attribute.Source = sourceNode?.InnerText.Trim();

					XmlNodeList attributeValues = attributeNode.SelectNodes("attrdomv");

					if (attributeValues == null || !(attributeValues.Count > 0))
						continue;

					foreach (XmlNode attributeValue in attributeValues)
					{
						MetadataAttributeValue value = new MetadataAttributeValue();

						XmlNode valueNode = attributeValue.SelectSingleNode("edom");
						XmlNode valueLabelNode = valueNode?.SelectSingleNode("edomv");
						XmlNode valueSourceNode = valueNode?.SelectSingleNode("edomvds");
						XmlNode valueDefinitionNode = valueNode?.SelectSingleNode("edomvd");
						XmlNode rangeNode = attributeValue?.SelectSingleNode("rdom");
						XmlNode minRangeNode = rangeNode?.SelectSingleNode("rdommin");
						XmlNode maxRangeNode = rangeNode?.SelectSingleNode("rdommax");
						XmlNode codeSetNode = attributeValue.SelectSingleNode("codesetd");
						XmlNode codeSetNameNode = codeSetNode?.SelectSingleNode("codesetn");
						XmlNode codeSetSourceNode = codeSetNode?.SelectSingleNode("codesets");
						XmlNode udomNode = attributeValue.SelectSingleNode("udom");

						value.Value = valueLabelNode?.InnerText.Trim();
						value.Source = valueSourceNode?.InnerText.Trim();
						value.Definition = valueDefinitionNode?.InnerText.Trim();
						value.MinRange = minRangeNode?.InnerText.ToNullableDecimal();
						value.MaxRange = maxRangeNode?.InnerText.ToNullableDecimal();
						value.Udom = udomNode?.InnerText.Trim();
						value.CodeSetName = codeSetNameNode?.InnerText.Trim();
						value.CodeSetSource = codeSetSourceNode?.InnerText.Trim();

						attribute.Values.Add(value);
					}
					Attributes.Add(attribute);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}
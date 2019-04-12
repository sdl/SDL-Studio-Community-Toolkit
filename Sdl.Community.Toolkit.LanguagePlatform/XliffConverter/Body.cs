﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Sdl.LanguagePlatform.Core;

namespace Sdl.Community.Toolkit.LanguagePlatform.XliffConverter
{
	public class Body
	{
		[XmlElement("trans-unit")]
		public List<TranslationUnit> TranslationUnits { get; set; }

		public Body()
		{
			TranslationUnits = new List<TranslationUnit>();
		}
		internal void Add(Segment sourceSegment)
		{
			if (sourceSegment == null)
				throw new NullReferenceException("Source segment cannot be null");

			TranslationUnits.Add(new TranslationUnit
			{
				Id = TranslationUnits.Count,
				SourceText = sourceSegment.ToXliffString(),
			});
		}

		internal void Add(Segment sourceSegment, Segment targetSegment, string toolID)
		{
			if (sourceSegment == null)
				throw new NullReferenceException("Source segment cannot be null");
			if (targetSegment == null)
				throw new NullReferenceException("Target segment cannot be null");

			TranslationUnits.Add(new TranslationUnit()
			{
				Id = TranslationUnits.Count,
				SourceText = sourceSegment.ToXliffString(),
				TranslationList = new List<TranslationOption>(){
					new TranslationOption(
						toolID,
						new TargetTranslation(targetSegment.Culture, targetSegment.ToXliffString()))
				}

			});
		}
	}
}

﻿/***************************************************************************************

	Copyright 2012 Greg Dennis

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		CharacterConverter.cs
	Namespace:		Manatee.Json.Internal
	Class Name:		CharacterConverter
	Purpose:		Maps ASCII characters to JsonInput values.

***************************************************************************************/

using System.Collections.Generic;

namespace Manatee.Json.Internal
{
	internal static class CharacterConverter
	{
		private static readonly Dictionary<char, JsonPathInput> PathConverter =
			new Dictionary<char, JsonPathInput>
			{
				{'$', JsonPathInput.Dollar},
				{'@', JsonPathInput.Current},
				{':', JsonPathInput.Colon},
				{'-', JsonPathInput.Number},
				{'0', JsonPathInput.Number},
				{'1', JsonPathInput.Number},
				{'2', JsonPathInput.Number},
				{'3', JsonPathInput.Number},
				{'4', JsonPathInput.Number},
				{'5', JsonPathInput.Number},
				{'6', JsonPathInput.Number},
				{'7', JsonPathInput.Number},
				{'8', JsonPathInput.Number},
				{'9', JsonPathInput.Number},
				{'.', JsonPathInput.Period},
				{'[', JsonPathInput.OpenBracket},
				{']', JsonPathInput.CloseBracket},
				{'(', JsonPathInput.OpenParenth},
				{',', JsonPathInput.Comma},
				{'*', JsonPathInput.Star},
				{'?', JsonPathInput.Question},
				{'_', JsonPathInput.Letter},
			};
		private static readonly Dictionary<char, JsonPathExpressionInput> ExpressionConverter =
			new Dictionary<char, JsonPathExpressionInput>
				{
					{'(', JsonPathExpressionInput.OpenParenth},
					{')', JsonPathExpressionInput.CloseParenth},
					{'0', JsonPathExpressionInput.Number},
					{'1', JsonPathExpressionInput.Number},
					{'2', JsonPathExpressionInput.Number},
					{'3', JsonPathExpressionInput.Number},
					{'4', JsonPathExpressionInput.Number},
					{'5', JsonPathExpressionInput.Number},
					{'6', JsonPathExpressionInput.Number},
					{'7', JsonPathExpressionInput.Number},
					{'8', JsonPathExpressionInput.Number},
					{'9', JsonPathExpressionInput.Number},
					{'.', JsonPathExpressionInput.Number},
					{'+', JsonPathExpressionInput.Plus},
					{'-', JsonPathExpressionInput.Minus},
					{'*', JsonPathExpressionInput.Star},
					{'/', JsonPathExpressionInput.Slash},
					{'^', JsonPathExpressionInput.Caret},
					{'$', JsonPathExpressionInput.Root},
					{'@', JsonPathExpressionInput.Current},
					{'<', JsonPathExpressionInput.LessThan},
					{'=', JsonPathExpressionInput.Equal},
					{'>', JsonPathExpressionInput.GreaterThan},
					{'!', JsonPathExpressionInput.Bang},
					{'"', JsonPathExpressionInput.Quote},
					{'t', JsonPathExpressionInput.Letter},
					{'T', JsonPathExpressionInput.Letter},
					{'f', JsonPathExpressionInput.Letter},
					{'F', JsonPathExpressionInput.Letter},
					{'n', JsonPathExpressionInput.Letter},
					{'N', JsonPathExpressionInput.Letter},
					{'&', JsonPathExpressionInput.And},
					{'|', JsonPathExpressionInput.Or},
				};

		public static JsonPathInput PathItem(char key)
		{
			return char.IsLetter(key)
					   ? JsonPathInput.Letter
					   : PathConverter.ContainsKey(key)
							 ? PathConverter[key]
							 : JsonPathInput.End;
		}
		public static JsonPathExpressionInput ExpressionItem(char key)
		{
			return ExpressionConverter[key];
		}
	}
}
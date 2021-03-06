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
 
	File Name:		JsonCompatibleClass.cs
	Namespace:		Manatee.Tests.Test_References
	Class Name:		JsonCompatibleClass
	Purpose:		Basic class that implements IJsonCompatible to be used in
					testing the Manatee.Json library.

***************************************************************************************/

using Manatee.Json.Serialization;

namespace Manatee.Json.Tests.Test_References
{
	public class JsonSerializableClass : IJsonSerializable
	{
		public string StringProp { get; private set; }
		public int IntProp { get; private set; }

		public JsonSerializableClass() { }
		public JsonSerializableClass(string s, int i)
		{
			StringProp = s;
			IntProp = i;
		}

		#region Implementation of IJsonSerializable

		public void FromJson(JsonValue json, JsonSerializer serializer)
		{
			StringProp = json.Object["StringProp"].String;
			IntProp = (int)json.Object["IntProp"].Number;
		}

		public JsonValue ToJson(JsonSerializer serializer)
		{
			return new JsonObject
				{
					{"StringProp", StringProp},
					{"IntProp", IntProp}
				};
		}

		#endregion

		public override bool Equals(object obj)
		{
			if (obj is JsonSerializableClass) return Equals((JsonSerializableClass)obj);
			return base.Equals(obj);
		}

		public bool Equals(JsonSerializableClass other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.StringProp, StringProp) && other.IntProp == IntProp;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((StringProp != null ? StringProp.GetHashCode() : 0) * 397) ^ IntProp;
			}
		}
	}
}
/*
Copyright 2010 Google Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.IO;
using System.Collections.Generic;

namespace Google.Apis.Discovery
{
    /// <summary>
    /// Implementors of this interface are able to execute arbitory requests against a service given the 
    /// resource, method, body and parameters
    /// </summary>
    public interface IRequestExecutor
    {
        /// <summary>
        /// Executes a request with the specified parameters
        /// </summary>
        Stream ExecuteRequest(string resource, string method, string body, IDictionary<string, object> parameters);
    }

    /// <summary>
    /// Implementors of this interface are able to execute arbitory requests against a service given the 
    /// resource, method, body and parameters. Aswell as serilising and deserilising Json => objects
    /// and visa versa.
    /// </summary>
    public interface ISchemaAwareRequestExecutor : IRequestExecutor
    {
        /// <summary>
        /// Serializes an object into a json representation
        /// </summary>
        string ObjectToJson(object obj);

        /// <summary>
        /// Deserializes a json document into the specified class
        /// </summary>
        TOutput JsonToObject<TOutput>(Stream stream);
    }
}
﻿using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Crypto
{
    public static class RsaExtensions
    {
        public static string ToJson(
            this RSACryptoServiceProvider rsa,
            bool includePrivateParameters)
        {
            var parameters = rsa.ExportParameters(includePrivateParameters);

            return JsonConvert.SerializeObject(parameters, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static void FromJson(
            this RSACryptoServiceProvider rsa,
            string json)
        {
            var parameters = JsonConvert.DeserializeObject<RSAParameters>(json);

            rsa.ImportParameters(parameters);
        }
    }
}

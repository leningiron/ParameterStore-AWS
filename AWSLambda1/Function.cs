using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using AwsParameterStore;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda1
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            AwsParameterStoreClient client = new AwsParameterStoreClient(Amazon.RegionEndpoint.USEast1);
            try
            {
                var value = await client.GetValueAsync("KeyTest");

                context.Logger.Log(value);


            }
            catch (Exception ex)
            {

                context.Logger.Log(ex.Message);
            }


            return input?.ToUpper();
        }
    }
}

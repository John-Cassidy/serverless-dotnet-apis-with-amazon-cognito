using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System.Net;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DOTNETAnonymousExample;

public class Function
{
    public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest apigProxyEvent, ILambdaContext context) {

        var sampleResponse = new { Name = "Frank Rizzo", Country = "Philadelphia" };

        return new APIGatewayProxyResponse {
            StatusCode = (int)HttpStatusCode.OK,
            Body = JsonSerializer.Serialize(sampleResponse)
        };
    }
}

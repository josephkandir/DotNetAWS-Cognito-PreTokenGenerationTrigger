using Amazon.Lambda.CognitoEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DotNetAWS.Cognito.PreTokenGenerateTrigger;

public class Function
{
    public CognitoPreTokenGenerationEvent FunctionHandler(CognitoPreTokenGenerationEvent cognitoEvent, ILambdaContext context)
    {
        context.Logger.LogInformation("Processing Pre-Token Generation Trigger");

        // Add or override custom claims
        var claimsToOverride = new Dictionary<string, string>
        {
            // key should be in the format "custom:claim_name"
            //{ "custom:claim_name", "claim_value" },
            { "custom:roles", "role_a,role_b" }
        };

        cognitoEvent.Response = new CognitoPreTokenGenerationResponse
        {
            ClaimsOverrideDetails = new ClaimOverrideDetails
            {
                ClaimsToAddOrOverride = claimsToOverride
            }
        };

        context.Logger.LogInformation("Processing Pre-Token Generation Trigger processing complete.");

        return cognitoEvent;
    }
}
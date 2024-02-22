using Microsoft.AspNetCore.Authorization;

namespace ASPNETCustomScopesAuthorizationExample.CognitoHelpers;

public class CognitoScopeAuthorizationRequirement : IAuthorizationRequirement {
    public string[] RequiredScopes { get; private set; }

    public CognitoScopeAuthorizationRequirement(string[] requiredScopes) {
        RequiredScopes = requiredScopes;
    }
}

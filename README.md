# Building Serverless .NET APIs using AWS Lambda, Amazon API Gateway, and Amazon Cognito

Series of Projects based on YouTube Videos by [@coderjony9694](https://www.youtube.com/@coderjony9694/videos)

[Blog Post](https://resonant-cement-f3c.notion.site/Building-Serverless-NET-APIs-using-AWS-Lambda-Amazon-API-Gateway-and-Amazon-Cognito-08c86abd62824dd1a6928582349e7bf5)

[GitHub Repo](https://github.com/ankushjain358/serverless-dotnet-apis-with-amazon-cognito/tree/main)

AWS Tag: Name: Project, Value: serverless-dotnet-cognito-cdk

AWS Resources:

- CloudFormation Stacks

  - CdkStack
  - CDKToolkit

- Lambda Functions

  - aspnet-core-apis\ASPNETAnonymousExample
  - aspnet-core-apis\ASPNETAuthenticationExample
  - aspnet-core-apis\ASPNETAuthorizationExample
  - aspnet-core-apis\ASPNETCustomScopesAuthorizationExample
  - dotnet-core-apis\DOTNETAnonymousExample (Function Only)
  - dotnet-core-apis\DOTNETAuthorizationExample (Function Only)

- Lambda Role (ServerlessDotnetAPILambdaFunction)

Cognito User Pool: Create Cognito user pool

- Pool Name: dotnet-userpool
- log in with: email
- standard password policy

```text
Password minimum length
8 character(s)
Password requirements
Contains at least 1 number
Contains at least 1 special character
Contains at least 1 uppercase letter
Contains at least 1 lowercase letter
Temporary passwords set by administrators expire in
7 day(s)
```

- No MFA
- User account recovery:

  - Enable self-service account recovery - Recommended
  - Email only - Delivery method for user account recovery messages

- Enable self registration
- Required Attributes:

  - given_name: first name
  - family_name: last name
  - address

- Use the Cognito Hosted UI (SEE thunder-environment.json for Cognito Domain URL)
- App client name: `web`
- Generate a client secret
- Allowed callback URLs: https://www.thunderclient.com/oauth/callback

API Gateway: Name = DotnetServerlessAPI - dotnet-rest-api

- dotnet-rest-api

  - /aspnet

    - /anonymous-example -- {proxy+} Create Method ANY
    - /authentication-example

      - {proxy+}
      - Create Method ANY
      - on ANY 'Method Request' add Authorizer

    - /authorization-example -- {proxy+}

      - {proxy+}
      - Create Method ANY
      - on ANY 'Method Request' add Authorizer

    - /custom-scopes-authorization-example -- {proxy+}

  - /dotnet

    - /anonymous-example -- {proxy+}
    - /authorization-example -- {proxy+}

- Create Authorizier in API Gateway for authentication paths

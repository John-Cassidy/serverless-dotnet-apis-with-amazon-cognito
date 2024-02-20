# Building Serverless .NET APIs using AWS Lambda, Amazon API Gateway, and Amazon Cognito

Series of Projects based on YouTube Videos by [@coderjony9694](https://www.youtube.com/@coderjony9694/videos)

[Blog Post](https://resonant-cement-f3c.notion.site/Building-Serverless-NET-APIs-using-AWS-Lambda-Amazon-API-Gateway-and-Amazon-Cognito-08c86abd62824dd1a6928582349e7bf5)

[GitHub Repo](https://github.com/ankushjain358/serverless-dotnet-apis-with-amazon-cognito/tree/main)

AWS Tag: Name-Project, Value-serverless-dotnet-cognito-cdk

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

Cognito User Pool

- dotnet-demo-userpool

API Gateway: Name = DotnetServerlessAPI - dotnet-rest-api

- dotnet-rest-api

  - /aspnet

    - /anonymous-example
    - /authentication-example
    - /authorization-example
    - /custom-scopes-authorization-example

  - /dotnet

    - /anonymous-example
    - /authorization-example

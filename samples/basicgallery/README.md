# Overview

This Power Apps Test Engine sample demonstrates how to basic gallery of a canvas application

## Usage

2. Get the Environment Id and Tenant of the environment that the solution has been imported into

3. Create config.json file using tenant, environment and user1Email

```json
{
    "environmentId": "a0000000-1111-2222-3333-444455556666",
    "tenantId": "ccccdddd-1111-2222-3333-444455556666",
    "installPlaywright": false,
    "user1Email": "test@contoso.onmicosoft.com"
}
```

4. Execute the test

```pwsh
.\RunTests.ps1
```

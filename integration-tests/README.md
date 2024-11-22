# Chat Copilot Integration Tests

## Purpose of the Integration Tests

The purpose of the integration tests is to ensure that the various components of the Chat Copilot work together as expected. These tests verify the functionality and interactions between different parts of the system, such as the backend API, memory pipeline, and plugins.

## Requirements

1. A running instance of the Chat Copilot's [backend](../webapi/README.md).

## Setup and Configuration Instructions

### Option 1: Use Secret Manager

Integration tests require the URL of the backend instance.

We suggest using the .NET [Secret Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
to avoid the risk of leaking secrets into the repository, branches and pull requests.

Values set using the Secret Manager will override the settings set in the `testsettings.development.json` file and in environment variables.

To set your secrets with Secret Manager:

```ps
cd integration-tests

dotnet user-secrets init
dotnet user-secrets set "BaseUrl" "https://your-backend-address/"
```

### Option 2: Use a Configuration File

1. Create a `testsettings.development.json` file next to `testsettings.json`. This file will be ignored by git,
   the content will not end up in pull requests, so it's safe for personal settings. Keep the file safe.
2. Edit `testsettings.development.json` and
    1. Set your base address - **make sure it ends with a trailing '/' **

For example:

```json
{
  "BaseUrl": "https://localhost:40443/"
}
```

### Option 3: Use Environment Variables
You may also set the test settings in your environment variables. The environment variables will override the settings in the `testsettings.development.json` file.

- bash:

```bash
export BaseUrl="https://localhost:40443/"
```

- PowerShell:

```ps
$env:BaseUrl = "https://localhost:40443/"
```

## Usage Instructions

1. Ensure that the Chat Copilot's backend is running.
2. Configure the integration tests using one of the setup options described above.
3. Run the integration tests using the following command:

```ps
dotnet test
```

## Contribution Guidelines

We welcome your contributions and suggestions to the Chat Copilot Integration Tests! One of the easiest
ways to participate is to engage in discussions in the GitHub repository.
Bug reports and fixes are welcome!

To learn more and get started:

- Read the [documentation](https://learn.microsoft.com/semantic-kernel/chat-copilot/)
- Join the [Discord community](https://aka.ms/SKDiscord)
- [Contribute](CONTRIBUTING.md) to the project
- Follow the team on our [blog](https://aka.ms/sk/blog)

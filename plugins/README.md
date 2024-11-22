# Plugins

> **IMPORTANT:** This sample is for educational purposes only and is not recommended for production deployments.

Plugins are cool! They allow Chat Copilot to talk to the internet. Read more about plugins here [Understanding AI plugins in Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/ai-orchestration/plugins/?tabs=Csharp) and here [ChatGPT Plugins](https://platform.openai.com/docs/plugins/introduction).

## Purpose of the Plugins

The purpose of the plugins is to extend the functionality of the Chat Copilot by allowing it to interact with external services and APIs. Plugins enable the Chat Copilot to perform tasks such as web searches, data retrieval, and more.

## Available Plugins

> These plugins in this project can be optionally deployed with the Chat Copilot [WebApi](../webapi/README.md)

- [WebSearcher](./web-searcher/README.md): A plugin that allows the chat bot to perform Bing search.
- More to come. Stay tuned!

## Third Party plugins

You can also configure Chat Copilot to use third party plugins.

> All no-auth plugins will be supported.

> All service-level-auth and user-level-auth plugins will be supported.

> OAuth plugins will NOT be supported.

Read more about plugin authentication here: [Plugin authentication](https://platform.openai.com/docs/plugins/authentication)

## Plugin Configuration in Chat Copilot

### Prerequisites

1. The name of your plugin. This should be identical to the `NameForHuman` in your plugin manifest.
   > Please refer to OpenAI for the [manifest requirements](https://platform.openai.com/docs/plugins/getting-started/plugin-manifest).
2. Url of your plugin.
   > This should be the root url to your API. Not the manifest url nor the OpenAPI spec url.
3. (Optional) Key of the plugin if it requires one.

### Local dev

In `appsettings.json` or `appsettings.development.json` under `../webapi/`, add your plugin to the existing **Plugins** list with the required information.

### Deployment

1. Go to your webapi resource in Azure portal.
2. Go to **Configuration** -> **Application settings**.
3. Look for Plugins:[*index*]:\* in the names that has the largest index.
4. Add the following names and their corresponding values:

```
Plugins[*index+1*]:Name
Plugins[*index+1*]:Url
Plugins[*index+1*]:Key (only if the plugin requires it)
```

## Usage Instructions

1. Ensure that the Chat Copilot's backend web API is running.
2. Configure the plugins by following the instructions in the [Plugin Configuration in Chat Copilot](#plugin-configuration-in-chat-copilot) section above.
3. Interact with the Chat Copilot using the chat interface and utilize the available plugins for extended functionality.

## Contribution Guidelines

We welcome your contributions and suggestions to the Chat Copilot Plugins! One of the easiest
ways to participate is to engage in discussions in the GitHub repository.
Bug reports and fixes are welcome!

To learn more and get started:

- Read the [documentation](https://learn.microsoft.com/semantic-kernel/chat-copilot/)
- Join the [Discord community](https://aka.ms/SKDiscord)
- [Contribute](CONTRIBUTING.md) to the project
- Follow the team on our [blog](https://aka.ms/sk/blog)

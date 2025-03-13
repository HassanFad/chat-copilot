# Chat Copilot front end web application

This directory contains the source code for Chat Copilot's frontend web application. The backend web API service component can be found in the [webapi/](../webapi/) directory.

## Running the Chat Copilot sample
To configure and run the full Chat Copilot application, please view the [main instructions](../README.md#instructions).

# (Under Development)
The following material is under development and may not be complete or accurate.

## How to use HTTPS for local development

If you want to run Copilot Chat with HTTPS, you need to create a certificate and sign it with a Certificate Authority (CA) that is trusted locally by your device and browser. You have a couple of options on how to do this:

1. (Recommended) Reusuing the [dotnet dev-certs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs) generated for the webapi app

    > Note: the `dotnet dev-certs` command does not have a built-in option to generate a certificate for a specific IP address. It only generates a cert for `localhost`. If you need to use a specific IP address, use one of the two options below.

2. [mkcert](https://github.com/FiloSottile/mkcert#installation): a simple tool for making locally-trusted development certificates; requires no configuration
3. [Azure KeyVault certificates](https://learn.microsoft.com/en-us/azure/key-vault/certificates/certificate-scenarios): you'll need to create the certificate in Key Vault using [Portal](https://learn.microsoft.com/en-us/azure/key-vault/certificates/quick-create-portal), [Azure CLI](https://learn.microsoft.com/en-us/azure/key-vault/certificates/quick-create-cli), or [Azure PowerShell](https://learn.microsoft.com/en-us/azure/key-vault/certificates/quick-create-powershell) and then download the cert and key files to use in step 2.

### Step 1: Creating the certificate

Option 1: Reusuing the [dotnet dev-certs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs) generated for the webapi app.

1. Open a terminal and navigate to `webapi`.
1. Run

    ```
    dotnet dev-certs https -ep ../webapp/local-cert.crt --no-password --trust --format PEM
    ```

    This will create a certificate for `localhost`, trust it, and export it to a PEM file including the private key.

    > Note: The `--no-password` flag specifies that a password will not be used for the key on export. This is intended for testing use only.

1. The certificate and key are now exported as a pair of files in PEM format at the root of this directory (/webapp):
    - local-cert.crt
    - local-cert.key

Option 2: Using [mkcert](https://github.com/FiloSottile/mkcert#installation)

1. From an elevated shell, run

    ### Windows

    On Windows, use [Chocolatey](https://chocolatey.org/)

    ```
    choco install mkcert
    ```

    ### MacOS

    On macOS, use [Homebrew](https://brew.sh/)

    ```
    brew install mkcert
    ```

    For installation on Linux, other operating systems, and advanced topics (e.g., supported root stores), see the [official mkcert installation guide](https://github.com/FiloSottile/mkcert#installation).

1. Create a new local certificate authority (CA) by running
    ```
    mkcert -install
    ```
1. Create a new certificate with all hostnames you wish to run the app on.

    > It is recommend you do this at the /webapp directory level.

    Run

    ```
    mkcert localhost 127.0.0.1 example.test
    ```

    You should see an output that looks like this:

    ```
    Created a new certificate valid for the following names 📜
        - "localhost"
        - "127.0.0.1"
        - "example.test"

    The certificate is at "./localhost+1.pem" and the key at "./localhost+1-key.pem" ✅

    It will expire on 1 September 2025
    ```

    > **Warning**: (from the developers of mkcert) the rootCA-key.pem file that mkcert automatically generates gives complete power to intercept secure requests from your machine. Do not share it.

### Step 2: Configuring Copilot Chat to use the certificate

1. In the webapp `.env` file, uncomment the following lines and populate with your respective certificate and key files generated in the step above.
    ```
    ...
    # To enable HTTPS, uncomment the following lines
    HTTPS="true"
    # Replace with your locally-trusted cert file
    SSL_CRT_FILE=local-cert.crt
    # Replace with your locally-trusted cert key
    SSL_KEY_FILE=local-cert.key
    ```
1. In the [webapi appsettings.json](../webapi/appsettings.json) file, find the `"AllowedOrigins"` section, and add the URLs (with ports!) that you'll be running the apps on with `https` prefixed. For instance, the `"AllowedOrigins"` section should look something like:
    ```
    ...
    // CORS
    "AllowedOrigins": [
        "http://localhost:3000",
        "https://localhost:3000",
        "https://127.0.0.1:3000",
    ],
    ...
    ```
1. Add the same URLs (with ports!) as single-page application (SPA) redirect URIs to your Azure Active Directory (AAD) application registration. This can be done in the [Azure Portal](https://portal.azure.com).
1. Restart the `webapi` and `webapp` - Copilot Chat should be now running locally with HTTPS.

## Authentication

This sample uses the Microsoft Authentication Library (MSAL) for React to authenticate users.
Learn more about it here: https://learn.microsoft.com/en-us/azure/active-directory/develop/quickstart-single-page-app-react-sign-in.

## Debug the web app

Aside from debugging within browsers, you can launch a debug session in Visual Studio.

1. Open the webapp folder (i.e.`webapp/`) in Visual Studio Code.
2. Go to "Run and Debug" and select on the "Launch Edge against localhost".
    > Go [here](https://code.visualstudio.com/docs/typescript/typescript-debugging) to learn more about debugging client-code in Visual Studio Code.

## Serve a production build

By default, we run the app using `yarn start`, which starts a local development server. This enables some additional development behaviors and debuggings features, such as `React.StrictMode`, which will render the app twice to find bugs caused by impure rendering.

If you want to serve a production build of the `webapp` (as static files) without any development-specific features,

1. Run

    ```
    yarn build
    ```

    This will generate an optimized and minified production-ready build of the app in the `/build` directory.

2. Once the build is complete, and you have the `/build` directory, run

    ```
    yarn serve
    ```

    This will start the server and serve the production build. You should see an output similar to:

    ```
    Serving!
    - Local:    http://localhost:3000
    - Network:  http://192.168.0.100:3000
    ```

## Directory Structure

### `webapp` Directory

The `webapp` directory contains the source code for the Chat Copilot's frontend web application. It includes the following key components:

- `package.json`: Defines the project's dependencies, scripts, and other configurations.
- `README.md`: Provides instructions on running the Chat Copilot frontend application and configuring HTTPS for local development.
- `src`: Contains the main source code, including components, hooks, models, services, and styles.

### `webapp/src` Directory

The `webapp/src` directory contains the main source code for the Chat Copilot frontend application. It includes the following key components:

- `components`: Contains various React components for the chat interface, such as `ChatInput`, `ChatRoom`, `ChatList`, and more.
- `libs`: Contains utility functions, hooks, and services used throughout the application.
- `redux`: Manages the application's state using Redux.
- `App.tsx`: Structures the application by defining the main components and their interactions.
- `index.tsx`: Initializes the application and sets up the Redux store and authentication.

### `webapp/src/components` Directory

The `webapp/src/components` directory includes various React components for the chat interface. Some of the key components are:

- `ChatInput.tsx`: Defines the chat input component.
- `ChatRoom.tsx`: Defines the chat room component, including chat history and input.
- `ChatList.tsx`: Defines the chat list component, including filtering and sorting conversations.
- `ChatWindow.tsx`: Defines the chat window component, including tabs for chat, documents, plans, and persona.
- `views`: Contains components for different views, such as `ChatView.tsx`, which defines the main chat view, including the chat list and chat window.

### `webapp/src/libs` Directory

The `webapp/src/libs` directory contains utility functions, hooks, and services used throughout the application. Some of the key components are:

- `hooks`: Contains custom hooks, such as `useChat.ts`, which defines the `useChat` hook for managing chat-related functionality.
- `auth`: Contains helper functions for authentication, such as `AuthHelper.ts`.
- `models`: Contains TypeScript interfaces and models used throughout the application, such as `ChatMessage.ts`, `ChatSession.ts`, `ChatUser.ts`, `ServiceInfo.ts`, and `TokenUsage.ts`.
- `services`: Contains services for making API requests, such as `BaseService.ts`, `ChatArchiveService.ts`, `ChatService.ts`, `DocumentImportService.ts`, `GraphService.ts`, `MaintenanceService.ts`, `PluginService.ts`, and `SpeechService.ts`.
- `semantic-kernel`: Contains models related to the semantic kernel, such as `Ask.ts`, `AskResult.ts`, `CustomPlugin.ts`, and `KeyConfig.ts`.
- `utils`: Contains utility functions, such as `PlanUtils.ts`.

### `webapp/src/redux` Directory

The `webapp/src/redux` directory manages the application's state using Redux. Some of the key components are:

- `app`: Contains the app slice, including actions and reducers for managing the app state. Key files include `store.ts`, `rootReducer.ts`, `appSlice.ts`, and `AppState.ts`.
- `features`: Contains slices for different features of the application, such as `conversations`, `message-relay`, `plugins`, and `users`. Key files include `ChatState.ts`, `conversationsSlice.ts`, `ConversationsState.ts`, `signalRHubConnection.ts`, `signalRMiddleware.ts`, `pluginsSlice.ts`, `PluginsState.ts`, `usersSlice.ts`, and `UsersState.ts`.

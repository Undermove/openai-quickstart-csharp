# OpenAI API Quickstart - CSharp example app

This is an example pet name generator app used in the OpenAI API [quickstart tutorial](https://platform.openai.com/docs/quickstart). It uses the [.NET 7.0 framework.](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

![Text box that says name my pet with an icon of a dog](https://github.com/Undermove/openai-quickstart-csharp/blob/main/public/dog.png?raw=true)

## Setup

1. If you don’t have .NET SDK 7.0 installed, [install it from here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

2. Clone this repository

3. Generate OpenAi API key [here](https://platform.openai.com/docs/quickstart/add-your-api-key)

4. Paste API key value to appsettings.json file in following section:
    ```json
      "OpenAiConfig": {
        "ApiKey": "<paste your key here>"
      }
    ```

5. Navigate into the project directory

   ```bash
   $ cd openai-quickstart-csharp/OpenAiQuickStartCSharp/
   ```

6. Run the app

   ```bash
   bash
   $ dotnet run
   ```
   
7. Test your app: 
    Open [app web page http://localhost:5078/](http://localhost:5078/) 
    
    Or use curl
    ```bash
    $ curl --location 'http://localhost:5078/OpenAi' --header 'Content-Type: application/json' --data '{ "Animal": "Cat"}'
    ```

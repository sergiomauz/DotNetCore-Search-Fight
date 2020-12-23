# .NET SEARCH FIGHT
> This project implements a simple challenge between 2 or more programming language for knowing which is the most popular between Search Engines.


## Screenshot
![screenshot-1](https://user-images.githubusercontent.com/36812672/102944697-86efc180-4489-11eb-9cdd-82404960ed12.png)

## Features
- Console application.
- 2 search engines (Google and Bing).
- 1 file with useful keys for the application (gotten from **App.config**).


## Built With
- Visual Studio 2019 - Community Edition
- .Net Core 3.1
- Application console
- C# programming language
- Google Search - API
- Bing Search v7 - API
- Newtonsoft and System.Text.Json for deserializing JSON into C# objects


## Used Techniques
- Serializing and Deserializing objects.
- Asynchronous tasks.
- Consuming APIs.
- Search engines.
- Collections.
- Interfaces.
- Inheritance.
- Overriding (Overwrite methods).
- StringBuilders.
- JSON and Dynamic objects.
- Lambda expressions.
- Handling exceptions.


## How to Install
- Install VS 2019 Community Edition and .Net Core 3.1 in your computer.
- Clone this repository using **git clone** command and open the **SearchFight.NetCore.sln** file.
- With a Google account, sign in and go to [Google - Programmable Search Engine (GPSE)](https://programmablesearchengine.google.com/).
- Go to your [GPSE Console](https://cse.google.com/cse/all): Create a new Search Engine for any website, copy your **Search ID** and replace the variable **GOOGLE_CX** value in the **App.config** file (which is in the **Search.Engine** directory).
- Go to your [Google Developer Console](https://developers.google.com/custom-search/v1/overview): Click in **Get a Key**, copy your **Key** and replace the variable **GOOGLE_KEY** value in the **App.config** file (mentioned above).
- With a Microsoft account, sign in and create an [Azure](https://azure.microsoft.com/en-us/) Account.
- Go to your [Azure Console](https://portal.azure.com/#home): Create a **Bing Search v7**, copy one of the **Keys** and replace the variable **BING_OCP_APIM_SUBSCRIPTION_KEY** value in the **App.config** file.
- Press **F5** to compile and start the solution.
- In a **Command Prompt** Move to directory **SearchFight.NetCore/bin/Debug/netcoreapp3.1/**.
- Run this example: ```SearchFight.NetCoreApp.exe "c sharp" python ruby perl```


## Unit Testing
![screenshot-2](https://user-images.githubusercontent.com/36812672/102944375-9a4e5d00-4488-11eb-8c16-a069a4cf3e81.png)

- For running tests, open de solution with Visual Studio 2019, go to menu **Test** and click in **Test Explorer**. After that, in the auxiliar window, click in **Run**. (Make sure that compile before to run the tests).


## Author

👤 **Sergio Zambrano**

- Github: [@sergiomauz](https://github.com/sergiomauz)
- Twitter: [@sergiomauz](https://twitter.com/sergiomauz)
- Linkedin: [Sergio Zambrano](https://www.linkedin.com/in/sergiomauz/)


## 🤝 Contributing
Contributions, issues and feature requests are welcome!. Feel free to check the [issues page](../../issues/).


## Show your support
Give a ⭐️ if you like this project!


## 📝 License
This project is [MIT](./LICENSE) licensed.

# .NET SEARCH FIGHT
> This project implements a simple challenge between 2 or more programming language for knowing which is the most popular between Search Engines.


## Screenshots
![screenshot-1](https://user-images.githubusercontent.com/36812672/99945143-1ea2a880-2d42-11eb-82fe-585cec28e2dc.png)
![screenshot-2](https://user-images.githubusercontent.com/36812672/99945285-5f9abd00-2d42-11eb-9467-de103e0515ff.png)


## Features
- 2 layers console application.
- 2 search engines (Google and Bing).
- 1 file with useful constants for the application. In this case, for a console application with 2 layers and important keys is preferible putting them as constants (even it could be better if this constants are encrypted).


## Built With
- Visual Studio 2019 - Community Edition
- .Net Framework 4.7.2
- Application console
- C# programming language
- Google search API
- Bing search API
- Newtonsoft for serializing JSON into C# objects


## Techniques used
- Serializing and Deserializing objects.
- Asynchronous tasks.
- Consuming APIs.
- Use of search engines.
- Use of collections.
- Use of StringBuilders.
- Lambda expressions.
- Handling exceptions.


## How to Install
- Install VS 2019 Community Edition and .Net Framework 4.7.2 in your computer.
- Clone this repository using **git clone** command and open the **SearchFight.sln** file.
- With a Google account, sign in and go to [Google - Programmable Search Engine (GPSE)](https://programmablesearchengine.google.com/).
- Go to your [GPSE Console](https://cse.google.com/cse/all): Create a new Search Engine for any website, copy your **Search ID** and replace the variable **GOOGLE_CX** value in the **Constants.cs** file (which is in the **Search.Engine** directory).
- Go to your [Google Developer Console](https://developers.google.com/custom-search/v1/overview): Click in **Get a Key**, copy your **Key** and replace the variable **GOOGLE_KEY** value in the **Constants.cs** file (mentioned above).
- With a Microsoft account, sign in and create an [Azure](https://azure.microsoft.com/en-us/) Account.
- Go to your [Azure Console](https://portal.azure.com/#home): Create a **Bing Search v7**, copy one of the **Keys** and replace the variable **BING_OCP_APIM_SUBSCRIPTION_KEY** value in the **Constants.cs** file.
- Press **F5** to compile and start the solution.
- In a **Command Prompt** Move to directory **Search.Fight/bin/Debug**.
- Run this example: ```SearchFight.exe "c sharp" python ruby perl```


## Unit Test
![screenshot-3](https://user-images.githubusercontent.com/36812672/99974003-617a7580-2d6e-11eb-9344-81db10d00c31.png)

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

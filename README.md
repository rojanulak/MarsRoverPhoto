# Rover Image 

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Rover Image consists of Console App that works like a archiver.Its backed by Rover Image Web Api that interfaces with NASA Rover Api. It also have a Angular 7 web app that can be used to see images based on Rover name and date.

# Tools Used!

  - AutoFixture with TestStack ( for test data generation using Builder pattern)
  - Automapper ( to map objects to Dto)
  - ManyConsole (as a command parser and implementing command pattern for console app)
  - Moq (mocking framework for test)
  - Serilog (for logging)
  - Shouldly (assertion framework for testing for simple and terse syntax)
  - Swagger (for web api endpoint discovery)
  - Unity ( Dependency Injection Container)
  - Xunit (Test runner)
  - 



### Framework

Rover Image uses a follwing framework:

* Angular 7
* Asp .net Core for Web
* .net 4.6.2



### Installation

Rover Image requires NodeJs and Npm to run.

Install the dependencies and devDependencies and start the server.

```sh
> cd MarsRoverCodingTest\MarsRover.Web
> npm install 
```


### How to Run ?
Rover Image is very easy to run.
First start your Web Api project under http://localhost:59582/, Then you can start your web app or console app or both. 

you can start console app from command line usng option belwo
```sh
> cd src\MarsRoverCodingTest\MarsRoverDownloadImages.CMD\bin\Debug
> MarsRoverDownloadImages.CMD.exe Run -f roverimagedates.txt
```
For Help
```sh
> cd src\MarsRoverCodingTest\MarsRoverDownloadImages.CMD\bin\Debug
> MarsRoverDownloadImages.CMD.exe /help
```

### Todos

 - Write MORE Tests (currenlty has 46 but none in UI layer)
 - Add Caching layer
 - Do some cleapnup and refactoring for web project
 - add support for docker, due to windows 8 on my home machince didn't could add support for it
 - add some security layer to web api project
 

License
----

MIT




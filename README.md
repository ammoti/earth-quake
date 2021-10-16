# EARTH-QUAKE
Earth-Quake is a API that returns earthquakes nearby by given coordinates.

[![.github/workflows/action.yml](https://github.com/ammoti/earth-quake/actions/workflows/action.yml/badge.svg)](https://github.com/ammoti/earth-quake/actions/workflows/action.yml)

## Technologies & Libraries
- .NET 5
- C# 9
- ASP.NET Core 5
- OpenAPI 3
- FluentValidation
- xUnit & Moq
- Github Actions(CI & CD)

## Run

```vahap@topGG:~$ git clone https://github.com/ammoti/earth-quake.git```\
```vahap@topGG:~$ cd earth-quake```\
```vahap@topGG:~$ dotnet restore```\
```vahap@topGG:~$ dotnet build```\
```vahap@topGG:~$ dotnet test```\
```vahap@topGG:~$ dotnet run --project .\API\EarthQuake.API.csproj```\
```vahap@topGG:~$ curl -X GET "https://localhost:5001/Earthquake/Ping" -H  "accept: */*"```

## Layers
**API** : OpenAPI.

**Application** : Business Flow

**Model** : Data Transfer Objects

## Performance & Scale

### Performance
We can boost performance with applying different techniques, for example;
Implementing cache mechanism like Redis would improve performance visible.

On the other hand we can improve performance using latest .NET Core Version, [in this article](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#json) indicates that almost every chapter .NET 6 beating .NET 5 almost all aspects(Mean, Ratio, Code Size). So that's why using latest .NET Core Version could another option for the increase performance.

But I want to add addtional things, in this project I used *record* for DTO objects instead of using *Class*  but [in this](https://stackoverflow.com/a/64828780) StackOverflow answer show us that class is performing better than record. So in my opinion obviously important but readability also very important so that's why I'm prefer record for the DTO as possible as (another reason immutable). 

### Scale
For scale an API have another techniques for example, using multiple host server with proper LoadBalancer, or you could also apply some horizontal and vertical scale techniques.  

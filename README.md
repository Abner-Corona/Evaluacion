Install [Visual Studio] or [.NET 6] sdk

execute the database scripts or add a migrations with code first

```sh
add-migration create_db -Context _DatabaseContext -OutputDir Migrations -verbose
```

change the connection string in RepositorioEF\_DatabaseContext.cs
and Evaluacion2\appsettings.json

run the project


 [Visual Studio]: https://visualstudio.microsoft.com/
 [.NET 6]: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
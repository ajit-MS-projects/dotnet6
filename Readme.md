Ef core db init
There are three strategies:
1. code first, write db context and entitiy classes then run ef migrate add and update, this also be done in code for e.g. on start of app
   1. dbcontext.cs, an example of code first where we created the dbcontext and entity classes, and then the ef. migrate & update commands to create dba nd tables in it. 
   2. this would create a migration folder locally and c-sharp code to create db and tables. on every update we would run these again. 
   3. code run migrations using code rather than dotnet cli - todo test
      1. https://stackoverflow.com/questions/70056665/run-ef-migrations-on-startup-in-asp-net-core-6-application
2. DB first: in this case db structur exists and of scaffold command is executed locally on pc to generate all enitities automatically.
   1. in this case we would use evolve .net to run db migragtions on start of app. The db structure would be kept in SQL files in solution. 
   2. https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
   3. https://docs.microsoft.com/en-us/ef/core/cli/dotnet#dotnet-ef-dbcontext-scaffold
   4. Now we have the tables in db, lets generate entity model classes from the db:
      1.  https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
      2.  https://docs.microsoft.com/en-us/ef/core/cli/dotnet#dotnet-ef-dbcontext-scaffold



# Code First: EntityCore project
## EF core database setup and migrations:

Note: to run dotnet ef, EF package must be in path 
```bash
$Env:PATH += ";C:\Users\chahal\.dotnet\tools"
```

Docs: Ref https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
add dbcontext & entity classes to project.
all the DbSet declared in dbcontext class would be created as tables in destinartion db.

```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This installs dotnet ef and the design package which is required to run the command on a project. 
The migrations command scaffolds a migration to create the initial set of tables for the model.
The database update command creates the database and applies the new migration to it.

Above is to setup ef only first time, then on every update
1. run, to create *migration* classes locally in migrations folder
    
    `dotnet ef migrations add InitialCreate`

        note: InitialCreate is the name of migration. it is new every time. 

2. then run following which would apply from local migrations to db

    `dotnet ef database update`

---

# DB first details: EnitiyCoreDbFirst project
## db migrations using sql scripts and evolve.net libe
https://evolve-db.netlify.app/getting-started/lib/
1. create a connection using Microsoft.Data.SqlClient.SqlConnection
2. create database sql scripts in db/migrations folder and run the program.
3. make sure in csproj file: so that all .sql files gets copied in build destination directory.
```xml
 <ItemGroup>
    <Content Include="db\migrations\**\*.sql">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
```

### Lets generate the entity classes now:
```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet ef dbcontext scaffold "Data Source=ajitpi1;Persist Security Info=True;User ID=sa;Password=mypassword;Database=Blogging;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models

```

Loading cpnnection string from secret config, this will be loaded from k8s secret mapped for e.g.. in prod AZURE key vault provider can be used in conjunction with k8s secrets.


---
---
# Query & save : 
Ok now we have tables in DB, lets CRUD & query data.
https://docs.microsoft.com/en-us/ef/core/
https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli


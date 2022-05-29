Ef core db init
There are code strategies:
1. code first, write db context and entitiy classes then run ef migrate add and update, this also be done in code for e.g. on start of app
   1. dbcontext.cs, an example of code first where we created the dbcontext and entity classes, and then the ef. migrate & update commands to create dba nd tables in it. 
   2. this would create a migration folder locally and c-sharp code to create db and tables. on every update we would run these again. 
2. DB first: in this case db structur exists and of scaffold command is executed locally on pc to generate all enitities automatically.
   1. in this case we would use evolve .net to run db migragtions on start of app. The db structure would be kept in SQL files in solution. 
   2. https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
   3. https://docs.microsoft.com/en-us/ef/core/cli/dotnet#dotnet-ef-dbcontext-scaffold



# Code First:
## EF core database setup and migrations:

Docs: Ref https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
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

Query & save : 
https://docs.microsoft.com/en-us/ef/core/

# DB first details
## 
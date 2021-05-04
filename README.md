# ToDoApplication

Robimy aplikację do dodawania zadań, wyświetlania ich i zapisywania w bazie danych. Są stworzone issue dla różnych zadań, w przypadku pytań najlepiej tam prowadzić dyskusję. Jedno issue może robić więcej niż 1 osoba. Na początek warto poczytać sobie o Razor Pages - [link](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-5.0&tabs=visual-studio#additional-resources).

# How to run it with database?
Project contains docker-compose.yaml file with database image. You should have installed Docker to use it. Alternatively, you can use another PostgreSQL database on port 7777 or change connection string.<br>
To start container with database, run `docker-compose up -d`. If you run it for the first time, it is necessary to applay migration to database. Install Entity Framework Core tool running `dotnet tool install --global dotnet-ef` or update it `dotnet tool update --global dotnet-ef`. Next, run `dotnet ef database update`, if you get an error, run it again. Database should work.
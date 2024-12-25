var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов
builder.Services.AddControllers();

var app = builder.Build();

// Подключение middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles(); // Для работы со статическими файлами

// Подключение маршрутов
app.MapControllers();

app.Run();

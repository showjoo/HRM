var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dockerConnectionString = Environment.GetEnvironmentVariable("MSSQLConnectionString");
// Inject our ConnectionString into DbContext
//builder.Services.AddDbContext<RecruitingDbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection"))
//);
//builder.Services.AddDbContext<RecruitingDbContext>(options => options.UseSqlServer(dockerConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
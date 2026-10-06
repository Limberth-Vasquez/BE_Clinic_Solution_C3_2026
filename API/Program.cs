using AppLogic;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPatientManager, PatientManager>();
builder.Services.AddSingleton<IDoctorManager, DoctorManager>();
builder.Services.AddSingleton<IRHConnector, RHConnector>();
builder.Services.AddSingleton<IAppointmentManager, AppointmentManager>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Demo_Policy",
        policy => {
            policy.AllowAnyOrigin(); //mypage.com, www.mypage.com, localhost:3000, etc.
            policy.AllowAnyHeader(); // application/json, text/plain, etc.
            policy.AllowAnyMethod(); // GET, POST, PUT, DELETE, etc.
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();

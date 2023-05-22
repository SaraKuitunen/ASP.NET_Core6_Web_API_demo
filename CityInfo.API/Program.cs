// Top-level statements: compiler will generate main method from the content of this file.
// That main method is starting point of the app, it is responsible for configuring and runnig the application

var builder = WebApplication.CreateBuilder(args); // used for hosting the web application

//// Add services to the container.
// Configure services by adding them to the services collection on the builder (WebApplicationBuilder):
// build-in dependency injection container
// -> services added to the container can be injected anywhere in the application code

// AddControllers is enough for building an with MVC pattern
builder.Services.AddControllers(options =>
{
    // OutputFormatters list could be used for setting default representations. Not set here -> default is JSON

    // status code 406 Not Acceptable is returned if user asks for non-supported representation
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters(); // Add XML input and output formatters -> adds support for XML
;

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// two lines below register on the container the services needed for Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // building the app results in an object of type WebApplication

//// Configure the HTTP request pipeline.
// Middleware: the components of that handle HTTP requests
if (app.Environment.IsDevelopment())
{
    // two lines below add Swagger middleware to the request pipeline
    app.UseSwagger(); // generates specification. https://localhost:7164/swagger/v1/swagger.json
    app.UseSwaggerUI(); // generates documentation UI based on the specification
}

app.UseHttpsRedirection();

app.UseRouting(); // Marks the position in the middleware pipeline where a routing decision is made, i.e. where endpoint is SELECTED

app.UseAuthorization();

app.UseEndpoints(endpoints => // Marks the position in the middleware pipeline where the selected endpoint is EXECUTED
{
    endpoints.MapControllers(); // Adds endpoints to controller actions w.o. specifying routes
});

//app.MapControllers(); // implements IEndpointRouting -> no need to add routing middleware and endpoint middleware to the request pipeline manually

app.Run();

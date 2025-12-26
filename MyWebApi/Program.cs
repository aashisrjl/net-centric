// // Required namespaces
// var builder = WebApplication.CreateBuilder(args); // Creates a new builder for the web app with default settings

// // Register services into the dependency injection container
// builder.Services.AddControllers(); // Adds support for controllers (API endpoints)
// // builder.Services.AddEndpointsApiExplorer(); // Enables minimal API endpoints (optional but used for Swagger)
// // builder.Services.AddSwaggerGen(); // Adds Swagger generation (API documentation tool)

// // Build the web application using the configured builder
// var app = builder.Build();

// // Middleware configuration starts here

// // app.UseSwagger(); // Enables middleware to serve the generated Swagger JSON
// // app.UseSwaggerUI(); // Enables the Swagger UI at /swagger for testing the API

// app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS automatically

// app.UseAuthorization(); // Adds authorization middleware (you can skip this if you're not using auth)

// // Maps attribute-routed controllers (like [Route("api/hello")])
// app.MapControllers(); // Looks for controllers in the Controllers folder and maps them

// app.Run(); // Runs the app — keeps listening for incoming HTTP requests


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/",context=>{
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

app.MapGet("/forms",(req)=>{
    req.Response.Redirect("/form.html");
    return Task.CompletedTask;
});
app.Run();

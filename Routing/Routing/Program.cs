using Routing.CustomConstraint;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("alphanumeric", typeof(alphaNumeric));
});

var app = builder.Build();
app.UseRouting();

//                    Routing in ASP.NET Core

app.UseEndpoints(endpoint =>
{
    
    //                   Regex or Regular Expression in Asp.NET
    endpoint.MapGet("/Quater-Yearly/{year:int:min(1999):minlength(4)}/{month:regex(^jun|nov|sep|dec$)}",async (context) =>
    {

        var year = Convert.ToInt32(context.Request.RouteValues["year"]);
        var month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"This is the {year}-{month}");
    });


    //                   Custom Constraint in ASP.NET Core
    endpoint.MapGet("/user/{username:alphanumeric}", async (context) =>
    {
        var UserName = Convert.ToString(context.Request.RouteValues["username"]);
        await context.Response.WriteAsync($"This is my {UserName}");
    });
});


app.Run();

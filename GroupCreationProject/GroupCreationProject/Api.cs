public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoints mapping
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users", DeleteUser);
        app.MapPost("/teacher/login", loginTeacher);
    }
    
    public static async Task<IResult> GetUsers(IUserData data)
    {
        try {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex){
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try {
            var results = await data.GetUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData Data)
    {
        try {
            await Data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateUser(UserModel user, IUserData Data)
    {
        try {
            await Data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteUser(int id, IUserData Data)
    {
        try {
            await Data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> loginTeacher(string email, string password, IteacherData Data)
    {
        try
        {
            var result = await Data.loginTeacher(email, password);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}



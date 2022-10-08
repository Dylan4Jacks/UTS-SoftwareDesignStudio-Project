public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoints mapping
        app.MapGet("/Groups", GetGroups);
        app.MapGet("/Groups/{id}", GetGroup);
        app.MapPost("/Groups", InsertGroup);
        app.MapPut("/Groups", UpdateGroup);
        app.MapDelete("/Groups", DeleteGroup);
    }
    
    public static async Task<IResult> GetGroups(IGroupData data)
    {
        try {
            return Results.Ok(await data.GetGroups());
        }
        catch (Exception ex){
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetGroup(int id, IGroupData data)
    {
        try {
            var results = await data.GetGroup(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertGroup(GroupModel group, IGroupData Data)
    {
        try {
            await Data.InsertGroup(group);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateGroup(GroupModel group, IGroupData Data)
    {
        try {
            await Data.UpdateGroup(group);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteGroup(int id, IGroupData Data)
    {
        try {
            await Data.DeleteGroup(id);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}



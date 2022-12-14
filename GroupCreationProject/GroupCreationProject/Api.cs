using Microsoft.AspNetCore.Mvc;
using GroupCreationProject.Models;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoints mapping
        
        //CategoryItem API Endpoints
        app.MapGet("/CategoryItems", GetCategoryItems);
        app.MapGet("/CategoryItems/{id}", GetCategoryItem);
        app.MapPost("/CategoryItems", InsertCategoryItem);
        app.MapPut("/CategoryItems", UpdateCategoryItem);
        app.MapDelete("/CategoryItems", DeleteCategoryItem);

        //CategoryList API Endpoints
        app.MapGet("/CategoryLists", GetCategoryLists);
        app.MapGet("/CategoryLists/{id}", GetCategoryList);
        app.MapPost("/CategoryLists", InsertCategoryList);
        app.MapPut("/CategoryLists", UpdateCategoryList);
        app.MapDelete("/CategoryLists", DeleteCategoryList);

        //CategorySelection API Endpoints
        app.MapGet("/CategorySelections", GetCategorySelections);
        app.MapGet("/CategorySelections/Student/{studentId}", GetCategorySelectionsStudent);
        app.MapGet("/CategorySelections/Item/{categoryItemId}", GetCategorySelectionsItem);
        app.MapGet("/CategorySelections/{studentId}/{categoryItemId}", GetCategorySelection);
        app.MapPost("/CategorySelections", InsertCategorySelection);
        app.MapPut("/CategorySelections", UpdateCategorySelection);
        app.MapDelete("/CategorySelections", DeleteCategorySelection);

        //Group API Endpoints
        app.MapGet("/Groups", GetGroups);
        app.MapGet("/Groups/{id}", GetGroup);
        app.MapPost("/Groups/", InsertGroup);
        app.MapPut("/Groups", UpdateGroup);
        app.MapDelete("/Groups", DeleteGroup);

        //Student API Endpoints
        app.MapGet("/Students", GetStudents);
        app.MapGet("/Students/{id}", GetStudent);
        app.MapPost("/Students", InsertStudent);
        app.MapPut("/Students", UpdateStudent);
        app.MapDelete("/Students", DeleteStudent);

        //Teacher API Endpoints
        app.MapGet("/Teachers", GetTeachers);
        app.MapGet("/Teachers/{id}", GetTeacher);
        app.MapPost("/Teachers", InsertTeacher);
        app.MapPut("/Teachers", UpdateTeacher);
        app.MapDelete("/Teachers", DeleteTeacher);

        //Authenticate Login
        app.MapPost("/Auth/Teacher", AuthenticateTeacher);
        app.MapPost("/Auth/Student", AuthenticateStudent);

        //Algorithm Execution
        app.MapGet("/Algorithm/Diverse/{isDiverse}/{groupSize}", GetGroupsDiverse);
    }


    //CategoryItem API Functions
    public static async Task<IResult> GetCategoryItems(ICategoryItemData data)
    {
        try {
            return Results.Ok(await data.GetCategoryItems());
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetCategoryItem(int id, ICategoryItemData data)
    {
        try {
            var results = await data.GetCategoryItem(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertCategoryItem(CategoryItemModel categoryItem, ICategoryItemData Data)
    {
        try {
            var id = await Data.InsertCategoryItem(categoryItem);
            return Results.Ok(id);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateCategoryItem(CategoryItemModel categoryItem, ICategoryItemData Data)
    {
        try {
            await Data.UpdateCategoryItem(categoryItem);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteCategoryItem(int id, ICategoryItemData Data)
    {
        try {
            await Data.DeleteCategoryItem(id);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    //CategoryList API Functions
    public static async Task<IResult> GetCategoryLists(ICategoryListData data)
    {
        try {
            return Results.Ok(await data.GetCategoryLists());
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetCategoryList(int id, ICategoryListData data)
    {
        try {
            var results = await data.GetCategoryList(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertCategoryList(CategoryListModel categoryList, ICategoryListData Data)
    {
        try {
            await Data.InsertCategoryList(categoryList);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateCategoryList(CategoryListModel categoryList, ICategoryListData Data)
    {
        try {
            await Data.UpdateCategoryList(categoryList);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteCategoryList(int id, ICategoryListData Data)
    {
        try {
            await Data.DeleteCategoryList(id);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    //CategorySelection API Functions
    public static async Task<IResult> GetCategorySelections(ICategorySelectionData data)
    {
        try {
            return Results.Ok(await data.GetCategorySelections());
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetCategorySelectionsStudent(int studentId, ICategorySelectionData data)
    {
        try {
            return Results.Ok(await data.GetCategorySelectionsStudent(studentId));
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetCategorySelectionsItem(int categoryItemId, ICategorySelectionData data)
    {
        try {
            return Results.Ok(await data.GetCategorySelectionsItem(categoryItemId));
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetCategorySelection(int studentId, int categoryItemId, ICategorySelectionData data)
    {
        try {
            var results = await data.GetCategorySelection(studentId, categoryItemId);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }


    private static async Task<IResult> InsertCategorySelection(CategorySelectionModel categorySelection, ICategorySelectionData Data)
    {
        try {
            await Data.InsertCategorySelection(categorySelection);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateCategorySelection(CategorySelectionModel categorySelection, ICategorySelectionData Data)
    {
        try {
            await Data.UpdateCategorySelection(categorySelection);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteCategorySelection(int StudentId, int categoryItemId, ICategorySelectionData Data)
    {
        try {
            await Data.DeleteCategorySelection(StudentId, categoryItemId);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    //Group API Functions
    public static async Task<IResult> GetGroups(IGroupData data)
    {
        try {
            return Results.Ok(await data.GetGroups());
        }
        catch (Exception ex) {
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

    //Student API Functions
    public static async Task<IResult> GetStudents(IStudentData data)
    {
        try {
            return Results.Ok(await data.GetStudents());
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetStudent(int id, IStudentData data)
    {
        try {
            var results = await data.GetStudent(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertStudent(StudentModel student, IStudentData Data)
    {
        try {
            await Data.InsertStudent(student);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateStudent(StudentModel student, IStudentData Data)
    {
        try {
            await Data.UpdateStudent(student);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteStudent(int id, IStudentData Data)
    {
        try {
            await Data.DeleteStudent(id);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    //Teacher API Functions
    public static async Task<IResult> GetTeachers(ITeacherData data)
    {
        try {
            return Results.Ok(await data.GetTeachers());
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetTeacher(int id, ITeacherData data)
    {
        try {
            var results = await data.GetTeacher(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertTeacher(TeacherModel teacher, ITeacherData Data)
    {
        try {
            await Data.InsertTeacher(teacher);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateTeacher(TeacherModel teacher, ITeacherData Data)
    {
        try {
            await Data.UpdateTeacher(teacher);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteTeacher(int id, ITeacherData Data)
    {
        try {
            await Data.DeleteTeacher(id);
            return Results.Ok();
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }




    // -------------  Authentication Functions  ---------------
    public class loginRequest
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }

    private static async Task<IResult> AuthenticateStudent([FromBody] loginRequest req, IStudentData data)
    {
        try {
            var results = await data.AuthenticateStudent(req.email, req.password);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> AuthenticateTeacher( [FromBody] loginRequest req, ITeacherData data)
    {
        try {
            var results = await data.AuthenticateTeacher(req.email, req.password);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    // -------------  Group Diversity Similarity Algorithms  ---------------
    // Lower Diversiy score = More Diverse
    // Higher Diversity score = More Similar
    
    public static async Task<IResult> GetGroupsDiverse(int isDiverse, int groupSize, IStudentData dataStu, ICategorySelectionData dataCatSel, ICategoryItemData dataCatItem, IGroupData dataGroup)
    {
        //Get User Data
        var students = await dataStu.GetStudents();
        var catSelections = await dataCatSel.GetCategorySelections();
        var catItems = await dataCatItem.GetCategoryItems();
        var groups = await dataGroup.GetGroups();
        //Get Diverse/Similar Groups
        DiversityModel divModel = new(students, catSelections, catItems);
        List<List<int>> newGroups= divModel.getDiverseGroups(groupSize, Convert.ToBoolean(isDiverse));

        //demo code
        //newGroups = (Convert.ToBoolean(isDiverse)) ?
        //    new List<List<int>>() {
                
        //    } :
        //    new List<List<int>>() {

        //    };

        //Delete Old Groups - (Student groupId is automaticaly updated to null)
        await dataGroup.DeleteAllGroups();
        //Create new Groups
        for (int Id = 1; Id <= newGroups.Count; Id++) {
            await dataGroup.InsertGroup(new() { GroupId=Id });
            foreach(int studentId in newGroups[Id-1]) {
                
                await dataStu.UpdateStudent(students.FirstOrDefault(student => student.StudentId == studentId));
            }
        }

        try {
            IEnumerable<GroupModel> results = await dataGroup.GetGroups();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    

}



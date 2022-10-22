using DataAccess.DbAccess;
using GroupCreationProject.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GroupCreationProject.Models;
//using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

//Lines needed to access UserDB
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ICategoryItemData, CategoryItemData>();
builder.Services.AddSingleton<ICategoryListData, CategoryListData>();
builder.Services.AddSingleton<ICategorySelectionData, CategorySelectionData>();
builder.Services.AddSingleton<IGroupData, GroupData>();
builder.Services.AddSingleton<IStudentData, StudentData>();
builder.Services.AddSingleton<ITeacherData, TeacherData>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.ConfigureApi();

StudentModel[] students = new StudentModel[]
            {
                new StudentModel {StudentId = 1, FirstName = "John", Email = "JohnSmith.com", Password = "cool"},
                new StudentModel {StudentId = 2, FirstName = "Ben", Email = "JohnSmith.com", Password = "cool"},
                new StudentModel { StudentId = 3, FirstName = "Alfred", Email = "JohnSmith.com", Password = "cool" },
                new StudentModel { StudentId = 4, FirstName = "Maso", Email = "JohnSmith.com", Password = "cool" },
                new StudentModel { StudentId = 5, FirstName = "Darla", Email = "JohnSmith.com", Password = "cool" },
                new StudentModel { StudentId = 6, FirstName = "MrCool", Email = "JohnSmith.com", Password = "cool" },
                new StudentModel { StudentId = 7, FirstName = "Roger", Email = "JohnSmith.com", Password = "cool" },
                new StudentModel { StudentId = 8, FirstName = "Federa", Email = "JohnSmith.com", Password = "cool" },
                new StudentModel { StudentId = 9, FirstName = "Ethan", Email = "JohnSmith.com", Password = "cool" }
            };

IEnumerable<StudentModel> getAllStudents()
{
    return students;
}

CategorySelectionModel[] categorySelects = new CategorySelectionModel[]
{
                new CategorySelectionModel {StudentId = 1}
};

CategoryItemModel[] categoryItems = new CategoryItemModel[]
{
                new CategoryItemModel{CategoryItemId = 1, Name = "High Distinction",  CategoryListId = 1},
                new CategoryItemModel {CategoryItemId = 2,Name = "Pass",CategoryListId = 1},
                new CategoryItemModel {CategoryItemId = 3,Name = "Distinction",CategoryListId = 1},
                new CategoryItemModel {CategoryItemId = 4,Name = "Server Development",CategoryListId = 2},
                new CategoryItemModel {CategoryItemId = 5,Name = "Web Development",CategoryListId = 2},
                new CategoryItemModel {CategoryItemId = 6,Name = "Data Analysis",CategoryListId = 2},
                new CategoryItemModel {CategoryItemId = 7,Name = "Management",CategoryListId = 2},
                new CategoryItemModel {CategoryItemId = 8,Name = "Cooking",CategoryListId = 3},
                new CategoryItemModel {CategoryItemId = 9,Name = "Sports",CategoryListId = 3},
                new CategoryItemModel {CategoryItemId = 10,Name = "Server SQL",CategoryListId = 4},
                new CategoryItemModel {CategoryItemId = 11,Name = "Programming",CategoryListId = 4},
                new CategoryItemModel {CategoryItemId = 12,Name = "Team Leading",CategoryListId = 4}

};

IEnumerable<CategoryItemModel> getAllCategoryItemModels()
{
    return categoryItems;
}

CategorySelectionModel[] categorySelections = new CategorySelectionModel[]
{
                new CategorySelectionModel { CategoryItemId = 1, StudentId = 1},
                new CategorySelectionModel { CategoryItemId = 4, StudentId = 1 },
                new CategorySelectionModel { CategoryItemId = 9, StudentId = 1 },
                new CategorySelectionModel { CategoryItemId = 12, StudentId = 1 },

                new CategorySelectionModel {CategoryItemId = 3, StudentId = 2},
                new CategorySelectionModel {CategoryItemId = 4, StudentId = 2},
                new CategorySelectionModel {CategoryItemId = 8, StudentId = 2},
                new CategorySelectionModel {CategoryItemId = 10, StudentId = 2},

                new CategorySelectionModel {CategoryItemId = 3, StudentId = 3},
                new CategorySelectionModel {CategoryItemId = 7, StudentId = 3},
                new CategorySelectionModel {CategoryItemId = 8, StudentId = 3},
                new CategorySelectionModel {CategoryItemId = 11, StudentId = 3},

                new CategorySelectionModel {CategoryItemId = 2, StudentId = 4},
                new CategorySelectionModel {CategoryItemId = 5, StudentId = 4},
                new CategorySelectionModel {CategoryItemId = 9, StudentId = 4},
                new CategorySelectionModel {CategoryItemId = 12, StudentId = 4},

                new CategorySelectionModel {CategoryItemId = 2, StudentId = 5},
                new CategorySelectionModel {CategoryItemId = 7, StudentId = 5},
                new CategorySelectionModel {CategoryItemId = 8, StudentId = 5},
                new CategorySelectionModel {CategoryItemId = 10, StudentId = 5},

                new CategorySelectionModel {CategoryItemId = 1, StudentId = 6},
                new CategorySelectionModel {CategoryItemId = 6, StudentId = 6},
                new CategorySelectionModel {CategoryItemId = 9, StudentId = 6},
                new CategorySelectionModel {CategoryItemId = 12, StudentId = 6},

                new CategorySelectionModel {CategoryItemId = 1, StudentId = 7},
                new CategorySelectionModel {CategoryItemId = 4, StudentId = 7},
                new CategorySelectionModel {CategoryItemId = 8, StudentId = 7},
                new CategorySelectionModel {CategoryItemId = 11, StudentId = 7},

                new CategorySelectionModel {CategoryItemId = 2, StudentId = 8},
                new CategorySelectionModel {CategoryItemId = 6, StudentId = 8},
                new CategorySelectionModel {CategoryItemId = 8, StudentId = 8},
                new CategorySelectionModel {CategoryItemId = 10, StudentId = 8},

                new CategorySelectionModel {CategoryItemId = 3, StudentId = 9},
                new CategorySelectionModel {CategoryItemId = 4, StudentId = 9},
                new CategorySelectionModel {CategoryItemId = 9, StudentId = 9},
                new CategorySelectionModel {CategoryItemId = 11, StudentId = 9}
};

IEnumerable<CategorySelectionModel> allCatSelects()
{
    return categorySelections;
}
/*
TransformationModel transform = new(getAllStudents(), allCatSelects(), getAllCategoryItemModels());

List<StuPrefModel> stuPrefs = new List<StuPrefModel>();
stuPrefs = transform.transformStu();
for (int i = 0; i < stuPrefs.Count; i++)
{
    stuPrefs[i].displayPreferences();
}
*/
GroupPrefModel group1 = new(1, "group 1");
GroupPrefModel group2 = new(2, "group 2");
GroupPrefModel group3 = new(3, "group 3");

void initalise_data(List<GroupPrefModel> groups)
{
 

    groups.Add(group1);
    groups.Add(group2);
    groups.Add(group3);
}



void getMostDiverseClass(bool diverse)
{
    int count = 0;
    Decimal mostDiverse;
    if (diverse == true)
    {
        mostDiverse = 999999999;
    }
    else
    {
        mostDiverse = -1;
    }
    Decimal diversity = mostDiverse;
    List<GroupPrefModel> mostDiverseGroup = new List<GroupPrefModel>();
    List<GroupPrefModel> current_group = new List<GroupPrefModel>();
    TransformationModel transform = new(getAllStudents(), allCatSelects(), getAllCategoryItemModels());
    List<StuPrefModel> people = new(transform.transformStu());


    Console.WriteLine("----------------------------");
    while (count < 1000)
    {
        List<GroupPrefModel> groups = new List<GroupPrefModel>();
        initalise_data(groups);
        GroupFormation make_groups = new(3, groups, people, 3);
        List<StuPrefModel> proper_list = make_groups.copyList(people);
        for (int i = 0; i < make_groups.Groups.Count; i++)
        {
            make_groups.randomiseGroups(make_groups.Groups[i], proper_list);
        }
        current_group = groups.ToList();
        diversity = make_groups.groupDiversity();
        if (diverse == true)
        {
            if (mostDiverse > diversity)
            {
                mostDiverse = diversity;
                diversity = 0;
                mostDiverseGroup = current_group;
            }
        }
        else
        {
            if (mostDiverse < diversity)
            {
                mostDiverse = diversity;
                diversity = 0;
                mostDiverseGroup = current_group;
            }
        }
        count += 1;
        proper_list = make_groups.copyList(people);
    }
    Console.WriteLine("MOST DIVERSE: " + mostDiverse);

    // This loop below is for showing the most diverse group
    for (int z = 0; z < mostDiverseGroup.Count; z++)
    {
        GroupPrefModel iteratedGroup = mostDiverseGroup[z];
        Console.WriteLine(iteratedGroup.Name);
        for (int j = 0; j < 3; j++)
        {
            iteratedGroup.Members[j].displayPreferences();
        }
    }
}
getMostDiverseClass(false);
Console.WriteLine("----------------------------");


app.Run();

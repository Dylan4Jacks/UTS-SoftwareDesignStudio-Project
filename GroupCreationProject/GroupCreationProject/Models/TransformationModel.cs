using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;


namespace GroupCreationProject.Models
{
    public class TransformationModel
    {

        IEnumerable<StudentModel> dataStu { get; set; }
        IEnumerable<CategorySelectionModel> dataCatSel { get; set; }
        IEnumerable<CategoryItemModel> dataCatItem { get; set; }
        public List<int> allStuIds { get; set; }


        public TransformationModel( IEnumerable<StudentModel> datastu, IEnumerable<CategorySelectionModel> datacatsel, IEnumerable<CategoryItemModel> datacatitem)
        {
            dataStu = datastu;
            dataCatSel = datacatsel;
            dataCatItem = datacatitem;
            allStuIds = getAllStuIds();
        }

        
        public List<int> getAllStuIds()
        {
            List<int> stuIds = new List<int>();
            foreach (var stu in dataStu)
            {
                stuIds.Add(stu.StudentId);
            }
            return stuIds;
        }

        public Dictionary<int, List<int>> get_catSelect()
        {
            Dictionary<int, List<int>> stuId_catSelect = new Dictionary<int, List<int>>();
            for (int i = 0; i < allStuIds.Count; i++)
            {
                List<int> catItemId = new List<int>();
                catItemId.Clear();
                foreach (var catSelectId in dataCatSel)
                {
                    if (catSelectId.StudentId == allStuIds[i])
                    {
                        catItemId.Add(catSelectId.CategoryItemId);
                    }
                    
                }
                stuId_catSelect.Add(allStuIds[i], catItemId);
            }
            return stuId_catSelect;
        }

        public List<StuPrefModel> transformStu()
        {
            List<StuPrefModel> students = new List<StuPrefModel>();
            foreach (KeyValuePair<int, List<int>> data in get_catSelect())
            {
                List<string> preferences = new List<string>();
                preferences.Clear();
                foreach (var catItemId in dataCatItem)
                {
                    for (int i = 0; i < data.Value.Count; i++)
                    {
                        if (catItemId.CategoryItemId == data.Value[i])
                        {
                            preferences.Add(catItemId.Name);
                        }
                    }
                }
                string preference1 = preferences[0];
                string preference2 = preferences[1];
                string preference3 = preferences[2];
                string preference4 = preferences[3];
                StuPrefModel new_student = new(data.Key, preference1, preference2, preference3, preference4);
                students.Add(new_student);
            }
            return students;
        }

        
        public static void Main()
        {

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

            TransformationModel transform = new(getAllStudents(), allCatSelects(), getAllCategoryItemModels());

            List<StuPrefModel> stuPrefs = new List<StuPrefModel>();
            stuPrefs = transform.transformStu();
            for (int i = 0; i<stuPrefs.Count; i++)
            {
                Console.WriteLine(stuPrefs[i]);
            }



        }
    }
}


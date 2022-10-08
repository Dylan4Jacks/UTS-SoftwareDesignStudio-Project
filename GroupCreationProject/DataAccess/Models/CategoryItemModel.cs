using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class CategoryItemModel
{
    public int CategoryItemId { get; set; }
    public string Name { get; set; }
    public string? Details { get; set; }
    public int CategoryListId { get; set; }

}

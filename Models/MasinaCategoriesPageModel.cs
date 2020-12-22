using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Medii_Bodea_Denis.Data;

namespace Proiect_Medii_Bodea_Denis.Models
{
    public class MasinaCategoriesPageModel :PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Proiect_Medii_Bodea_DenisContext context, Masina masina)
        {
            var allCategories = context.Category;
            var masinaCategories = new HashSet<int>(
                masina.MasinaCategories.Select(c => c.MasinaID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = masinaCategories.Contains(cat.ID)

                });
            }
        }

        public void UpdateMasinaCategories(Proiect_Medii_Bodea_DenisContext context,
            string[] selectedCategories, Masina masinaToUpdate)
        {
            if(selectedCategories == null)
            {
                masinaToUpdate.MasinaCategories = new List<MasinaCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var masinaCategories = new HashSet<int>
                (masinaToUpdate.MasinaCategories.Select(c => c.Category.ID));
            foreach(var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!masinaCategories.Contains(cat.ID))
                    {
                        masinaToUpdate.MasinaCategories.Add(
                            new MasinaCategory
                            {
                                MasinaID = masinaToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (masinaCategories.Contains(cat.ID))
                    {
                        MasinaCategory courseToRemove
                            = masinaToUpdate
                            .MasinaCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

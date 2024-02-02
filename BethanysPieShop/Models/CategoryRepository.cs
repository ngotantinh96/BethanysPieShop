namespace BethanysPieShop.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly BethanysPieShopDbContext dbContext;

    public CategoryRepository(BethanysPieShopDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IEnumerable<Category> AllCategories => dbContext.Categories.OrderBy(x => x.CategoryName);
}

using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class PieRepository : IPieRepository
{
    private readonly BethanysPieShopDbContext dbContext;

    public PieRepository(BethanysPieShopDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Pie> AllPies => dbContext.Pies.Include(x => x.Category);

    public IEnumerable<Pie> PiesOfTheWeek => dbContext.Pies.Include(x => x.Category).Where(x => x.IsPieOfTheWeek);

    public Pie? GetPieById(int pieId) => dbContext.Pies.FirstOrDefault(x => x.PieId == pieId); 

    public IEnumerable<Pie> SearchPies(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
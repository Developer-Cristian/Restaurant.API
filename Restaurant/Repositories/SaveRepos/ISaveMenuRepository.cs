using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;

namespace Restaurant.Repositories.SaveRepos
{
    public interface ISaveMenuRepository : ISaveGenericRepositoty<Menu>, IReadMenuRepository
    {
    }
}

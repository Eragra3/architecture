using System.Threading.Tasks;

namespace KekManager.Database
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}

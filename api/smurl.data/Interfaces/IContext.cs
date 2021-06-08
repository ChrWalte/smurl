using System.Threading.Tasks;

namespace smurl.data.Interfaces
{
    public interface IContext
    {
        Task TestDatabaseConnection();
    }
}
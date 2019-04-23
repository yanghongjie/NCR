using System.Data;
using System.Threading.Tasks;

namespace NCR.Tests.Base
{
    public interface IDataAccess
    {
        int ExecuteNonQuery(string commandText, object objParams = null);
    }
}
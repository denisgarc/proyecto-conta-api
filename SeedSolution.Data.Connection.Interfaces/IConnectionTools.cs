using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.Connection.Interfaces
{
    public interface IConnectionTools
    {
        DataSet Getds();
        DataTable Getdt();
        bool Exec();
        bool Exec(List<string> QueryList);
        bool Exec(List<SqlCommand> CommandsList);
        bool Exec(SqlCommand cmd);
        string ExecEscalar(SqlCommand cmd);
        DataSet Getds(SqlCommand cmd);
        string Error();
        bool Status();
    }
}

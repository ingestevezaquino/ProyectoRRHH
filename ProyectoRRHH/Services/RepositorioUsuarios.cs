using Microsoft.Data.SqlClient;
using ProyectoRRHH.Models;

namespace ProyectoRRHH.Services
{
    public interface IRepositorioUsuarios
    {

    }
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly string connectionString;

        public RepositorioUsuarios(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("rrhh_connection");
        }

        /*public async Task<int> CrearUsuario(Usuario usuario)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>();
        }*/
    }
}

using Dominio.BoundedContext.AggregatePlanta;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrucura.Core.Comunes
{
    public class BCUnitOfWork : DbContext
    {
        /// <summary>
        /// Inicializa mi UnitOfWord Base de acuerdo a la cadena de conexion que recibe mi parametro
        /// </summary>
        /// <param name="connectionString">Cadena de conexion para poderse conectar a la base de datos</param>
        public BCUnitOfWork(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<BCUnitOfWork>(null);
        }

        /// <summary>
        /// Constructor vacio del unito of work Base
        /// </summary>
        public BCUnitOfWork()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Gestion.Metricas
{
    public class Cliente
    {
        public IList<Entidades.Parametros.Salidas.Metricas.EstadoCliente> Listar()
        {
            return Listar(string.Empty);
        }

        public IList<Entidades.Parametros.Salidas.Metricas.EstadoCliente> Listar(string rutCliente)
        {
            return new Datos.Gestion.Metricas.Cliente().Listar(rutCliente);
        }

        public IList<Entidades.Parametros.Salidas.Metricas.EstadoClienteCobranza> ListarCobranzas(string rutCliente)
        {
            if (string.IsNullOrWhiteSpace(rutCliente))
                return new List<Entidades.Parametros.Salidas.Metricas.EstadoClienteCobranza>();
            return new Datos.Gestion.Metricas.Cliente().ListarCobranzas(rutCliente);
        }
    }
}

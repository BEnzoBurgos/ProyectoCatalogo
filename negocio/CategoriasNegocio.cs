﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
   public class CategoriasNegocio
    {
        public List<Categorias> listar()
        {
			List<Categorias> lista = new List<Categorias>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Select Id, Descripcion From Categorias");
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					Categorias aux = new Categorias();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];
					
					lista.Add(aux);
				}

				return lista;
            }
			catch (Exception ex )
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();

			}
        } 
    }
}

using Microsoft.EntityFrameworkCore;
using RegistroPrestamos.DAL;
using RegistroPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPrestamos.BLL
{
    public class PersonasBLL
    {
        public static bool Existe(int id)
        {
            var contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Personas.Any(e => e.PersonaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Insertar(Personas personas)
        {
            var contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Personas.Add(personas);
                insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return insertado;
        }

        public static bool Modificar(Personas personas)
        {
            var contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.PersonaId))
                return Insertar(personas);
            else
                return Modificar(personas);
        }

        public static bool Eliminar(int id)
        {
            var contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var personas = contexto.Personas.Find(id);

                if (personas != null)
                {
                    contexto.Personas.Remove(personas);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return eliminado;
        }

        public static Personas Buscar(int id)
        {
            var contexto = new Contexto();
            Personas personas;

            try
            {
                personas = contexto.Personas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return personas;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> criterio)
        {
            List<Personas> lista = new List<Personas>();
            var contexto = new Contexto();

            try
            {
                lista = contexto.Personas.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Personas> GetEstudiantes()
        {
            List<Personas> lista = new List<Personas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Personas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

    }
}
}

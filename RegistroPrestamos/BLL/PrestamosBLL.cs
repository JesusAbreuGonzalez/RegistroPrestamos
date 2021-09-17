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
    public class PrestamosBLL
    {
        public static bool Existe(int id)
        {
            var contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(e => e.PrestamoId == id);
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

        public static bool Insertar(Prestamos prestamos)
        {
            var contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Prestamos.Add(prestamos);
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

        public static bool Modificar(Prestamos prestamos)
        {
            var contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Entry(prestamos).State = EntityState.Modified;
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

        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }

        public static bool Eliminar(int id)
        {
            var contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var prestamos = contexto.Prestamos.Find(id);

                if (prestamos != null)
                {
                    contexto.Prestamos.Remove(prestamos);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return eliminado;
        }

        public static Prestamos Buscar(int id)
        {
            var contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamos;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            var contexto = new Contexto();

            try
            {
                lista = contexto.Prestamos.Where(criterio).ToList();
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

        public static List<Prestamos> GetPrestamos()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Prestamos.ToList();
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

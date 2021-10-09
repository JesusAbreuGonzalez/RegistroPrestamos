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
    public class MorasBLL
    {
        public static bool Guardar(Moras mora)
        {
            if (!Existe(mora.MoraId))
            {
                return Insertar(mora);
            }
            else
            {
                return Modificar(mora);
            }
        }

        public static bool Existe(int Id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Moras.Any(e => e.MoraId == Id);
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

        public static bool Insertar(Moras mora)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Moras.Add(mora);
                paso = contexto.SaveChanges() > 0;
                if (paso)
                {
                    AjustarPrestamos(mora, 1);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Moras mora)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                AjustarPrestamos(mora, 0);
                contexto.Database.ExecuteSqlRaw($"Delete from MorasDetalle where MoraId = {mora.MoraId}");

                foreach (var anterior in mora.MorasDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(mora).State = EntityState.Modified;

                paso = contexto.SaveChanges() > 0;
                if (paso)
                {
                    AjustarPrestamos(mora, 1);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int MoraId)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var mora = contexto.Moras.Include(e => e.MorasDetalle).Where(m => m.MoraId == MoraId).FirstOrDefault();

                if (mora != null)
                {
                    AjustarPrestamos(mora, 0);
                    contexto.Moras.Remove(mora);
                    paso = contexto.SaveChanges() > 0;
                    if (paso)
                    {
                        contexto.Database.ExecuteSqlRaw($"Delete from MorasDetalle where MoraId = {MoraId}");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Moras Buscar(int MoraId)
        {
            Contexto contexto = new Contexto();
            Moras mora;

            try
            {
                mora = contexto.Moras.Include(det => det.MorasDetalle).Where(m => m.MoraId == MoraId).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return mora;
        }

        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> morasList = new List<Moras>();
            Contexto contexto = new Contexto();

            try
            {
                morasList = contexto.Moras.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return morasList;
        }

        public static void AjustarPrestamos(Moras Mora, int option)
        {
            try
            {
                using (var contexto = new Contexto())
                {
                    foreach (MorasDetalle detalle in Mora.MorasDetalle)
                    {
                        var Prestamo = contexto.Prestamos.Where(p => p.PrestamoId == detalle.PrestamoId).FirstOrDefault();

                        Prestamo.Balance += (option == 0 ? (detalle.Valor * -1) : detalle.Valor); // 0 -> Revertir la mora; 1 -> Aplicar la mora
                        contexto.Entry(Prestamo).State = EntityState.Modified;

                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

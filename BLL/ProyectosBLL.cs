using Microsoft.EntityFrameworkCore;
using P2_AP1_Frankelyn_20190276.DAL;
using P2_AP1_Frankelyn_20190276.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Frankelyn_20190276.BLL
{
    public class ProyectosBLL
    {
        public static bool Guardar(Proyectos Proyecto)
        {
            if (!Existe(Proyecto.ProyectoId))
                return Insertar(Proyecto);
            else
                return Modificar(Proyecto);
        }

        private static bool Insertar(Proyectos Proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach(var detalle in Proyecto.Detalle)
                {
                    detalle.TipoDeTarea.TiempoAcumulado += detalle.Tiempo;
                    contexto.Entry(detalle.TipoDeTarea).State = EntityState.Modified;
                }

                contexto.Proyectos.Add(Proyecto);
                paso = contexto.SaveChanges() > 0;
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

        private static bool Modificar(Proyectos Proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyectoAnterior = contexto.Proyectos.Where(x => x.ProyectoId == Proyecto.ProyectoId)
                                                         .Include(x => x.Detalle)
                                                         .ThenInclude(x => x.TipoDeTarea)
                                                         .AsNoTracking()
                                                         .SingleOrDefault();

                foreach(var detalle in proyectoAnterior.Detalle)
                {
                    var tarea = contexto.TipoDeTarea.Find(detalle.TipoDeTarea.TipoDeTareaId);
                    tarea.TiempoAcumulado -= detalle.Tiempo;
                    detalle.TipoDeTarea = tarea;
                    contexto.Entry(detalle.TipoDeTarea).State = EntityState.Modified;
                }



                contexto.Database.ExecuteSqlRaw($"Delete from ProyectosDetalle where ProyectoId = {Proyecto.ProyectoId}");


                foreach(var Item in Proyecto.Detalle)
                {
                    contexto.Entry(Item).State = EntityState.Added;
                    var tarea = contexto.TipoDeTarea.Find(Item.TipoDeTarea.TipoDeTareaId);
                    tarea.TiempoAcumulado += Item.Tiempo;
                    Item.TipoDeTarea = tarea;
                    contexto.Entry(Item.TipoDeTarea).State = EntityState.Modified;
                }

                contexto.Entry(Proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
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


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyecto = ProyectosBLL.Buscar(id);

                if(proyecto != null)
                {

                    foreach(var detalle in proyecto.Detalle)
                    {
                        detalle.TipoDeTarea.TiempoAcumulado -= detalle.Tiempo;
                        contexto.Entry(detalle.TipoDeTarea).State = EntityState.Modified;
                    }

                    contexto.Proyectos.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
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

        public static Proyectos Buscar(int id)
        {
            Proyectos proyecto;
            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyectos.Where(x => x.ProyectoId == id)
                                             .Include(x => x.Detalle)
                                             .ThenInclude(x => x.TipoDeTarea)
                                             .AsNoTracking()
                                             .SingleOrDefault();
                                             
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }

        public static bool Existe(int id)
        {
            bool esValido = false;
            Contexto contexto = new Contexto();

            try
            {
                esValido = contexto.Proyectos.Any(x => x.ProyectoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esValido;
        }

        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> Criterio)
        {
            List<Proyectos> lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(Criterio).ToList();
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

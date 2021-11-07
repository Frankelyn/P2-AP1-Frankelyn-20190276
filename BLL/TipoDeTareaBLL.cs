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
    public class TipoDeTareaBLL
    {

        public static TipoDeTarea Buscar(int id)
        {
            TipoDeTarea tipoDeTarea;
            Contexto contexto = new Contexto();

            try
            {
                tipoDeTarea = contexto.TipoDeTarea.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tipoDeTarea;
        }

        public static List<TipoDeTarea> GetList(Expression<Func<TipoDeTarea, bool>> Criterio)
        {
            List<TipoDeTarea> lista = new List<TipoDeTarea>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TipoDeTarea.Where(Criterio).ToList();
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

        public static List<TipoDeTarea> GetTiposDeTarea()
        {
            List<TipoDeTarea> lista = new List<TipoDeTarea>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TipoDeTarea.ToList();
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

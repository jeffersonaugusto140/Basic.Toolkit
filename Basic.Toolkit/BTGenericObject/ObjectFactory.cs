using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Toolkit.BTGenericObject
{
    public class ObjectFactory
    {
        /// <summary>
        /// Cria instância do tipo informado. Caso não consiga retorna uma TypeUnloadedException.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static TSource CreateInstance<TSource>(params object[] args)
        {
            try
            {
                var type = typeof(TSource);
                var mAssembly = type.Assembly;
                return (TSource)mAssembly.CreateInstance(type.FullName, true, BindingFlags.CreateInstance, null, args, null, null);
            }
            catch (Exception ex)
            {
                throw new System.TypeUnloadedException(
                    string.Format("Não foi possível criar instância do objeto '{0}'", typeof(TSource).FullName), ex);
            }
        }

        /// <summary>
        /// Cria instância do tipo informado. Caso não consiga retorna uma TypeUnloadedException.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateInstance(Type type, params object[] args)
        {
            try
            {
                var mAssembly = type.Assembly;
                return mAssembly.CreateInstance(type.FullName, true, BindingFlags.CreateInstance, null, args, null, null);
            }
            catch (System.Exception ex)
            {
                throw new System.TypeUnloadedException(string.Format("Não foi possível criar instância do objeto '{0}'", type.FullName), ex);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Reflection
{
    public static class ReflectionExtension
    {
        /// <summary>
        /// Copia os valores para o outro objeto baseado no nome das propriedades.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyTo(this object source, object target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();

            foreach (var propertyInfo in sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var methodName = propertyInfo.Name;

                if (propertyInfo.GetGetMethod() == null || targetType.GetProperty(methodName).GetSetMethod() == null)
                    continue;
                
                var sourceValue = sourceType.GetProperty(methodName).GetValue(source);
                targetType
                    .GetProperty(methodName)
                    .SetValue(target, sourceValue, BindingFlags.Public | BindingFlags.Instance, null, null, null);
            }
        }

        /// <summary>
        /// Retorna o valor com base no nome da propriedade.
        /// Caso não encontre a propriedade retorna null.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetValueFrom(this object source, string propertyName)
        {
            var sourceType = source.GetType();

            if (sourceType.GetProperty(propertyName) != null && sourceType.GetProperty(propertyName).GetGetMethod() != null)
                return sourceType.GetProperty(propertyName).GetValue(source);
            return null;
        }
    }
}

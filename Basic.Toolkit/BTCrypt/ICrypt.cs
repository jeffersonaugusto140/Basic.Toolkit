using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Toolkit.BTCrypt
{
    public interface ICrypt
    {
        string Key { get; set; }

        /// <summary>
        /// Encripta o dado solicitado.
        /// </summary>
        /// <param name="plainText">Texto a ser criptografado.</param>
        /// <returns>Texto criptografado.</returns>
        string Encrypt(string texto);

        /// <summary>
        /// Decripta o dado solicitado.
        /// </summary>
        /// <param name="cryptoText">Texto a ser descriptografado.</param>
        /// <returns>Texto descriptografado.</returns>
        string Decrypt(string textoCriptografado);

        /// <summary>
        /// Gera a chave de criptografia válida dentro do array.
        /// </summary>
        /// <returns>Chave com array de bytes.</returns>
        byte[] GetKey();
    }
}

/*
<version>1.0</version>
<author>Tiago Mendes</author>
<mail>tiago@mendes.com.pt</mail>
<date>2016-02-20</date>
<description>Classe que define a roleta</description>
*/
using System;

namespace Roleta
{
    /// <summary>
    /// Classe que define a roleta
    /// </summary>
    public class Roleta
    {
        #region ATRIBUTOS
        //Variaveis que definem quais os numeros pretos e vermelhos da roleta
        static int[] numerosPretos = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
        static int[] numerosVermelhos = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        #endregion

        #region METODOS

        #region PROPRIEDADES
        /// <summary>
        /// Todos os numeros pretos da roleta
        /// </summary>
        public static int[] NumerosPretos
        {
            get{ return numerosPretos; }
        }

        /// <summary>
        /// Todos os numeros vermelhos da roleta
        /// </summary>
        public static int[] NumerosVermelhos
        {
            get { return numerosVermelhos; }
        }
        #endregion

        #region OUTROS
        /// <summary>
        /// Roda a roleta
        /// </summary>
        /// <returns>Retorna um valor inteiro que saiu na roleta</returns>
        public static int GiraRoleta()
        {
            return GeraNumero();
        }

        /// <summary>
        /// Gerar numero aleatóriamente entre 0 e 36
        /// </summary>
        /// <returns>Retorna um inteiro entre 0 e 36</returns>
        private static int GeraNumero()
        {
            //Variaveis do metodo
            Random random = new Random();
            int valor;

            //atribuir valor random
            valor = random.Next(37);
            
            //retornar o valor gerado aleatóriamente
            return valor;
        }
        #endregion

        #endregion
    }
}

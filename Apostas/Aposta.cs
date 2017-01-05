/*
<version>0.1</version>
<author>Rui Sousa</author>
<mail>mcruso@hotmail.com</mail>
<date>2016-02-20</date>
<description>Enums</description>
*/
namespace Apostas
{
    /// <summary>
    /// Uma aposta tem um id, uma casa onde se pretende jogar e um valor que representa quanto se pretende apostar
    /// </summary>
    public class Aposta
    {
        #region ESTADO

        int id;
        int casa; //A "casa" no tabuleiro que se pretende preencher com a aposta
        int valor;
        static int incrementaId = 0;

        #endregion

        #region MÉTODOS

        #region CONSTRUTOR

        /// <summary>
        /// Um objeto de aposta por defeito, sem valores definidos
        /// </summary>
        public Aposta()
        {
            incrementaId++;
            id = incrementaId;
            casa = -1;
            valor = 0;
        }

        /// <summary>
        /// Uma aposta que recebe todos os parametros, casa e valor da aposta
        /// </summary>
        /// <param name="casa">A casa do taboleiro que se pretende apostar</param>
        /// <param name="valor">O valor da aposta</param>
        public Aposta(int casa, int valor)
        {
            incrementaId++;
            id = incrementaId;
            this.casa = casa;
            this.valor = valor;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade ID
        /// </summary>
        public int Id
        {
            get { return id; } //Apenas se pode perguntar o id
        }

        /// <summary>
        /// Propriedade Casa
        /// </summary>
        public int Casa
        {
            get { return casa; }
            set { casa = value; }
        }

        /// <summary>
        /// Propriedade valor
        /// </summary>
        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        #endregion

        #region Outros

        /// <summary>
        /// Passa a informação da aposta para string
        /// </summary>
        /// <returns>Uma string com as informações da aposta</returns>
        public override string ToString()
        {
            return "[\n Aposta " + id + ": \n - Casa: " + casa + "; \n - Valor: " + valor + " \n]";
        }
        #endregion

        #endregion
    }
}

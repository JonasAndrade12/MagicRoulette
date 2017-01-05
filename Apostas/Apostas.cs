/*
<version>1.0</version>
<author>Rui Sousa</author>
<mail>mcruso@hotmail.com</mail>
<date>2016-02-20</date>
<description>Classe que armazena todas as apostas do utilizador</description>
*/
using System;
using System.Collections.Generic;
using System.Linq;


namespace Apostas
{
    /// <summary>
    /// Apostas cooresponde a um conjunto de apostas
    /// </summary>
    [Serializable]
    public class Apostas
    {
        #region ATRIBUTOS

        static List<Aposta> todas = new List<Aposta>();

        #endregion

        #region METODOS

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade Todas
        /// </summary>
        public static List<Aposta> Todas
        {
            get { return todas; }
        }
        #endregion

        #region OUTROS

        /// <summary>
        /// Insere uma nova aposta na lista de apostas
        /// </summary>
        /// <param name="aposta">A aposta a ser inserida</param>
        /// <returns>Retorna verdadeiro se inserir com sucesso ou false se nao inserir</returns>
        public static bool NovaAposta(Aposta  aposta)
        {
            if (ValidaAposta(aposta))
            {
                todas.Add(aposta);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove uma aposta da lista
        /// </summary>
        /// <param name="id">Id da aposta a ser removida</param>
        /// <returns>Verdadeiro se remover ou false se nao remover</returns>
        public static bool RemoveAposta(int id)
        {
            Aposta ApostaRemover = new Aposta();

            foreach (Aposta aposta in todas)
            {
                if (aposta.Id == id)
                {
                    ApostaRemover = aposta;
                }
            }

            return todas.Remove(ApostaRemover);
        }

        /// <summary>
        /// Remove todas as apostas guardadas na lista de apostas
        /// </summary>
        public static void RemoveTodasApostas()
        {
            todas.Clear();
        }

        /// <summary>
        /// O total de apostas
        /// </summary>
        /// <returns>Retorna o total de apostas que existem na lista</returns>
        public static int TotalApostas()
        {
            return todas.Count();
        }

        /// <summary>
        /// Passa todas as apostas que estão registadas na lista para um array
        /// </summary>
        /// <returns>Um array com todas as apostas</returns>
        public static Aposta[] TodasApostasArray()
        {
            int totalApostas = todas.Count();
            int i = 0;
            Aposta[] apostas = new Aposta[totalApostas];

            foreach (Aposta aposta in todas)
            {
                apostas[i] = aposta;
                i++;
            }

            return apostas;
        }

        #region METODO ValidaAposta
        /// <summary>
        /// Valida se uma aposta é valida ou não
        /// </summary>
        /// <param name="aposta">Objeto de aposta a verificar</param>
        /// <returns>Verdadeiro se nao houver problemas ou false se houver algo errado</returns>
        public static bool ValidaAposta(Aposta aposta)
        {
            if (aposta.Casa < 0 || aposta.Casa > 42)
            {
                return false;
            }

            if (aposta.Valor <= 0)
            {
                return false;
            }

            return true;

        }

        #endregion

        /// <summary>
        /// Mostra todas as apostas na lista
        /// </summary>
        public static void MostraApostas()
        {
            foreach (var aposta in todas)
            {
                Console.WriteLine(aposta.ToString());
            }
        }
        #endregion

        #endregion
    }
}

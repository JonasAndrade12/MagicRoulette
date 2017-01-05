/*
<version>1.1</version>
<author>Jonas Andrade</author>
<mail>jonas_andrade@live.com.pt</mail>
<date>2016-02-20</date>
<description>Classe responsavel por calcular o premio das apostas</description>   
*/

using Apostas;
using MetodosLib;
using Roleta;

namespace Premio
{
    /// <summary>
    /// Classe que calcula o valor do premio das apostas em função do numero que saiu na roleta
    /// </summary>
    public class Premio
    {
        #region ATRIBUTOS
        #endregion

        #region METODOS

        /// <summary>
        /// calcula os ganhos do utilizador para um array de apostas e o valor que saiu na roleta
        /// </summary>
        /// <param name="apostas">As apostas</param>
        /// <param name="resultado">O valor que saiu na roleta</param>
        /// <returns>O total dos ganhos</returns>
        public static int CalculaPremio(Aposta[] apostas, int resultado)
        {
            //variaveis do metodo
            int tamanhoArray = apostas.Length;
            int totalPremio = 0; 
            int premio = 0;

            /*
            Regras baseadas na roleta europeia
            */

            //Ciclo que percorre todas as apostas do utilizador
            for (int i = 0; i < tamanhoArray; i++)
            {
                premio = 0;

                //acertar num numero específico
                if (apostas[i].Casa >= 0 && apostas[i].Casa <= 36 && apostas[i].Casa == resultado)
                {
                    premio = apostas[i].Valor * 36; /*é 36 porque tem de incluir o valor apostado*/
                    totalPremio += premio;
                }

                //acertar par
                if (resultado % 2 == 0 && apostas[i].Casa == (int)EnumLegenda.par)
                {
                    premio = apostas[i].Valor * 2; /*numa probabilidade 50/50, o valor é multiplicado por 2*/
                    totalPremio += premio;
                }

                //acertar impar
                else if (resultado % 2 != 0 && apostas[i].Casa == (int)EnumLegenda.impar)
                {
                    premio = apostas[i].Valor * 2;
                    totalPremio += premio;
                }

                //acertar pequeno
                if ((resultado > 0 && resultado < 19) && apostas[i].Casa == (int)EnumLegenda.pequeno)//Parentices é so por via das duvidas, e mesmo importante que ele faça as duas primeiras
                {
                    premio = apostas[i].Valor * 2;
                    totalPremio += premio;
                }

                //acertar grande
                else if ((resultado > 18 && resultado < 37) && apostas[i].Casa == (int)EnumLegenda.grande)//Parentices é so por via das duvidas, e mesmo importante que ele faça as duas primeiras
                {
                    premio = apostas[i].Valor * 2;
                    totalPremio += premio;
                }

                //Se acertar no vermelho
                if (Metodos.ExisteNoArray(Roleta.Roleta.NumerosVermelhos, resultado) && apostas[i].Casa == (int)EnumLegenda.vermelho)
                {
                    premio = apostas[i].Valor * 2;
                    totalPremio += premio;
                }

                //Se acertar no preto
                else if (Metodos.ExisteNoArray(Roleta.Roleta.NumerosPretos, resultado) && apostas[i].Casa == (int)EnumLegenda.preto)
                {
                    premio = apostas[i].Valor * 2;
                    totalPremio += premio;
                }
            }

            //Devolve o valor total do premio acomulado pelo utilizador
            return totalPremio;
        }
        #endregion
    }
}

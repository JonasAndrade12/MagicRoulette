/*
<version>1.0</version>
<authors>
  <author>Jonas Andrade</author>
  <author>Rui Sousa</author>
  <author>Tiago Mendes</author>
</authors>
<mail>mcruso@hotmail.com</mail>
<date>2016-02-20</date>
<description>Classe com procedimentos úteis no programa em geral</description>
*/

using System;

namespace MetodosLib
{
    /// <summary>
    /// Classe com procedimentos variados para o decorrer do programa
    /// </summary>
    public class Metodos
    {

        #region METODO ExisteNoArray
        /// <summary>
        /// Procura se determinado valor inteiro existe num array
        /// </summary>
        /// <param name="array">Array onde se tenciona procurar</param>
        /// <param name="valor">Valor inteiro que se pretende encontrar</param>
        /// <returns>Verdadeiro se encontrar ou falso se nao encontrar</returns>
        public static bool ExisteNoArray(int[] array, int valor)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == valor)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region METODO MostraMesaJogo
        /// <summary>
        /// Mostra a mesa de jogo
        /// </summary>
        public static void MostraMesaJogo()
        {
            //Variaveis do metodo
            int[] preto = Roleta.Roleta.NumerosPretos;
            int[] vermelho = Roleta.Roleta.NumerosVermelhos;

            /*Apresentar o 0*/
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("    0    ");

            //Percorrer todos os numeros do jogo
            for (int i = 1; i < 37; i++)
            {
                //Se a posição do i atual existir no array de numeros pretos, entao imprime o numero em preto
                if (ExisteNoArray(preto, i) == true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    if (i < 10)
                    {
                        Console.Write(" 0" + i);
                    }
                    else
                    {
                        Console.Write(" " + i);
                    }

                }

                //Se a posição do i atual existir no array de numeros vermelhos, entao imprime o numero em vermelho
                if (ExisteNoArray(vermelho, i) == true)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    if (i < 10)
                    {
                        Console.Write(" 0" + i);
                    }
                    else
                    {
                        Console.Write(" " + i);
                    }
                }

                if (i == 12 | i == 24)
                {
                    Console.Write("\n");
                }
            }

            //Imprimir apostas especiais 50/50 chance
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     37 - Preto  | 38 - Vermelho    ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     39 - Par    | 40 - Impar       ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     41 - Grande | 42 - Pequeno     ");

            Console.ResetColor(); /* voltar a cor normal*/
        }
        #endregion

        #region METODO EfeitoRoletaBonito
        /// <summary>
        /// Imprime um efeito de rodar a roleta
        /// </summary>
        /// <param name="valor">O valor onde a roleta tem de parar</param>
        public static void EfeitoRoletaBonito(int valor)
        {
            //variaveis do metodo
            int contador1 = 0;
            int numerosRoleta = 0;
            int[] todosNumerosRoleta = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 32, 33, 34, 35, 36 };
            bool umaVolta = false;
            int numerosRoletaMenos2 = 0;
            int numerosRoletaMenos1 = 0;
            int numerosRoletaMais1 = 0;
            int numerosRoletaMais2 = 0;

            //Contagem decrescente para rodar roleta
            for (int i = 3; i > -1; i--)
            {
                Console.Clear();
                Console.Write("A rodar roleta em {0}", i);
                System.Threading.Thread.Sleep(1000);
            }

            //Aqui a roleta gira mesmo
            for (int i = 0; i < 80; i++)
            {
                // Calcula os dois valores a frente e atras que aparecem no crã
                numerosRoletaMenos2 = numerosRoleta - 2;
                numerosRoletaMenos1 = numerosRoleta - 1;
                numerosRoletaMais1 = numerosRoleta + 1;
                numerosRoletaMais2 = numerosRoleta + 2;

                //Quando o valor atual da roleta e 0 podia aparecer o -1 e o -2, isto resolve essa situação
                numerosRoletaMenos2 = VerificaNumeroRoleta(numerosRoletaMenos2);
                numerosRoletaMenos1 = VerificaNumeroRoleta(numerosRoletaMenos1);
                numerosRoletaMais1 = VerificaNumeroRoleta(numerosRoletaMais1);
                numerosRoletaMais2 = VerificaNumeroRoleta(numerosRoletaMais2);

                if (contador1 < 15) //Velocidade 1
                {
                    Console.Clear();
                    Console.WriteLine(" \n");
                    Console.WriteLine(" ---------------------------------- ");
                    Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", numerosRoletaMenos2.ToString("00"), numerosRoletaMenos1.ToString("00"),
                        numerosRoleta.ToString("00"), numerosRoletaMais1.ToString("00"), numerosRoletaMais2.ToString("00"));
                    Console.WriteLine("                 ^^                   ");
                    System.Threading.Thread.Sleep(50);

                }
                else if (contador1 < 25) //Velocidade 2
                {
                    Console.Clear();
                    Console.WriteLine(" \n");
                    Console.WriteLine(" ---------------------------------- ");
                    Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", numerosRoletaMenos2.ToString("00"), numerosRoletaMenos1.ToString("00"),
                        numerosRoleta.ToString("00"), numerosRoletaMais1.ToString("00"), numerosRoletaMais2.ToString("00"));
                    Console.WriteLine("                 ^^                   ");
                    System.Threading.Thread.Sleep(100);

                }
                else if (contador1 < 36) //Velocidade 3
                {
                    Console.Clear();
                    Console.WriteLine(" \n");
                    Console.WriteLine(" ---------------------------------- ");
                    Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", numerosRoletaMenos2.ToString("00"), numerosRoletaMenos1.ToString("00"),
                        numerosRoleta.ToString("00"), numerosRoletaMais1.ToString("00"), numerosRoletaMais2.ToString("00"));
                    Console.WriteLine("                 ^^                   ");
                    System.Threading.Thread.Sleep(150);

                }
                else //Velocidade 4
                {
                    Console.Clear();
                    Console.WriteLine(" \n");
                    Console.WriteLine(" ---------------------------------- ");
                    Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", numerosRoletaMenos2.ToString("00"), numerosRoletaMenos1.ToString("00"),
                        numerosRoleta.ToString("00"), numerosRoletaMais1.ToString("00"), numerosRoletaMais2.ToString("00"));
                    Console.WriteLine("                 ^^                   ");
                    System.Threading.Thread.Sleep(200);
                }

                if (numerosRoleta == valor && umaVolta == true) //Aqui é onde para quando encontrar o numero igual ao que foi sorteado
                {
                    Console.Clear();
                    Console.WriteLine(" \n");
                    Console.WriteLine(" ---------------------------------- ");
                    Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", numerosRoletaMenos2.ToString("00"), numerosRoletaMenos1.ToString("00"),
                        numerosRoleta.ToString("00"), numerosRoletaMais1.ToString("00"), numerosRoletaMais2.ToString("00"));
                    Console.WriteLine("                 ^^                   ");
                    Console.WriteLine(" ");
                    Console.Write("> Saiu o numero ");

                    if (valor == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(valor);
                        Console.ResetColor(); /* voltar a cor normal*/
                    }
                    else if (ExisteNoArray(Roleta.Roleta.NumerosVermelhos, valor))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(valor);
                        Console.ResetColor(); /* voltar a cor normal*/
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(valor);
                        Console.ResetColor(); /* voltar a cor normal*/
                    }

                    break;
                }

                numerosRoleta++;
                contador1++;

                if (numerosRoleta > 36)
                {
                    numerosRoleta = 0;
                    umaVolta = true;
                }
            }
        }
        #endregion

        #region METODO VerificaNumeroRoleta
        /// <summary>
        /// Nao deixa que apareçam -2 ou -1 assim como 37 e 38 na apresentação da roleta
        /// </summary>
        /// <param name="numero">Numero a verificar</param>
        /// <returns>Retorna o mesmo valor se nao houver problema ou um corrigido se houver problema</returns>
        public static int VerificaNumeroRoleta(int numero)
        {
            if (numero < 0)
            {
                return 37 + numero;
            }

            if (numero > 36)
            {
                return numero - 37;
            }

            return numero;
        }
        #endregion

    }
}

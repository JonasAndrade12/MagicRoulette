/*
<version>2.0</version>
<authors>
  <author>Jonas Andrade - 10506</author>
  <author>Rui Sousa - 12564</author>
  <author>Tiago Mendes - 10603</author>
</authors>
<date>2016-02-20</date>
<description>Roleta de multiplas apostas e ganhos de cada aposta</description>
*/

using System;
using Apostas;
using Premio;
using MetodosLib;

namespace Roleta_Mágica
{
    class Program
    {

        static void Main(string[] args)
        {
            //Variaveis
            int saldo;
            int numJogadas = 0;
            string decisaoAposta = "";
            int valorAposta;  
            int casaAposta;
            bool inserirAposta = false;
            int valorRoleta;
            int premio = 0;

            //Introduzir o saldo inicial
            Console.Write("Introduza o saldo que deseja: ");
            saldo = int.Parse(Console.ReadLine());
            Console.Clear();

            do
            {
                
                do
                {
                    //Imprimir mesa
                    
                    Console.Clear();
                    Metodos.MostraMesaJogo();
                    Console.WriteLine();
                    Console.Write("[Saldo: {0} ]  [Numero de jogadas: {1}]  [Apostas: {2}]", saldo, numJogadas, Apostas.Apostas.TotalApostas());
                    Console.WriteLine(" \n");
                    Console.Write("Deseja fazer uma aposta? (s/n) ");
                    decisaoAposta = Console.ReadLine();

                    if (decisaoAposta == "" || decisaoAposta == "s")
                    {
                        //Estética
                        Console.Clear();
                        Metodos.MostraMesaJogo();

                        //Pedir dados sobre a aposta
                        Console.WriteLine();
                        Console.Write("[Saldo: {0} ]  [Numero de jogadas: {1}]  [Apostas: {2}]", saldo, numJogadas, Apostas.Apostas.TotalApostas());
                        Console.WriteLine(" \n");
                        Console.Write("Qual é a casa que quer apostar? ");
                        casaAposta = int.Parse(Console.ReadLine());
                        Console.Write("Qual é o valor que quer apostar? ");
                        valorAposta = int.Parse(Console.ReadLine());

                        //criar aqui um novo objeto de aposta para inserir na lista
                        Aposta aposta = new Aposta();
                        aposta.Casa = casaAposta;
                        aposta.Valor = valorAposta;

                        /*Verifica se tem saldo suficiente antes de criar a aposta*/
                        if (saldo >= valorAposta)
                        {
                            //tentar inserir a aposta na lista de apostas
                            inserirAposta = Apostas.Apostas.NovaAposta(aposta);
                            saldo -= valorAposta;
                            /* confirma a inserção da aposta*/
                            if (inserirAposta == false)
                            {
                                Console.Write("A aposta nao foi inserida porque é inválida, tente novamente.");
                                Console.ReadKey();
                            }
                            if (inserirAposta == true)
                            {
                                Console.Write("A aposta foi inserida com sucesso!");
                                Console.ReadKey();
                            }
                        }

                        else
                        {
                            Console.WriteLine("Saldo insuficiente!");
                            Console.ReadKey();

                        }

                    }

                } while (decisaoAposta == "" || decisaoAposta == "s");

                //mostrar apostas
                Console.Clear();
                Console.WriteLine("-----[ Apostas Registadas ]-----");
                Apostas.Apostas.MostraApostas();
                Console.Write("Enter para continnuar...");
                Console.ReadKey();

                //Rodar a Roleta
                valorRoleta = Roleta.Roleta.GiraRoleta();
                Metodos.EfeitoRoletaBonito(valorRoleta);
                Console.ReadKey();

                //Calcular premio
                Console.Clear();
                Console.WriteLine("A calcular premio...");
                System.Threading.Thread.Sleep(200);
                premio = Premio.Premio.CalculaPremio(Apostas.Apostas.TodasApostasArray(), valorRoleta);
                Console.WriteLine("Retorno de {0} Euros", premio);
                saldo += premio;
                Console.ReadKey();

                //Apagar todas as apostas
                Apostas.Apostas.RemoveTodasApostas();
                numJogadas++;

            } while (saldo > 0);

            Console.WriteLine("Parece que ficou sem saldo");
            System.Threading.Thread.Sleep(300);
            Console.WriteLine("A encerrar programa");
            System.Threading.Thread.Sleep(3000);

        }
    }
}

using System;
using System.Threading;

namespace Batalha2
{
    //Trava caso o jogador coloque uma opção não válida
    /*while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "7" && op != "8")
    {
        Console.WriteLine("ERRO! O valor digitado não corresponde a nenhuma opção, tente novamente");
        Console.Write("\nDigite sua escolha: ");
        op = Console.ReadLine();
        Console.WriteLine("");
    }*/

    class Program
    {
        //Atributos de player (para definir o player atual) e de escolha de opções
        static int player = 1;
        static string op = null;


        // Atributos do Jogador 1
        static int forca_1, Vida_Player_1 = 100, Mana_Player_1 = 10, Poção_de_Cura_1 = 0, Poção_de_Mana_1 = 0, Poção_Estranha_1 = 0, Poções_1 = Poção_Estranha_1 + Poção_de_Mana_1 + Poção_de_Cura_1, queimadura_1 = 0, armadura_1 = 0, manto_1 = 0, espada_1 = 0, enfraquecimento_p1 = 0, campo_forca1 = 0;
        static bool Paralizado_1 = false, runas_1, Confusão_p1 = false;
        static string[] magias_p1 = { "0", "0", "0" };


        // Atributos do Jogador 2
        static int forca_2, Vida_Player_2 = 100, Mana_Player_2 = 10, Poção_de_Cura_2 = 0, Poção_de_Mana_2 = 0, Poção_Estranha_2 = 0, Poções_2 = Poção_Estranha_2 + Poção_de_Mana_2 + Poção_de_Cura_2, queimadura_2 = 0, armadura_2 = 0, manto_2 = 0, espada_2 = 0, enfraquecimento_p2 = 0, campo_forca2 = 0;
        static bool Paralizado_2 = false, runas_2, Confusão_p2 = false;
        static string[] magias_p2 = { "0", "0", "0" };


        // Atributos para o Modo Singleplayer
        static bool Singleplayer = false;
        static int Vida_Boss = 100, Mana_Boss = 20;


        static void Main()
        {
            //desenha DUEL
            DesenharLogo();

            //Regras
            Console.WriteLine(@"


Bem vindo a Duel!!! O jogo funciona da seguinte forma:

|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
|1º. Para começa, você deve selecionar um modo de jogo, SinglePlayer ou MultiPlayer                                                                            |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
|2º. Caso você selecione SinglePlayer, você irá lutar contra um inimigo controlado pelo computador                                                             |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
|3º. Se você selecionar MultiPlayer, você e outro jogador poderão se enfrentar em uma série de turnos                                                          |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
|4º. Seu objetivo é levar seu adversário 0 de Vida o atacando, lançando poderosas magias, que consomem sua Mana, e usando seus itens, de um estoque limitado   |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------|

IMPORTANTE!!! Para selecionar uma opção digite o apenas número dela

Se você entendeu, pressione ENTER");


            //Trava
            Console.ReadLine();
            Console.Clear();


            //Escolher entre SinglePlayer e MultiPlayer
            EscolherPartida();


            //Envia para a Loja (comprar itens)
            Loja();


            //Envia para o "Menu" de Atributos (Escolher os valores de Força (que afeta a Mana))
            EscolherAtributos();


            //Envia para o "Menu" de escolha de Magias
            EscolherMagias();


            //Verificação do tipo de partida escolhido, enviando para o Método específico para que a ordem de turnos esteja certa
            if (Singleplayer == false) //Caso a Partida seja MultiPlayer
            {
                BatalhaMultiplayer();
            }
            else if (Singleplayer == true)
            {
                BatalhaSingleplayer(); //Caso a partida seja Singleplayer
            }
        }


        static void DesenharLogo()
        {
            Thread.Sleep(200);
            Console.WriteLine(@"                                                                                   ██████████                       ████ 
                                                                                  ░░███░░░░███                     ░░███ ");
            Thread.Sleep(200);
            Console.WriteLine(@"                                                                                   ░███   ░░███ █████ ████  ██████  ░███ 
                                                                                   ░███    ░███░░███ ░███  ███░░███ ░███ ");
            Thread.Sleep(200);
            Console.WriteLine(@"                                                                                   ░███    ░███ ░███ ░███ ░███████  ░███ 
                                                                                   ░███    ███  ░███ ░███ ░███░░░   ░███ ");
            Thread.Sleep(200);
            Console.WriteLine(@"                                                                                   ██████████   ░░████████░░██████  █████
                                                                                  ░░░░░░░░░░     ░░░░░░░░  ░░░░░░  ░░░░░ ");
        }


        static void EscolherPartida()
        {
            //Estético
            Console.WriteLine(@"
░▀█▀░█▀█░▀█▀░█▀▀░▀█▀░█▀█░█▀▄░░░▀▀█░█▀█░█▀▀░█▀█
░░█░░█░█░░█░░█░░░░█░░█▀█░█▀▄░░░░░█░█░█░█░█░█░█
░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀░▀░░░▀▀░░▀▀▀░▀▀▀░▀▀▀
           ");


            //Opções
            Console.WriteLine("1. SinglePlayer");
            Console.WriteLine("2. MultiPlayer");


            //Entrar sua escolha
            Console.Write("\nDigite sua escolha: ");
            op = Console.ReadLine();


            //Verificação da escolha
            if (op == "1") //Caso o jogador decida jogar SinglePlayer, bool SinglePlayer = true
            {
                Singleplayer = true;
                Console.WriteLine("\nVocê escolheu o modo SinglePlayer");
            }
            else if (op == "2") //Caso o jogador decida jogar MultiPlayer, bool SinglePlayer == false
            {
                Singleplayer = false;
                Console.WriteLine("\nVocê escolheu o modo MultiPlayer");
            }
            

            //Trava
            Console.WriteLine("\nAperte ENTER para continuar");
            Console.ReadLine();
            Console.Clear();
        }


        static void Loja()
        {
            //Saldo dos dois players
            int saldo_1 = 100;
            int saldo_2 = 100;


            //Estético
            Console.WriteLine("Bem vindo a loja Player 1! Aqui você poderá comprar itens que te ajudarão durante sua batalha");


            //Enquanto o saldo do jogador for maior que 0 e ele não escolher a opção de sair da loja ele continuará nesse ciclo, podendo continuar comprando o que seu saldo permitir
            while (saldo_1 > 0 && op != "8")
            {
                //Quantidade (usada para itens que podem ser comprados em mais de uma unidade). Colocando essa variável nessa posição ela sempre reseta quando o ciclo recomeçar
                int quantidade = 0;


                //Mostra as opções que o jogador pode comprar
                OpsLoja();


                //Mostra o saldo e pergunta o que o jogador gostaria de comprar
                Console.WriteLine($"\nSeu saldo: {saldo_1}");
                Console.WriteLine("\n\nO que você gostaria de comprar?");


                //Entrar sua escolha
                Console.Write("Digite sua escolha: ");
                op = Console.ReadLine();
                Console.WriteLine("");


                //Opções de compra
                if (op == "1") //Caso o jogador queira comprar poções de vida
                {
                    //Definir quantas unidades o jogador quer
                    Console.WriteLine("Quantas unidades você gostaria de comprar?");
                    quantidade = int.Parse(Console.ReadLine());

                    //Caso o saldo do jogador seja insuficiente para comprar a quantidade requisitada, ele deve definir uma nova quantidade
                    while ((saldo_1 - quantidade * 10) < 0)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                        quantidade = int.Parse(Console.ReadLine());
                    }

                    //Retira do saldo o valor do produto vezes a quantidade requisitada e entrega para o jogador a quantidade de produto comprada
                    saldo_1 -= 10 * quantidade;
                    Poção_de_Cura_1 += quantidade;

                    //Mostra quanto o jogador comprou e quanto ele gastou
                    Console.WriteLine($"Você comprou {quantidade} poções de cura e gastou {10 * quantidade} pila");

                    //Trava
                    Console.WriteLine("\n Digite ENTER para continuar");
                    Console.ReadLine();
                }
                if (op == "2") //Caso o jogador queira comprar poções de mana
                {
                   //Definir quantas unidades o jogador quer
                    Console.WriteLine("Quantas unidades você gostaria de comprar? Digite 0 para cancelar a compra");
                    quantidade = int.Parse(Console.ReadLine());

                    //Caso o jogador não tenha cancelado a compra (digitado 0)
                    if (quantidade != 0)
                    {
                        //Caso o saldo do jogador seja insuficiente para comprar a quantidade requisitada, ele deve definir uma nova quantidade
                        while ((saldo_1 - quantidade * 15) < 0)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                            quantidade = int.Parse(Console.ReadLine());
                        }

                        //Retira do saldo o valor do produto vezes a quantidade requisitada e entrega para o jogador a quantidade de produto comprada
                        saldo_1 -= 15 * quantidade;
                        Poção_de_Mana_1 += quantidade;

                        //Mostra quanto o jogador comprou e quanto ele gastou
                        Console.WriteLine($"Você comprou {quantidade} poções de mana e gastou {15 * quantidade} pila");

                        //Trava
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                }
                if (op == "3") //Caso o jogador queira comprar a poção estranha
                {
                    //Confirmação da compra
                    Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                    op = Console.ReadLine();

                    //Caso o jogador confirme a compra
                    if (op == "1")
                    {
                        saldo_1 -= 1; 
                        Poção_Estranha_1 = 1;
                        Console.WriteLine($"Você comprou 1 poção estranha e gastou 1 pila");

                        //Trava
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                }
                if (op == "4") //Caso o jogador queira comprar a armadura
                {
                    if (saldo_1 < 30)
                    {
                        //Trava de saldo
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        //Confirmação da compra
                        Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                        op = Console.ReadLine();

                        //Caso o jogador confirme a compra
                        if (op == "1")
                        {
                            armadura_1 = 10;
                            saldo_1 -= 30;
                            Console.WriteLine("Você gastou 30 pila e conseguiu uma armadura de malha capaz de te proteger de ataques corpo-a-corpo");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                }

                if (op == "5") //Caso o jogador queira comprar o manto
                {
                    //Trava de saldo
                    if (saldo_1 < 40)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        //Confirmação da compra
                        Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                        op = Console.ReadLine();

                        //Caso o jogador confirme a compra
                        if (op == "1")
                        {
                            armadura_1 = 5;
                            saldo_1 -= 40;
                            Console.WriteLine("Você gastou 40 pila e comprou robes capazes de te proteger de efeitos mágicos");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                }

                if (op == "6") //Caso o jogador queira comprar a espada
                {
                    //Trava de saldo
                    if (saldo_1 < 30)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        //Confirmação da compra
                        Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                        op = Console.ReadLine();

                        //Caso o jogador confirme a compra
                        if (op == "1")
                        {
                            espada_1 = 10;
                            saldo_1 -= 30;
                            Console.WriteLine("Você gastou 30 pila e conseguiu uma espada melhor");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                }

                if (op == "7") //Caso o jogador queira comprar as runas
                {
                    //Trava de saldo
                    if (saldo_1 < 40)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        //Confirmação da compra
                        Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                        op = Console.ReadLine();

                        //Caso o jogador confirme a compra
                        if (op == "1")
                        {
                            runas_1 = true;
                            saldo_1 -= 40;
                            Console.WriteLine("Você gastou 40 pila e comprou runas que emitem uma forte energia mágica");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                }
                Console.Clear();
            }


            //Trava
            Console.WriteLine("Obrigado pela preferência! Volte sempre");
            Console.WriteLine("\n\nDigite ENTER para continuar");
            Console.ReadLine();


            //Caso o modo escolhido seja o MultiPlayer, o player 2 poderá comprar seus itens
            if (Singleplayer == false)
            {
                //Estético
                Console.WriteLine("Bem vindo a loja player 2! Aqui você poderá comprar itens que te ajudarão durante sua batalha");


                //Enquanto o saldo do jogador for maior que 0 e ele não escolher a opção de sair da loja ele continuará nesse ciclo, podendo continuar comprando o que seu saldo permitir
                while (saldo_2 > 0 && op != "8")
                {
                    //Quantidade (usada para itens que podem ser comprados em mais de uma unidade). Colocando essa variável nessa posição ela sempre reseta quando o ciclo recomeçar
                    int quantidade = 0;


                    //Mostra as opções que o jogador pode comprar
                    OpsLoja();


                    //Mostra o saldo e pergunta o que o jogador gostaria de comprar
                    Console.WriteLine($"\nSeu saldo: {saldo_2}");
                    Console.WriteLine("\n\nO que você gostaria de comprar?");


                    //Entrar sua escolha
                    Console.Write("Digite sua escolha: ");
                    op = Console.ReadLine();
                    Console.WriteLine("");


                    //Opções de compra
                    if (op == "1") //Caso o jogador queira comprar poções de vida
                    {
                        //Definir quantas unidades o jogador quer
                        Console.WriteLine("Quantas unidades você gostaria de comprar?");
                        quantidade = int.Parse(Console.ReadLine());

                        //Caso o saldo do jogador seja insuficiente para comprar a quantidade requisitada, ele deve definir uma nova quantidade
                        while ((saldo_2 - quantidade * 10) < 0)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                            quantidade = int.Parse(Console.ReadLine());
                        }

                        //Retira do saldo o valor do produto vezes a quantidade requisitada e entrega para o jogador a quantidade de produto comprada
                        saldo_2 -= 10 * quantidade;
                        Poção_de_Cura_2 += quantidade;

                        //Mostra quanto o jogador comprou e quanto ele gastou
                        Console.WriteLine($"Você comprou {quantidade} poções de cura e gastou {10 * quantidade} pila");

                        //Trava
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    if (op == "2") //Caso o jogador queira comprar poções de mana
                    {
                        //Definir quantas unidades o jogador quer
                        Console.WriteLine("Quantas unidades você gostaria de comprar? Digite 0 para cancelar a compra");
                        quantidade = int.Parse(Console.ReadLine());

                        //Caso o jogador não tenha cancelado a compra (digitado 0)
                        if (quantidade != 0)
                        {
                            //Caso o saldo do jogador seja insuficiente para comprar a quantidade requisitada, ele deve definir uma nova quantidade
                            while ((saldo_2 - quantidade * 15) < 0)
                            {
                                Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                                quantidade = int.Parse(Console.ReadLine());
                            }

                            //Retira do saldo o valor do produto vezes a quantidade requisitada e entrega para o jogador a quantidade de produto comprada
                            saldo_2 -= 15 * quantidade;
                            Poção_de_Mana_2 += quantidade;

                            //Mostra quanto o jogador comprou e quanto ele gastou
                            Console.WriteLine($"Você comprou {quantidade} poções de mana e gastou {15 * quantidade} pila");

                            //Trava
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                    if (op == "3") //Caso o jogador queira comprar a poção estranha
                    {
                        //Confirmação da compra
                        Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                        op = Console.ReadLine();

                        //Caso o jogador confirme a compra
                        if (op == "1")
                        {
                            saldo_2 -= 1;
                            Poção_Estranha_2 = 1;
                            Console.WriteLine($"Você comprou uma poção estranha e gastou 1 pila");

                            //Trava
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                    if (op == "4") //Caso o jogador queira comprar a armadura
                    {
                        if (saldo_2 < 30)
                        {
                            //Trava de saldo
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            //Confirmação da compra
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            //Caso o jogador confirme a compra
                            if (op == "1")
                            {
                                armadura_2 = 10;
                                saldo_2 -= 30;
                                Console.WriteLine("Você gastou 30 pila e conseguiu uma armadura de malha capaz de te proteger de ataques corpo-a-corpo");
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }

                    if (op == "5") //Caso o jogador queira comprar o manto
                    {
                        //Trava de saldo
                        if (saldo_2 < 40)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            //Confirmação da compra
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            //Caso o jogador confirme a compra
                            if (op == "1")
                            {
                                armadura_2 = 5;
                                saldo_2 -= 40;
                                Console.WriteLine("Você gastou 40 pila e comprou robes capazes de te proteger de efeitos mágicos");
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }

                    if (op == "6") //Caso o jogador queira comprar a espada
                    {
                        //Trava de saldo
                        if (saldo_2 < 30)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            //Confirmação da compra
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            //Caso o jogador confirme a compra
                            if (op == "1")
                            {
                                espada_2 = 10;
                                saldo_2 -= 30;
                                Console.WriteLine("Você gastou 30 pila e conseguiu uma espada melhor");
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }

                    if (op == "7") //Caso o jogador queira comprar as runas
                    {
                        //Trava de saldo
                        if (saldo_2 < 40)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            //Confirmação da compra
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            //Caso o jogador confirme a compra
                            if (op == "1")
                            {
                                runas_2 = true;
                                saldo_2 -= 40;
                                Console.WriteLine("Você gastou 40 pila e comprou runas que emitem uma forte energia mágica");
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }
                    Console.Clear();
                }
            }

            //Trava
            Console.WriteLine("Obrigado pela preferência! Volte sempre");
            Console.WriteLine("\n\nDigite ENTER para continuar");
            Console.ReadLine();
            Console.Clear();
        }


        static void OpsLoja()
        {
            //Sumário (explica o que cada tipo de item significa) + opções de poção de cura, poção de mana e poção estranha
            Console.WriteLine(@"
|----------------------------------------------------------------------------------------------------|
|Sumário                                                                                             |
|Consumíveis: Cada unidade é perdida após o uso                                                      |
|Armaduras: Afetam sua resistência contra efeitos de certo tipo, só é possível carregar uma por vez  |
|Equipamentos: Afetam suas ações de ataque e magias                                                  |
|----------------------------------------------------------------------------------------------------|


1. Poção de Cura: Restaura sua saúde.
Consumível, recupera 20 de vida, custa 10 pila cada unidade

2. Poção de Mana: Recupera parte da sua energia mágica. 
Consumível, recupera 5 de mana, custa 15 pila cada unidade");


            //Opções que irão desaparecer caso o jogador as compre
            if (player == 1 && Poção_Estranha_1 == 0 || player == 2 && Poção_Estranha_2 == 0)
            {
                Console.WriteLine("3. Poção Estranha: Um líquido preto estranho que se contorce dentro do frasco, não fazemos ideia do que pode fazer, tome por sua conta e risco. \nConsumível, ???????????, custa 1 pila");
            }
            if (player == 1 && armadura_1 == 0 || (player == 2 && armadura_2 == 0)) //Mostrar a opção de armadura caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n4. Armadura de Cota de Malha: Uma armadura feita de argolas de ferro, eficiente contra ataques corpo-a-corpo. \nArmadura, reduz 10 de dano de todo ataque físico, custa 30 pila");
            }
            if (player == 1 && manto_1 == 0 || (player == 2 && manto_2 == 0)) //Mostrar a opção de manto arcano caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n5. Manto Arcano: Uma roupa marcada com diversos símbolos místicos, eficiente contra efeitos mágicos. \nArmadura, reduz todo dano mágico em 5, custa 40 pila");
            }
            if (player == 1 && espada_1 == 0 || (player == 2 && espada_2 == 0)) //Mostrar a opção de espada balanceada caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n6. Espada Balanceada: Uma espada feita por um ferreiro extremamente habilidoso, feita para golpes certeiros. \nEquipamento, aumenta seu dano físico em 10, custa 30 pila");
            }
            if (player == 1 && runas_1 == false || (player == 2 && runas_2 == false)) //Mostrar a opção de runas arcana caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n7. Runas Arcanas: Uma bolsa com runas capazes de amplificar suas magias, mas de uma forma misteriosa. \nEquipamento, amplifica o efeito de suas magias, custa 40 pila");
            }


            //opção de sair da loja
            Console.WriteLine("\n8. Sair da loja");
        }


        static void EscolherAtributos()
        {
            //Escolhendo atributos caso o modo SinglePlayer seja escolhido
            if (Singleplayer == true)
            {
                //Estético
                Console.WriteLine("Jogador 1, escolha seu modificador de Força. Você dará mais dano em ataques corpo a corpo, mas terá menos mana");
                Console.Write("\nForça (0 - 10): ");
                forca_1 = int.Parse(Console.ReadLine());


                //Trava para Força não ser menor ou maior que o estipulado
                while (forca_1 < 0 || forca_1 > 10)
                {
                    Console.WriteLine("\nERRO! O valor do seu modificador de Força deve estar entre 0 e 10, digite um valor nesse intervalo");
                    forca_1 = int.Parse(Console.ReadLine());
                }


                //Mostrar Força e Mana
                Console.WriteLine("\nSua Força é: " + forca_1);
                Console.WriteLine("Sua Mana é: " + (Mana_Player_1 += 20 - forca_1));

            }

            //Escolhendo atributos caso o modo MultiPlayer seja escolhido
            if (Singleplayer == false)
            {
                //Trava para começar a seleção do player 2
                Console.WriteLine("\nDigite ENTER para continuar");
                Console.ReadLine();
                Console.Clear();

                //definindo Força do jogador 2
                Console.WriteLine("Jogador 2, escolha seu modificador de Força. Você dará mais dano em ataques corpo a corpo, mas terá menos mana");
                Console.Write("Força (1 - 10): ");
                forca_2 = int.Parse(Console.ReadLine());

                //trava para Força não ser menor ou maior que o estipulado
                while (forca_2 < 0 || forca_2 > 10)
                {
                    Console.WriteLine("\nERRO! O valor do seu modificador de Força deve estar entre 0 e 10, digite um valor nesse intervalo");
                    forca_1 = int.Parse(Console.ReadLine());
                }

                //mostrar Força e Mana
                Console.WriteLine("Sua força é: " + forca_2);
                Mana_Player_2 += 20 - forca_2;
                Console.WriteLine("Sua mana é: " + Mana_Player_2);

                Console.WriteLine("\nAperte ENTER para começar a luta");
                Console.ReadLine();
                Console.Clear();
            }
        }


        static void EscolherMagias()
        {
            string[] op_magias = new string[9];
            op_magias[0] = "Bola de Fogo";
            op_magias[1] = "Relâmpago";
            op_magias[2] = "Curar Ferimentos";
            op_magias[3] = "Despedaçar";
            op_magias[4] = "Confusão";
            op_magias[5] = "Purificar";
            op_magias[6] = "Raio do Enfraquecimento";
            op_magias[7] = "Rogar Maldição";
            op_magias[8] = "Campo de Força";


            Console.WriteLine("As magias são poderes invocados a partir da energia arcana, você pode escolher 3 para levar a batalha\n");

            Console.WriteLine(@"1. Bola de Fogo: 
2. Relâmpago
3. Curar Ferimentos
4. Despedaçar
5. Confusão
6. Purificar
7. Raio do Enfraquecimento
8. Rogar Maldição
9. Campo de Força
");

            Console.WriteLine("Jogador 1, escolha suas magias");
            for (int x = 0; x < 3; x++)
            {
                int y = int.Parse(Console.ReadLine());
                magias_p1[x] = op_magias[y - 1];
                op_magias[y - 1] = "0";

                while (magias_p1[x] == "0")
                {
                    Console.WriteLine("\nErro! A magia selecionada é igual a alguma já escolhida, escolha outra!");
                    y = int.Parse(Console.ReadLine());
                    magias_p1[x] = op_magias[y - 1];
                    op_magias[y - 1] = "0";
                }

                Console.WriteLine($"A magia escolhida foi: {magias_p1[x]}");
            }
            Console.WriteLine("\nDigite ENTER para continuar");
            Console.ReadLine();
            Console.Clear();

            if (Singleplayer == false)
            {
                op_magias[0] = "Bola de Fogo";
                op_magias[1] = "Relâmpago";
                op_magias[2] = "Curar Ferimentos";
                op_magias[3] = "Despedaçar";
                op_magias[4] = "Confusão";
                op_magias[5] = "Purificar";
                op_magias[6] = "Raio do Enfraquecimento";
                op_magias[7] = "Rogar Maldição";
                op_magias[8] = "Campo de Força";

                Console.WriteLine("As magias são poderes invocados a partir da energia arcana, você pode escolher 3 para levar a batalha\n");

                Console.WriteLine(@"1. Bola de Fogo: 
2. Relâmpago
3. Curar Ferimentos
4. Despedaçar
5. Confusão
6. Purificar
7. Raio do Enfraquecimento
8. Rogar Maldição
9. Campo de Força
");

                Console.WriteLine("Jogador 2, escolha suas magias");
                for (int x = 0; x < 3; x++)
                {
                    int y = int.Parse(Console.ReadLine());
                    magias_p2[x] = op_magias[y - 1];
                    op_magias[y - 1] = "0";

                    while (magias_p2[x] == "0")
                    {
                        Console.WriteLine("\nErro! A magia selecionada é igual a alguma já escolhida, escolha outra!");
                        y = int.Parse(Console.ReadLine());
                        magias_p2[x] = op_magias[y - 1];
                        op_magias[y - 1] = "0";
                    }

                    Console.WriteLine($"A magia escolhida foi: {magias_p2[x]}");
                }
                Console.WriteLine("\nDigite ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }


        static void BatalhaMultiplayer()
        {
            Random r = new Random();
            int confusão;
            player = 1;

            while (Vida_Player_1 > 0 && Vida_Player_2 > 0)
            {
                if (player == 1)
                {
                    HUD();
                    if (Paralizado_1 == false)
                    {
                        confusão = r.Next(1, 6);

                        if (Confusão_p1 == true && confusão >= 4)
                        {
                            Console.WriteLine("Você está confuso e acaba acertando a sí próprio, perdendo 5 de vida");
                            Vida_Player_1 -= 5;
                        }
                        else
                        {
                            AçõesJogadores();
                        }
                    }
                    else
                    {
                        Paralizado_1 = false;
                    }
                    if (queimadura_1 > 0)
                    {
                        Console.WriteLine("As chamas consomem seu corpo lentamente, fazendo você receber 2 de dano");
                        Vida_Player_1 -= 2;
                        queimadura_1--;
                    }
                    enfraquecimento_p1 = 0;
                    EndGame();
                    player = 2;
                }
                HUD();
                if (Paralizado_2 == false && player == 2)
                {
                    AçõesJogadores();
                }
                else
                {
                    Paralizado_2 = false;
                }
                if (queimadura_2 > 0)
                {
                    Console.WriteLine("As chamas consomem seu corpo lentamente, fazendo você receber 2 de dano");
                    Vida_Player_2 -= 2;
                    queimadura_2--;
                }
                enfraquecimento_p2 = 0;
                EndGame();
                player = 1;
                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }


        static void BatalhaSingleplayer()
        {
            while (Vida_Player_1 > 0 && Vida_Player_2 > 0)
            {
                HUD();
                if (Paralizado_1 == false)
                {
                    AçõesJogadores();
                }
                else
                {
                    Paralizado_1 = false;
                }
                EndGame();
                if (Paralizado_2 == false)
                {
                    Boss();
                }
                else
                {
                    Console.WriteLine("Você vê seu adversário estático");
                    Paralizado_2 = false;
                }
                if (queimadura_2 > 0)
                {
                    Console.WriteLine("Você vê seu adversário ardendo em chamas, ele perde 5 de vida");
                    Vida_Boss -= 5;
                }
                EndGame();
            }
        }


        static void HUD()
        {
            if (Singleplayer == false)
            {
                if (player == 1)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    Console.Write("Vida do Player 1: " + Vida_Player_1 + "         Mana do Player 1: " + Mana_Player_1 + "\n");

                    Console.Write("Vida do Player 2: " + Vida_Player_2 + "        Mana do Player 2: " + Mana_Player_2 + "\n");

                    if (Paralizado_1 == true)
                    {
                        Console.WriteLine("\nVocê não consegue se mover!");
                    }
                    else
                    {
                        Console.WriteLine("\nJogador 1, escolha seu movimento!");
                    }
                }
                else if (player == 2)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    Console.Write("Vida do Player 1: " + Vida_Player_1 + "         Mana do Player 1: " + Mana_Player_1 + "\n");

                    Console.Write("Vida do Player 2: " + Vida_Player_2 + "        Mana do Player 2: " + Mana_Player_2 + "\n");

                    if (Paralizado_2 == true)
                    {
                        Console.WriteLine("\nVocê não consegue se mover!");
                    }
                    else
                    {
                        Console.WriteLine("\nJogador 2, escolha seu movimento!");
                    }
                }
            }
            else if (Singleplayer == true)
            {
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.Write("Vida do Herói: " + Vida_Player_1 + "         Mana do Herói: " + Mana_Player_1 + "\n");

                Console.Write("Vida do Adversário: " + Vida_Boss + "        Mana do Adversário: " + Mana_Boss + "\n");

                Console.WriteLine("\nEscolha seu movimento!");
            }
        }


        static void AçõesJogadores()
        {
            //opções
            Console.WriteLine("\n1. Atacar");
            Console.WriteLine("2. Magia");
            Console.WriteLine("3. Itens");
            Console.WriteLine("");

            //entrando a opção
            op = Console.ReadLine();
            Console.WriteLine("");

            if (op == "1")
            {
                Ataque();
            }

            //Opcões de Magias
            else if (op == "2")
            {
                Magia();
            }

            //Opções de Itens
            else if (op == "3")
            {
                Item();
            }
        }


        static void Ataque()
        {
            Random rPlayer = new Random();
            int Ataque = rPlayer.Next(6);

            if (Singleplayer == false && player == 1)
            {
                if (Ataque <= 2)
                {
                    if (espada_1 > 0)
                    {
                        Vida_Player_2 -= 25 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2;
                        Console.WriteLine($"Você acerta! O inimigo perde {25 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2} de vida");
                    }
                    else
                    {
                        Vida_Player_2 -= 15 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2;
                        Console.WriteLine($"Você acerta! O inimigo perde {15 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2} de vida");
                    }
                }
                else if (Ataque >= 3)
                {
                    Console.WriteLine("Você errou!");

                }
                else if (Ataque == 5)
                {
                    if (espada_1 > 0)
                    {
                        Vida_Player_2 -= 40 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {40 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2} de vida");
                    }
                    else
                    {
                        Vida_Player_2 -= 30 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {30 + forca_1 - armadura_2 - enfraquecimento_p1 - campo_forca2} de vida");
                    }

                }
            }

            else if (Singleplayer == false && player == 2)
            {
                if (Ataque <= 2)
                {
                    if (espada_2 > 0)
                    {
                        Vida_Player_1 -= 25 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1;
                        Console.WriteLine($"Você acerta! O inimigo perde {25 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1} de vida");
                    }
                    else
                    {
                        Vida_Player_1 -= 15 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1;
                        Console.WriteLine($"Você acerta! O inimigo perde {15 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1} de vida");
                    }

                }
                else if (Ataque >= 3)
                {
                    Console.WriteLine("Você errou!");
                }
                else if (Ataque == 5)
                {
                    if (espada_2 > 0)
                    {
                        Vida_Player_1 -= 40 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {40 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1} de vida");
                    }
                    else
                    {
                        Vida_Player_1 -= 30 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {30 + forca_2 - armadura_1 - enfraquecimento_p2 - campo_forca1} de vida");
                    }
                }
            }

            else if (Singleplayer == true)
            {
                if (Ataque <= 2)
                {
                    if (espada_1 > 0)
                    {
                        Vida_Boss -= 25 + forca_1;
                        Console.WriteLine($"Você acerta! O inimigo perde {25 + forca_1} de vida");
                    }
                    else
                    {
                        Vida_Boss -= 15 + forca_1;
                        Console.WriteLine($"Você acerta! O inimigo perde {15 + forca_1} de vida");
                    }
                }
                else if (Ataque >= 3)
                {
                    Console.WriteLine("Você errou!");
                }
                else if (Ataque == 5)
                {
                    if (espada_1 > 0)
                    {
                        Vida_Boss -= 40 + forca_1;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {40 + forca_1} de vida");
                    }
                    else
                    {
                        Vida_Boss -= 30 + forca_1;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {30 + forca_1} de vida");
                    }
                }
            }
        }


        static void Magia()
        {
            //opções
            Random rPlayer2 = new Random();
            int Magias = rPlayer2.Next(6);

            if (player == 1)
            {
                Console.WriteLine("1. " + magias_p1[0]);
                Console.WriteLine("2. " + magias_p1[1]);
                Console.WriteLine("3. " + magias_p1[2]);
            }
            else if (player == 2)
            {
                Console.WriteLine("1. " + magias_p2[0]);
                Console.WriteLine("2. " + magias_p2[1]);
                Console.WriteLine("3. " + magias_p2[2]);
            }
            Console.WriteLine("4. Voltar");
            Console.WriteLine("");

            op = Console.ReadLine();
            Console.WriteLine("");

            if (player == 1)
            {
                if (Mana_Player_1 >= 5)
                {
                    if (op == "4")
                    {
                        BatalhaMultiplayer();
                    }
                    //opções de magia caso esteja no MultiPla
                    if (Singleplayer == false)
                    {
                        if (magias_p1[Convert.ToInt32(op) - 1].Contains("Bola de Fogo"))
                        {
                            if (Mana_Player_1 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                                AçõesJogadores();
                            }
                            else if (Magias == 0 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 10 - manto_2;
                                Mana_Player_1 -= 10;
                                Console.WriteLine($"Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde {10 - manto_2} de vida");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 20 - manto_2;
                                Mana_Player_1 -= 10;
                                Console.WriteLine($"Você acerta sua Bola de Fogo. O inimigo perde {20 - manto_2} de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 30 - manto_2;
                                Mana_Player_1 -= 10;
                                Console.WriteLine($"Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde {30 - manto_2} de vida");
                                if (runas_1 == true && manto_2 == 0)
                                {
                                    Console.WriteLine("Uma runa vermelha arde no seu bolso, você vê que seu inimigo ficou Queimado!");
                                    queimadura_2 = 5;
                                }
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Relâmpago"))
                        {
                            if (Mana_Player_1 < 5)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Magias == 0 && Mana_Player_1 >= 5)
                            {
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você lança um raio e erra");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 5)
                            {
                                Vida_Player_2 -= 10 - manto_2;
                                Mana_Player_1 -= 5;
                                Console.WriteLine($"Você acerta seu raio no inimigo. O inimigo perde {10 - manto_2} de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 5)
                            {
                                Vida_Player_2 -= 20 - manto_2;
                                Mana_Player_1 -= 5;
                                Console.WriteLine($"Você acerta um raio em cheio no peito do inimigo. O inimigo perde {20 - manto_2} de vida");
                                if (runas_1 == true && manto_2 == 0)
                                {
                                    Console.WriteLine("Você vê uma runa azul brilhando no seu bolso, e seu inimigo fica paralizado!");
                                    Paralizado_2 = true;
                                }
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Curar Ferimentos"))
                        {
                            if (Mana_Player_1 < 5)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 5)
                            {
                                Vida_Player_1 += 20;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                                if (runas_1 == true)
                                {
                                    Console.WriteLine("Uma runa amarela começa a brilhar no seu bolso, você sente uma sensação de alívio. Você recuperou mais 10 de vida!");
                                    Vida_Player_1 += 10;
                                }
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Despedaçar"))
                        {
                            if (Mana_Player_1 < 5)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 5)
                            {
                                Random r = new Random();
                                int destruir = r.Next(1, 12);
                                Mana_Player_1 -= 5;
                                Console.WriteLine(destruir);
                                Console.WriteLine("Esta magia emite um som alto e agudo, com a tentativa de destruir uma armadura do seu oponente.");
                                Console.ReadLine();

                                if (destruir == 4 && manto_2 > 0)
                                {
                                    manto_2 = 0;
                                    Console.WriteLine("Você destruiu o manto do inimigo");
                                }
                                else if (destruir == 8 && armadura_2 > 0)
                                {
                                    armadura_2 = 0;
                                    Console.WriteLine("Você destruiu a armadura do inimigo");
                                }
                                else if (destruir == 12 && espada_2 > 0)
                                {
                                    espada_2 = 0;
                                    Console.WriteLine("Voce destruiu a espada do inimigo");
                                }
                                else if (destruir == 4 && manto_2 == 0 || destruir == 8 && armadura_2 == 0 || destruir == 12 && espada_2 == 0)
                                {
                                    Console.WriteLine("causou 20 de dano ao seu inimigo");
                                    Vida_Player_2 -= 20;
                                }
                            }

                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Confusão"))
                        {
                            if (Mana_Player_1 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 10)
                            {
                                Mana_Player_1 -= 10;
                                Random r = new Random();
                                int confusão = r.Next(1, 6);
                                Console.WriteLine(confusão);

                                if (confusão == 5)
                                {
                                    Console.WriteLine("Você conjura a magia confusão, e deixa o seu inimigo se comportando de modo aleatorio");
                                    Confusão_p2 = true;
                                }
                                else if (confusão < 5)
                                {
                                    Console.WriteLine("Você conjura a magia confusão, e falha, e deixa seu comportamento em modo aleatorio");
                                    Confusão_p1 = true;
                                }
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Purificar"))
                        {
                            if (Mana_Player_1 < 5)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 5)
                            {
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Com a ajuda dos espiritos você pede a benção deles, capaz de tirar os seus efeitos negativos");
                                enfraquecimento_p1 = 0;
                                Confusão_p1 = false;

                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Raio do Enfraquecimento"))
                        {
                            if (Mana_Player_1 < 5)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 5)
                            {
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você concentra sua magia, e solta um raio que enfraqueçe o dano do seu adversario.");
                                enfraquecimento_p2 = 10;
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Rogar Maldição"))
                        {

                            if (Mana_Player_1 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 10)
                            {
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você toca em seu adversario, e roga uma maldição\n 1- Maldição do rompimento: Você faz com que o seu adversario tenha uma chance enquanto te ataca de quebrar uma armadura");
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Campo de Força"))
                        {
                            if (Mana_Player_1 < 15)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 15)
                            {
                                Mana_Player_1 -= 15;
                                Console.WriteLine("Você concentra sua energia magica em sua volta, e cria um campo de força, reduzindo todos os danos ao seu redor em 20");
                                campo_forca1 = 20;
                            }
                        }
                    }
                    else if (Singleplayer == true)
                    {
                        if (magias_p1[Convert.ToInt32(op) - 1].Contains("Bola de Fogo"))
                        {
                            if (Mana_Player_1 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Magias == 0 && Mana_Player_1 >= 10)
                            {
                                Vida_Boss -= 10;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 10)
                            {
                                Vida_Boss -= 20;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 20 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 10)
                            {
                                Vida_Boss -= 30;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 30 de vida");
                                if (runas_1 == true)
                                {
                                    Console.WriteLine("Uma runa vermelha arde no seu bolso, você vê que seu inimigo ficou Queimado!");
                                    queimadura_2 = 5;
                                }
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Relâmpago"))
                        {
                            if (Mana_Player_1 < 5)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Magias == 0 && Mana_Player_1 >= 5)
                            {
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você lança um raio e erra");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 5)
                            {
                                Vida_Boss -= 10;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 10 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 5)
                            {
                                Vida_Boss -= 20;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 20 de vida");
                                if (runas_1 == true)
                                {
                                    Console.WriteLine("Você vê uma runa azul brilhando no seu bolso, e seu inimigo fica paralizado!");
                                    Paralizado_2 = true;
                                }
                            }
                        }
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Curar Ferimentos"))
                        {
                            if (Mana_Player_1 < 5)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Mana_Player_1 >= 5)
                            {
                                Vida_Player_1 += 20;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                            }

                        }

                    }
                }

                else if (Mana_Player_1 < 5)
                {
                    Console.WriteLine("Você não tem mana suficiênte, escolha outra opção.");
                    AçõesJogadores();
                }
            }
            if (player == 2)
            {
                if (op == "4")
                {
                    BatalhaMultiplayer();
                }
                if (magias_p2[Convert.ToInt32(op) - 1].Contains("Bola de Fogo"))
                {
                    if (Mana_Player_2 < 10)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Magias == 0 && Mana_Player_2 >= 10)
                    {
                        Vida_Player_1 -= 10 - manto_1;
                        Mana_Player_2 -= 10;
                        Console.WriteLine($"Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde {10 - manto_1} de vida");
                    }
                    else if (Magias >= 1 && Magias <= 4 && Mana_Player_2 >= 10)
                    {
                        Vida_Player_1 -= 20 - manto_1;
                        Mana_Player_2 -= 10;
                        Console.WriteLine($"Você acerta sua Bola de Fogo. O inimigo perde {20 - manto_1} de vida");
                    }
                    else if (Magias == 5 && Mana_Player_2 >= 10)
                    {
                        Vida_Player_1 -= 30 - manto_1;
                        Mana_Player_2 -= 10;
                        Console.WriteLine($"Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde {30 - manto_1} de vida");
                        if (runas_2 == true && manto_1 == 0)
                        {
                            Console.WriteLine("Uma runa vermelha arde no seu bolso, você vê que seu inimigo ficou Queimado!");
                            queimadura_1 = 5;
                        }
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Relâmpago"))
                {
                    if (Mana_Player_2 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Magias == 0 && Mana_Player_2 >= 5)
                    {
                        Mana_Player_2 -= 5;
                        Console.WriteLine("Você lança um raio e erra");
                    }
                    else if (Magias >= 1 && Magias <= 4 && Mana_Player_2 >= 5)
                    {
                        Vida_Player_1 -= 10 - manto_1;
                        Mana_Player_2 -= 5;
                        Console.WriteLine($"Você acerta seu raio no inimigo. O inimigo perde {10 - manto_1} de vida");
                    }
                    else if (Magias == 5 && Mana_Player_2 >= 5)
                    {
                        Vida_Player_1 -= 20 - manto_1;
                        Mana_Player_2 -= 5;
                        Console.WriteLine($"Você acerta um raio em cheio no peito do inimigo. O inimigo perde {20 - manto_1} de vida");
                        if (runas_1 == true && manto_1 == 0)
                        {
                            Console.WriteLine("Você vê uma runa azul brilhando no seu bolso, e seu inimigo fica paralizado!");
                            Paralizado_2 = true;
                        }
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Curar Ferimentos"))
                {
                    if (Mana_Player_2 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Mana_Player_2 >= 5)
                    {
                        Vida_Player_2 += 20;
                        Mana_Player_2 -= 5;
                        Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                        if (runas_2 == true)
                        {
                            Console.WriteLine("Uma runa amarela começa a brilhar no seu bolso, você sente uma sensação de alívio. Você recuperou mais 10 de vida!");
                            Vida_Player_1 += 10;
                            if (runas_1 == true)
                            {
                                Console.WriteLine("Uma runa amarela começa a brilhar no seu bolso, você sente uma sensação de alívio. Você recuperou mais 10 de vida!");
                                Vida_Player_1 += 10;
                            }
                        }
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Despedaçar"))
                {
                    if (Mana_Player_2 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Mana_Player_2 >= 5)
                    {
                        Random r = new Random();
                        int destruir = r.Next(1, 12);
                        Mana_Player_2 -= 5;
                        Console.WriteLine(destruir);
                        Console.WriteLine("Esta magia emite um som alto e agudo, com a tentativa de destruir uma armadura do seu oponente.");

                        if (destruir == 4 && manto_1 > 0)
                        {
                            manto_1 = 0;
                            Console.WriteLine("Você destruiu o manto do inimigo");
                        }
                        else if (destruir == 8 && armadura_1 > 0)
                        {
                            armadura_1 = 0;
                            Console.WriteLine("Você destruiu a armadura do inimigo");
                        }
                        else if (destruir == 12 && espada_1 > 0)
                        {
                            espada_1 = 0;
                            Console.WriteLine("Voce destruiu a espada do inimigo");
                        }
                        else if (manto_1 == 0 || armadura_1 == 0 || espada_1 == 0)
                        {
                            if (destruir == 4 && manto_1 == 0)
                            {
                                Console.WriteLine("causou 20 de dano ao seu inimigo");
                                Vida_Player_1 -= 20;
                            }
                            if (destruir == 8 && armadura_1 == 0)
                            {
                                Console.WriteLine("causou 20 de dano ao seu inimigo");
                                Vida_Player_1 -= 20;
                            }
                            if (destruir == 12 && espada_1 == 0)
                            {
                                Console.WriteLine("causou 20 de dano ao seu inimigo");
                                Vida_Player_1 -= 20;
                            }
                        }
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Confusão"))
                {
                    if (Mana_Player_2 < 10)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Mana_Player_2 >= 10)
                    {
                        Mana_Player_2 -= 10;
                        Random r = new Random();
                        int confusão = r.Next(1, 6);
                        Console.WriteLine(confusão);

                        if (confusão == 5)
                        {
                            Console.WriteLine("Você conjura a magia confusão, e deixa o seu inimigo se comportando de modo aleatorio");
                            Confusão_p1 = true;
                        }
                        else if (confusão < 5)
                        {
                            Console.WriteLine("Você conjura a magia confusão, e falha, e deixa seu comportamento em modo aleatorio");
                            Confusão_p2 = true;
                        }
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Purificar"))
                {
                    if (Mana_Player_2 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Mana_Player_2 >= 5)
                    {
                        Mana_Player_2 -= 5;
                        Console.WriteLine("Com a ajuda dos espiritos você pede a benção deles, capaz de tirar os seus efeitos negativos");
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Raio do Enfraquecimento"))
                {
                    if (Mana_Player_2 < 10)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Mana_Player_2 >= 10)
                    {
                        Mana_Player_2 -= 10;
                        Console.WriteLine("Você concentra sua magia, e solta um raio que enfraqueçe o dano do seu adversario.");
                        enfraquecimento_p1 = 10;
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Rogar Maldição"))
                {

                    if (Mana_Player_2 < 10)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Mana_Player_2 >= 10)
                    {
                        Mana_Player_2 -= 10;
                        Console.WriteLine("Você toca em seu adversario, e roga uma maldição\n 1- Maldição do rompimento: Quando voce atacar seu adversario tenha uma chance de quebrar uma armadura dele\n 2- Cegueira: Aumente a chance do adversario errar um ataque\n 3- ");
                        op = Console.ReadLine();
                        if (op == "1") 
                        {
                        }
                    }
                }
                else if (magias_p2[Convert.ToInt32(op) - 1].Contains("Campo de Força"))
                {
                    if (Mana_Player_2 < 15)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                    }
                    else if (Mana_Player_2 >= 15)
                    {
                        Mana_Player_2 -= 15;
                        Console.WriteLine("Você concentra sua energia magica em sua volta, e cria um campo de força, reduzindo todos os danos ao seu redor em 20");
                        campo_forca2 = 20;
                    }
                }
            }
        }


        static void Item()
        {
            Random rPlayer = new Random();
            int Itens2 = rPlayer.Next(20);

            //opções
            Console.WriteLine("1. Poção de Cura");
            Console.WriteLine("Recupera 10 de vida");
            Console.WriteLine("Quantidade: " + Poção_de_Cura_1);
            Console.WriteLine("");
            Console.WriteLine("2. Poção de Mana");
            Console.WriteLine("Recupera 5 de mana");
            Console.WriteLine("Quantidade: " + Poção_de_Mana_1);
            Console.WriteLine("");
            Console.WriteLine("3. Poção Estranha");
            Console.WriteLine("????????");
            Console.WriteLine("Quantidade: " + Poção_Estranha_1);
            Console.WriteLine("");
            Console.WriteLine("4. Voltar");
            Console.WriteLine("");

            op = Console.ReadLine();
            Console.WriteLine("");

            if (player == 1)
            {
                if (Poções_1 > 0)
                {

                    if (op == "4")
                    {
                        BatalhaMultiplayer();
                    }
                    if (player == 1)
                    {

                        if (op == "1" && Poção_de_Cura_1 > 0)
                        {
                            Vida_Player_1 += 10;
                            Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                            Poção_de_Cura_1 -= 1;
                        }
                        else if (op == "1" && Poção_de_Cura_1 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de cura");
                        }

                        else if (op == "2" && Poção_de_Mana_1 > 0)
                        {
                            Mana_Player_1 += 5;
                            Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                            Poção_de_Mana_1 -= 1;
                        }
                        else if (op == "2" && Poção_de_Mana_1 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de mana");
                        }

                        else if (op == "3")
                        {
                            if (Itens2 == 0 && Poção_Estranha_1 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e começa a se sentir tonto até cai desacordado");
                                Console.WriteLine("");
                                Vida_Player_1 = 0;
                            }
                            else if (Itens2 >= 1 && Itens2 <= 5 && Poção_Estranha_1 > 0)
                            {
                                Vida_Player_1 = 100;
                                Mana_Player_1 = 20;
                                Console.WriteLine("Você bebe a poção e começa a se sentir completamente restaurado");
                                Poção_Estranha_1 -= 1;
                            }
                            else if (Itens2 >= 6 && Poção_Estranha_1 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e não sente nenhuma mudança");
                            }
                            else if (op == "3" && Poção_Estranha_1 == 0)
                            {
                                Console.WriteLine("Você não tem mais nenhuma poção estranha");
                            }
                        }
                    }
                }
            }
            if (player == 2)
            {
                if (Poções_2 > 0)
                {

                    if (op == "4")
                    {
                        BatalhaMultiplayer();
                    }
                    if (player == 1)
                    {

                        if (op == "1" && Poção_de_Cura_1 > 0)
                        {
                            Vida_Player_1 += 10;
                            Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                            Poção_de_Cura_1 -= 1;
                        }
                        else if (op == "1" && Poção_de_Cura_1 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de cura");
                        }

                        else if (op == "2" && Poção_de_Mana_1 > 0)
                        {
                            Mana_Player_1 += 5;
                            Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                            Poção_de_Mana_1 -= 1;
                        }
                        else if (op == "2" && Poção_de_Mana_1 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de mana");
                        }

                        else if (op == "3")
                        {
                            if (Itens2 == 0 && Poção_Estranha_1 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e começa a se sentir tonto até cai desacordado");
                                Console.WriteLine("");
                                Vida_Player_1 = 0;
                                EndGame();
                            }
                            else if (Itens2 >= 1 && Itens2 <= 5 && Poção_Estranha_1 > 0)
                            {
                                Vida_Player_1 = 100;
                                Mana_Player_1 = 20;
                                Console.WriteLine("Você bebe a poção e começa a se sentir completamente restaurado");
                                Poção_Estranha_1 -= 1;
                                EndGame();
                            }
                            else if (Itens2 >= 6 && Poção_Estranha_1 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e não sente nenhuma mudança");
                                Poção_Estranha_1 -= 1;
                            }
                            else if (op == "3" && Poção_Estranha_1 == 0)
                            {
                                Console.WriteLine("Você não tem mais nenhuma poção estranha");
                            }
                        }
                    }
                }
                else if (Poções_2 == 0)
                {
                    Console.WriteLine("Você não tem nenhum item");
                    AçõesJogadores();
                }
            }
        }


        static void Boss()
        {
            Random rPlayer = new Random();
            int Boss = rPlayer.Next(20);

            while (Mana_Boss < 10 && Boss <= 10)
            {
                Boss = rPlayer.Next(20);
            }

            if (Boss == 0 && Mana_Boss >= 10)
            {
                Paralizado_1 = true;
                Mana_Boss -= 10;
                Console.WriteLine("Seu inimigo começa a sussurrar palavras estranhas. Você se sente congelado");
            }
            else if (Boss >= 1 && Boss <= 5 && Mana_Boss >= 10)
            {
                Mana_Boss -= 10;
                Console.WriteLine("Seu inimigo canaliza uma torrente de energia negativa na sua direção, mas erra");
            }
            else if (Boss >= 6 && Boss <= 10 && Mana_Boss >= 10)
            {
                Vida_Player_1 -= 20;
                Mana_Boss -= 10;
                Console.WriteLine("Seu inimigo canaliza uma torrente de energia negativa na sua direção. Você perde 20 de vida");
            }
            else if (Boss >= 11 && Boss <= 14)
            {
                Console.WriteLine("Seu inimigo tenta te acertar com um ataque, mas erra.");
            }
            else if (Boss >= 15 && Boss <= 18)
            {
                Vida_Player_1 -= 15;
                Console.WriteLine("Seu inimigo te acerta com um ataque. Você perde 15 de vida.");
            }
            else
            {
                Vida_Player_1 -= 30;
                Console.WriteLine("Seu inimigo te acerta em cheio. Você perde 30 de vida.");
            }
            Console.WriteLine("\nPressione Enter para continuar");
            Console.ReadLine();
            Console.Clear();
        }


        static void EndGame()
        {
            if (Vida_Player_1 > 0 && (Vida_Player_2 <= 0 || Vida_Boss <= 0))
            {
                Console.WriteLine(@"
░▀▀█░█▀█░█▀▀░█▀█░█▀▄░█▀█░█▀▄░░░▀█░░░░█▀▀░█▀█░█▀█░█░█░█▀█
░░░█░█░█░█░█░█▀█░█░█░█░█░█▀▄░░░░█░░░░█░█░█▀█░█░█░█▀█░█▀█
░▀▀░░▀▀▀░▀▀▀░▀░▀░▀▀░░▀▀▀░▀░▀░░░▀▀▀░░░▀▀▀░▀░▀░▀░▀░▀░▀░▀░▀
");
                Console.WriteLine("Digite ENTER para encerrar o programa");
                Console.ReadLine();
                Environment.Exit(0);
            }

            else if (Vida_Player_1 <= 0 && (Vida_Player_2 > 0 || Vida_Boss > 0))
            {
                if (Singleplayer == false)
                {
                    Console.WriteLine(@"
░▀▀█░█▀█░█▀▀░█▀█░█▀▄░█▀█░█▀▄░░░▀▀▄░░░█▀▀░█▀█░█▀█░█░█░█▀█
░░░█░█░█░█░█░█▀█░█░█░█░█░█▀▄░░░▄▀░░░░█░█░█▀█░█░█░█▀█░█▀█
░▀▀░░▀▀▀░▀▀▀░▀░▀░▀▀░░▀▀▀░▀░▀░░░▀▀▀░░░▀▀▀░▀░▀░▀░▀░▀░▀░▀░▀");
                    Console.WriteLine("Digite ENTER para encerrar o programa");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine(@"
░█▀█░░░█▀█░█▀▄░█░█░█▀▀░█▀▄░█▀▀░█▀█░█▀▄░▀█▀░█▀█░░░█▀▀░█▀█░█▀█░█░█░█▀█
░█░█░░░█▀█░█░█░▀▄▀░█▀▀░█▀▄░▀▀█░█▀█░█▀▄░░█░░█░█░░░█░█░█▀█░█░█░█▀█░█▀█
░▀▀▀░░░▀░▀░▀▀░░░▀░░▀▀▀░▀░▀░▀▀▀░▀░▀░▀░▀░▀▀▀░▀▀▀░░░▀▀▀░▀░▀░▀░▀░▀░▀░▀░▀");
                }
            }
        }
    }
}

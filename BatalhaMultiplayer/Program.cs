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
        static int forca_1, Vida_Player_1 = 100, Mana_Player_1 = 10, Poção_de_Cura_1 = 0, Poção_de_Mana_1 = 0, Poção_Estranha_1 = 0, Poções_1 = Poção_Estranha_1 + Poção_de_Mana_1 + Poção_de_Cura_1, queimadura_1 = 0, armadura_1 = 0, manto_1 = 0, espada_1 = 0, enfraquecimento_p1 = 0, campo_forca1 = 0, fraco1 = 0;
        static bool Paralizado_1 = false, runas_1, Confusão_p1 = false, fragil1 = false, cego1 = false, mudo1 = false;
        static string[] magias_p1 = { "0", "0", "0" };


        // Atributos do Jogador 2
        static int forca_2, Vida_Player_2 = 100, Mana_Player_2 = 10, Poção_de_Cura_2 = 0, Poção_de_Mana_2 = 0, Poção_Estranha_2 = 0, Poções_2 = Poção_Estranha_2 + Poção_de_Mana_2 + Poção_de_Cura_2, queimadura_2 = 0, armadura_2 = 0, manto_2 = 0, espada_2 = 0, enfraquecimento_p2 = 0, campo_forca2 = 0, fraco2 = 0;
        static bool Paralizado_2 = false, runas_2, Confusão_p2 = false, fragil2 = false, cego2 = false, mudo2 = false;
        static string[] magias_p2 = { "0", "0", "0" };


        // Atributos para o Modo Singleplayer
        static bool Singleplayer = false;
        static int Vida_Boss = 100, Mana_Boss = 20, dano;


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
            if (op == "1") //Caso o jogador decida jogar SinglePlayer, bool (SinglePlayer) = true
            {
                Singleplayer = true;
                Console.WriteLine("\nVocê escolheu o modo SinglePlayer");
            }
            else if (op == "2") //Caso o jogador decida jogar MultiPlayer, bool (SinglePlayer) == false
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

                        //Trava
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

                            //Trava
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

                        //Trava
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
                            manto_1 = 5;
                            saldo_1 -= 40;
                            Console.WriteLine("Você gastou 40 pila e comprou robes capazes de te proteger de efeitos mágicos");

                            //Trava
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

                        //Trava
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

                            //Trava
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

                        //Trava
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

                            //Trava
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                }
                Console.Clear();
            }

            op = "";
            //Trava
            Console.WriteLine("Obrigado pela preferência! Volte sempre");
            Console.WriteLine("\n\nDigite ENTER para continuar");
            Console.ReadLine();
            Console.Clear();

            //Caso o modo escolhido seja o MultiPlayer, o player 2 poderá comprar seus itens
            if (Singleplayer == false)
            {
                player = 2;
                Console.WriteLine("Bem vindo a loja player 2! Aqui você poderá comprar itens que te ajudarão durante sua batalha");


                while (saldo_2 > 0 && op != "8")
                {
                    int quantidade = 0;

                    OpsLoja();

                    Console.WriteLine($"\nSeu saldo: {saldo_2}");
                    Console.WriteLine("\n\nO que você gostaria de comprar?");

                    Console.Write("Digite sua escolha: ");
                    op = Console.ReadLine();
                    Console.WriteLine("");

                    if (op == "1") //Caso o jogador queira comprar poções de vida
                    {
                        Console.WriteLine("Quantas unidades você gostaria de comprar?");
                        quantidade = int.Parse(Console.ReadLine());

                        while ((saldo_2 - quantidade * 10) < 0)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                            quantidade = int.Parse(Console.ReadLine());
                        }

                        saldo_2 -= 10 * quantidade;
                        Poção_de_Cura_2 += quantidade;

                        Console.WriteLine($"Você comprou {quantidade} poções de cura e gastou {10 * quantidade} pila");

                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    if (op == "2") //Caso o jogador queira comprar poções de mana
                    {
                        Console.WriteLine("Quantas unidades você gostaria de comprar? Digite 0 para cancelar a compra");
                        quantidade = int.Parse(Console.ReadLine());

                        if (quantidade != 0)
                        {
                            while ((saldo_2 - quantidade * 15) < 0)
                            {
                                Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                                quantidade = int.Parse(Console.ReadLine());
                            }

                            saldo_2 -= 15 * quantidade;
                            Poção_de_Mana_2 += quantidade;

                            Console.WriteLine($"Você comprou {quantidade} poções de mana e gastou {15 * quantidade} pila");

                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }
                    if (op == "3") //Caso o jogador queira comprar a poção estranha
                    {
                        Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                        op = Console.ReadLine();

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
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");

                            //Trava
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            if (op == "1")
                            {
                                armadura_2 = 10;
                                saldo_2 -= 30;
                                Console.WriteLine("Você gastou 30 pila e conseguiu uma armadura de malha capaz de te proteger de ataques corpo-a-corpo");

                                //Trava
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }

                    if (op == "5") //Caso o jogador queira comprar o manto
                    {
                        if (saldo_2 < 40)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");

                            //Trava
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            if (op == "1")
                            {
                                manto_2 = 5;
                                saldo_2 -= 40;
                                Console.WriteLine("Você gastou 40 pila e comprou robes capazes de te proteger de efeitos mágicos");

                                //Trava
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }

                    if (op == "6") //Caso o jogador queira comprar a espada
                    {
                        if (saldo_2 < 30)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");

                            //Trava
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            if (op == "1")
                            {
                                espada_2 = 10;
                                saldo_2 -= 30;
                                Console.WriteLine("Você gastou 30 pila e conseguiu uma espada melhor");

                                //Trava
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }

                    if (op == "7") //Caso o jogador queira comprar as runas
                    {
                        if (saldo_2 < 40)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");

                            //Trava
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Você tem certeza que quer continuar essa compra?\n1. Sim\n2. Não");
                            op = Console.ReadLine();

                            if (op == "1")
                            {
                                runas_2 = true;
                                saldo_2 -= 40;
                                Console.WriteLine("Você gastou 40 pila e comprou runas que emitem uma forte energia mágica");

                                //Trava
                                Console.WriteLine("\n Digite ENTER para continuar");
                                Console.ReadLine();
                            }
                        }
                    }
                    Console.Clear();

                    //Trava
                    Console.WriteLine("Obrigado pela preferência! Volte sempre");
                    Console.WriteLine("\n\nDigite ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
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
Consumível, recupera 10 de vida, custa 10 pila cada unidade

2. Poção de Mana: Recupera parte da sua energia mágica. 
Consumível, recupera 5 de mana, custa 15 pila cada unidade");


            //Opções que irão desaparecer caso o jogador as compre
            if (player == 1 && Poção_Estranha_1 == 0 || player == 2 && Poção_Estranha_2 == 0)
            {
                Console.WriteLine("\n3. Poção Estranha: Um líquido preto estranho que se contorce dentro do frasco, não fazemos ideia do que pode fazer, tome por sua conta e risco. \nConsumível, ???????????, custa 1 pila");
            }
            if (player == 1 && armadura_1 == 0 || player == 2 && armadura_2 == 0) //Mostrar a opção de armadura caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n4. Armadura de Cota de Malha: Uma armadura feita de argolas de ferro, eficiente contra ataques corpo-a-corpo. \nArmadura, reduz 10 de dano de todo ataque físico, custa 30 pila");
            }
            if (player == 1 && manto_1 == 0 || player == 2 && manto_2 == 0) //Mostrar a opção de manto arcano caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n5. Manto Arcano: Uma roupa marcada com diversos símbolos místicos, eficiente contra efeitos mágicos. \nArmadura, reduz todo dano mágico em 5, custa 40 pila");
            }
            if (player == 1 && espada_1 == 0 || player == 2 && espada_2 == 0) //Mostrar a opção de espada balanceada caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n6. Espada Balanceada: Uma espada feita por um ferreiro extremamente habilidoso, feita para golpes certeiros. \nEquipamento, aumenta seu dano físico em 10, custa 30 pila");
            }
            if (player == 1 && runas_1 == false || player == 2 && runas_2 == false) //Mostrar a opção de runas arcana caso o jogador ainda não a tenha escolhido
            {
                Console.WriteLine($"\n7. Runas Arcanas: Uma bolsa com runas capazes de amplificar suas magias, mas de uma forma misteriosa. \nEquipamento, amplifica o efeito de suas magias, custa 40 pila");
            }


            //opção de sair da loja
            Console.WriteLine("\n8. Sair da loja");
        }


        static void EscolherAtributos()
        {
            //Definindo Força do jogador 1
            Console.WriteLine("Jogador 1, escolha seu modificador de Força. Você dará mais dano em ataques corpo a corpo, mas terá menos mana");
            Console.Write("\nForça (0 - 10): ");
            forca_1 = int.Parse(Console.ReadLine());


            //Trava para Força não ser menor ou maior que o estipulado
            while (forca_1 < 0 || forca_1 > 10)
            {
                Console.WriteLine("\nERRO! O valor do seu modificador de Força deve estar entre 0 e 10, digite um valor nesse intervalo");
                forca_1 = int.Parse(Console.ReadLine());
            }


            //Mostrar Força e Mana do player 1 (a Mana é 10 + (20 - força selecionada))
            Console.WriteLine("\nSua Força é: " + forca_1);
            Mana_Player_1 += 20 - forca_1;
            Console.WriteLine("Sua Mana é: " + Mana_Player_1);


            //Caso o modo MultiPlayer tenha sido escolhido, começa a vez do player 2 de definir sua Força
            if (Singleplayer == false)
            {
                Console.WriteLine("\nDigite ENTER para continuar");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Jogador 2, escolha seu modificador de Força. Você dará mais dano em ataques corpo a corpo, mas terá menos mana");
                Console.Write("Força (1 - 10): ");
                forca_2 = int.Parse(Console.ReadLine());

                while (forca_2 < 0 || forca_2 > 10)
                {
                    Console.WriteLine("\nERRO! O valor do seu modificador de Força deve estar entre 0 e 10, digite um valor nesse intervalo");
                    forca_1 = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Sua força é: " + forca_2);
                Mana_Player_2 += 20 - forca_2;
                Console.WriteLine("Sua mana é: " + Mana_Player_2);
            }


            //Trava
            Console.WriteLine("\nDigite ENTER para continuar");
            Console.ReadLine();
            Console.Clear();
        }


        static void EscolherMagias()
        {
            //Todas as opções de magia
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


            //Info
            Console.WriteLine("As magias são poderes invocados a partir da energia arcana, você pode escolher 3 para levar a batalha\n");


            //Escrevendo as opções do player
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


            //Começa a seleção do player 1
            Console.WriteLine("Jogador 1, escolha suas magias");
            //O código irá se repetir 3 vezes, com o jogador escolhendo uma magia por vez
            for (int x = 0; x < 3; x++)
            {
                //Entrando a opção
                int y = int.Parse(Console.ReadLine());
                //O array (magias_p1) no índice do valor de x armazena o o nome da magia escrita no array (op_magias) no índice y - 1 (a opção do jogador menos 1)
                magias_p1[x] = op_magias[y - 1];
                //Iguala a "0" o texto do array (op_magias) que acabou de ser copiado
                op_magias[y - 1] = "0";


                //Trava para o jogador não escolher duas vezes a mesma magia
                while (magias_p1[x] == "0") //Verifica se o texto do array (magias_p1) é igual a "0", por que isso significa que a magia já foi escolhida
                {
                    //Aviso
                    Console.WriteLine("\nERRO! A magia selecionada é igual a alguma já escolhida, escolha outra!");
                    //Entrar opção
                    y = int.Parse(Console.ReadLine());
                    magias_p1[x] = op_magias[y - 1];
                    op_magias[y - 1] = "0";
                }


                //Mostrar a magia escolhida
                Console.WriteLine($"A magia escolhida foi: {magias_p1[x]}");
            }


            //Trava
            Console.WriteLine("\nDigite ENTER para continuar");
            Console.ReadLine();
            Console.Clear();


            //Caso o modo Multiplayer tenha sido escolhido o player 2 começa a selecionar suas magias
            if (Singleplayer == false)
            {
                //Reinicia o array (op_magias) para que o jogador 2 possa escolher qualquer magia que o jogador 1 já tenha escolhido
                op_magias[0] = "Bola de Fogo";
                op_magias[1] = "Relâmpago";
                op_magias[2] = "Curar Ferimentos";
                op_magias[3] = "Despedaçar";
                op_magias[4] = "Confusão";
                op_magias[5] = "Purificar";
                op_magias[6] = "Raio do Enfraquecimento";
                op_magias[7] = "Rogar Maldição";
                op_magias[8] = "Campo de Força";


                //Info
                Console.WriteLine("As magias são poderes invocados a partir da energia arcana, você pode escolher 3 para levar a batalha\n");


                //Escrevendo as opções do player
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


                //Começa a seleção do player 2
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
            //Gera um novo random
            Random r = new Random();
            int confusão = 0;
            player = 1;


            //Enquanto a a vida do player e a vida do player 2 forem maiores que 0 esse script continuará sendo executado
            while (Vida_Player_1 > 0 && Vida_Player_2 > 0)
            {
                //Caso o player seja o player 1 irá executar esse primeiro trecho
                if (player == 1)
                {
                    //Desenha o HUD
                    HUD();

                    //Verifica se os status paralizado ou confusão estão aplicados
                    if (Paralizado_1 == true || Confusão_p1 == true)
                    {
                        //Caso paralizado esteja ativo, o jogador não joga e paralizado é desativado, permitindo que ele jogue próximo turno
                        if (Paralizado_1 == true)
                        {
                            Paralizado_1 = false;
                        }

                        //Caso confusão esteja ativo, ele gera um número de 1 a 6 e, caso o resultado de 4 ou mais, o jogador se acerta e perde sua vez
                        else if (Confusão_p1 == true)
                        {
                            confusão = r.Next(1, 6);

                            if (confusão >= 4)
                            {
                                Console.WriteLine("Você está confuso e acaba acertando a sí próprio, perdendo 5 de vida");
                                Vida_Player_1 -= 5;
                            }
                            //Caso o número seja 3 ou menos, o jogador joga normalmente
                            else
                            {
                                AçõesJogadores();
                            }
                        }
                    }
                    //Caso nada da situação anterior aconteça, o jogador pode jogar normalmente
                    else
                    {
                        AçõesJogadores();
                    }

                    if (fraco1 > 0)
                    {
                        fraco1--;
                    }
                    else
                    {
                        enfraquecimento_p1 = 0;
                    }

                    //Verifica se o jogador está com o status queimado, se ele estiver ele receberá 2 de dano no final de todos os seus turnos durante 5 turnos
                    if (queimadura_1 > 0)
                    {
                        Console.WriteLine("As chamas consomem seu corpo lentamente, fazendo você receber 2 de dano");
                        Vida_Player_1 -= 2;
                        queimadura_1--;
                    }

                    EndGame();
                    campo_forca2 = 0;
                    //Zera a confusão para ela não interferir nas ações do player 2
                    confusão = 0;
                    //Define o player como 2 para que as opções dele sejam mostradas de acordo
                    player = 2;

                    fragil1 = false; cego1 = false; mudo1 = false;
                }


                //Começa a jogada do player 2
                HUD();


                if (Paralizado_2 == true || Confusão_p2 == true)
                {
                    if (Paralizado_2 == true)
                    {
                        Paralizado_2 = false;
                    }

                    else if (Confusão_p2 == true)
                    {
                        confusão = r.Next(1, 6);

                        if (confusão >= 4)
                        {
                            Console.WriteLine("Você está confuso e acaba acertando a sí próprio, perdendo 5 de vida");
                            Vida_Player_2 -= 5;

                        }
                        else
                        {
                            AçõesJogadores();
                        }
                    }
                }

                else
                {
                    AçõesJogadores();
                }

                if (fraco2 > 0)
                {
                    fraco2--;
                }
                else
                {
                    enfraquecimento_p2 = 0;
                }

                if (queimadura_2 > 0)
                {
                    Console.WriteLine("As chamas consomem seu corpo lentamente, fazendo você receber 2 de dano");
                    Vida_Player_2 -= 2;
                    queimadura_2--;
                }

                EndGame();
                campo_forca1 = 0;
                confusão = 0;
                player = 1;

                fragil2 = false; cego2 = false; mudo2 = false;

                //Trava
                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }


        static void BatalhaSingleplayer()
        {
            //Cria uma variável confusão (que será usada caso o jogador esteja confuso) e um novo random
            int confusão = 0;
            Random r = new Random();

            //Enquanto a a vida do player e a vida do Boss forem maiores que 0 esse script continuará sendo executado
            while (Vida_Player_1 > 0 && Vida_Boss > 0)
            {
                //Desenha o HUD
                HUD();

                //Verifica se os status paralizado ou confusão estão aplicados
                if (Paralizado_1 == true)
                {
                    Paralizado_1 = false;
                }

                //Caso nada da situação anterior aconteça, o jogador pode jogar normalmente
                else
                {
                    AçõesJogadores();
                }

                //Verifica se o jogador está com o status queimado, se ele estiver ele receberá 2 de dano no final de todos os seus turnos durante 5 turnos
                if (queimadura_1 > 0)
                {
                    Console.WriteLine("As chamas consomem seu corpo lentamente, fazendo você receber 2 de dano");
                    Vida_Player_1 -= 2;
                    queimadura_1--;
                }

                EndGame();


                //Começa o turno do Boss

                if (Paralizado_2 == true || Confusão_p2 == true)
                {
                    if (Paralizado_2 == true)
                    {
                        Paralizado_2 = false;
                    }

                    else if (Confusão_p1 == true)
                    {
                        confusão = r.Next(1, 6);

                        if (confusão >= 4)
                        {
                            Console.WriteLine("Você vê seu inimigo confuso e acertando a sí próprio, perdendo 5 de vida");
                            Vida_Boss -= 5;
                        }
                        else
                        {
                            Boss();
                        }
                    }
                }
                else
                {
                    Boss();
                }

                if (queimadura_2 > 0)
                {
                    Console.WriteLine("As chamas consomem o corpo do seu inimigo lentamente, fazendo ele receber 2 de dano");
                    Vida_Player_1 -= 2;
                    queimadura_1--;
                }

                EndGame();

                if (fraco2 > 0)
                {
                    fraco2--;
                }
                else
                {
                    enfraquecimento_p2 = 0;
                }

                fragil2 = false; cego2 = false; mudo2 = false;
                campo_forca1 = 0;
            }
        }


        static void HUD()
        {
            //Caso o modo MultiPlayer tenha sido escolhido
            if (Singleplayer == false)
            {
                //Caso o player atual seja o player 1
                if (player == 1)
                {
                    //Escreve as informações (Vida e Mana do player 1 e 2)
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    Console.Write("Vida do Player 1: " + Vida_Player_1 + "         Mana do Player 1: " + Mana_Player_1 + "\n");

                    Console.Write("Vida do Player 2: " + Vida_Player_2 + "        Mana do Player 2: " + Mana_Player_2 + "\n");


                    //Caso o jogador esteja paralizado
                    if (Paralizado_1 == true)
                    {
                        Console.WriteLine("\nVocê não consegue se mover!");
                    }
                    //Se não, texto estético
                    else
                    {
                        Console.WriteLine("\nJogador 1, escolha seu movimento!");
                    }
                }
                //Caso o player atual seja o player 2
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
            //Caso o modo SinglePlayer tenha sido escolhido
            else if (Singleplayer == true)
            {
                //Escreva as informações (Vida e Mana do player 1 e do Boss)
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.Write("Vida do Herói: " + Vida_Player_1 + "         Mana do Herói: " + Mana_Player_1 + "\n");

                Console.Write("Vida do Adversário: " + Vida_Boss + "        Mana do Adversário: " + Mana_Boss + "\n");


                //Caso o jogador esteja paralizado
                if (Paralizado_1 == true)
                {
                    Console.WriteLine("\nVocê não consegue se mover!");
                }
                //Se não, texto estético
                else
                {
                    Console.WriteLine("\nJogador 1, escolha seu movimento!");
                }
            }
        }


        static void AçõesJogadores()
        {
            //Opções
            Console.WriteLine("\n1. Atacar");
            Console.WriteLine("2. Magia");
            Console.WriteLine("3. Itens");
            Console.WriteLine("");

            //Entrando a opção
            op = Console.ReadLine();
            Console.WriteLine("");


            if (op == "1") //Caso a opção seja atacar
            {
                Ataque();
            }
            else if (op == "2" && (mudo1 == false || mudo2 == false)) //Caso a opção seja lançar uma magia
            {

                if (player == 1) //Caso o jogador atual seja o player 1, mostra suas magias
                {
                    Console.WriteLine("1. " + magias_p1[0]);
                    Console.WriteLine("2. " + magias_p1[1]);
                    Console.WriteLine("3. " + magias_p1[2]);
                }
                else if (player == 2) //Caso o jogador atual seja o player 2, mostra suas magias
                {
                    Console.WriteLine("1. " + magias_p2[0]);
                    Console.WriteLine("2. " + magias_p2[1]);
                    Console.WriteLine("3. " + magias_p2[2]);
                }

                //Mostra a opção "voltar"
                Console.WriteLine("4. Voltar");
                Console.WriteLine("");

                //Entrando a opção
                op = Console.ReadLine();
                Console.WriteLine("");

                Magia();
            }
            else if (op == "2")
            {
                Console.WriteLine("Você tenta proferir as palavras mágicas para lançar magias, escolha outra opção");
                AçõesJogadores();
            }
            else if (op == "3") //Caso a opção seja usar um item
            {
                //Opções
                Console.WriteLine("1. Poção de Cura");
                Console.WriteLine("Recupera 10 de vida");
                if (player == 1)
                {
                    Console.WriteLine($"Quantidade: {Poção_de_Cura_1}");
                }
                else
                {
                    Console.WriteLine($"Quantidade: {Poção_de_Cura_2}");
                }
                Console.WriteLine("2. Poção de Mana");
                Console.WriteLine("Recupera 5 de mana");
                if (player == 1)
                {
                    Console.WriteLine($"Quantidade: {Poção_de_Mana_1}");
                }
                else
                {
                    Console.WriteLine($"Quantidade: {Poção_de_Mana_2}");
                }
                Console.WriteLine("3. Poção Estranha");
                Console.WriteLine("????????");
                if (player == 1)
                {
                    Console.WriteLine($"Quantidade: {Poção_Estranha_1}");
                }
                else
                {
                    Console.WriteLine($"Quantidade: {Poção_Estranha_2}");
                }
                Console.WriteLine("4. Voltar");
                Console.WriteLine("");

                //Entrando a opção
                op = Console.ReadLine();
                Console.WriteLine("");

                Item();
            }
        }


        static void Ataque()
        {
            //Gera um novo random e atribui a uma variável Ataque um valor aleatório
            Random rPlayer = new Random();
            int Ataque = rPlayer.Next(6);

            if ((player == 1 && cego1 == true || player == 2 && cego2 == true) && Ataque == 5)
            {
                Console.WriteLine("Você não consegue enxergar direito e erra");
            }

            else
            {
                if (Ataque <= 2) //Caso o random tenha dado 2 ou menos, ele dá o dano padrão (15) + os modificadores no jogador 2
                {
                    if (Singleplayer == true) //Caso o modo SinglePlayer tenha sido escolhido (o dano é direcionado ao Boss)
                    {
                        dano = 15 + forca_1 + espada_1 - armadura_2 - enfraquecimento_p1;
                        if (dano < 0)
                        {
                            dano = 0;
                        }
                        Vida_Boss -= 0;
                        Console.WriteLine($"Você acerta! O inimigo perde {dano} de vida");
                    }
                    else if (player == 1) //Caso o modo MultiPlayer tenha sido escolhido e o player = 1 (o dano é direcionado ao player 2)
                    {
                        dano = 15 + forca_1 + espada_1 - armadura_2 - enfraquecimento_p1 - campo_forca2;
                        if (dano < 0)
                        {
                            dano = 0;
                        }
                        Vida_Player_2 -= dano;
                        Console.WriteLine($"Você acerta! O inimigo perde {dano} de vida");
                    }
                    else //Caso o modo MultiPlayer tenha sido escolhido e o player = 2 (o dano é direcionado ao player 1)
                    {
                        dano = 15 + forca_2 + espada_2 - armadura_1 - enfraquecimento_p2 - campo_forca1;
                        if (dano < 0)
                        {
                            dano = 0;
                        }
                        Vida_Player_1 -= dano;
                        Console.WriteLine($"Você acerta! O inimigo perde {dano} de vida");
                    }

                }
                else if (Ataque >= 3 && Ataque <= 4) //Caso o random esteja entre 3 e 4 é um golpe crítico, onde o dano base é dobrado (valendo 30)
                {
                    if (Singleplayer == true)
                    {
                        dano = 30 + forca_1 + espada_1 - armadura_2;
                        if (dano < 0)
                        {
                            dano = 0;
                        }
                        Vida_Boss -= dano;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {dano} de vida");
                    }
                    else if (player == 1)
                    {
                        dano = 30 + forca_1 + espada_1 - armadura_2 - enfraquecimento_p1 - campo_forca2;
                        if (dano < 0)
                        {
                            dano = 0;
                        }
                        Vida_Player_2 -= dano;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {dano} de vida");
                    }
                    else
                    {
                        dano = 30 + forca_2 + espada_2 - armadura_1 - enfraquecimento_p2 - campo_forca1;
                        if (dano < 0)
                        {
                            dano = 0;
                        }
                        Vida_Player_1 -= dano;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {dano} de vida");
                    }

                }
                else if (Ataque == 5) //Caso o random tenha dado 5, o jogador erra
                {
                    Console.WriteLine("Você errou!");
                }
            }

            if (player == 1 && fragil1 == true || player == 2 && fragil2 == true)
            {
                Fragil();
            }
        }


        static void Magia()
        {
            //Cria um novo random e uma nova variável que se iguala a um resultado aleatório
            Random rPlayer2 = new Random();
            int Magias = rPlayer2.Next(6);


            if (op == "4") //Caso a opção seja igual a "4" retorna para o menu de ações
            {
                if (Singleplayer == true)
                {
                    BatalhaSingleplayer();
                }
                else
                {
                    BatalhaMultiplayer();
                }
            }

            else if (player == 1 && magias_p1[Convert.ToInt32(op) - 1].Contains("Bola de Fogo") || player == 2 && magias_p2[Convert.ToInt32(op) - 1].Contains("Bola de Fogo")) //Caso o texto armazenado no array (magias_p1 ou 2) no índice [op (que acabou de ser digitada) - 1] seja igual a "Bola de Fogo"
            {
                if (player == 1 && Mana_Player_1 < 10 || player == 2 && Mana_Player_2 < 10) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                    AçõesJogadores();
                }
                else
                {
                    //Verificação de qual player está jogando (para perder 10 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 10;
                    }
                    else
                    {
                        Mana_Player_2 -= 10;
                    }

                    if (Magias == 0) //Caso o random seja 0 o jogador erra, mas a explosão da Bola de Fogo ainda acerta
                    {
                        if (Singleplayer == true)
                        {
                            Vida_Boss -= 10;
                            Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                        }
                        else if (player == 1)
                        {
                            Vida_Player_2 -= 10 - manto_2;
                            Console.WriteLine($"Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde {10 - manto_2} de vida");
                        }
                        else
                        {
                            Vida_Player_1 -= 10 - manto_1;
                            Console.WriteLine($"Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde {10 - manto_1} de vida");
                        }
                    }
                    else if (Magias >= 1 && Magias <= 4) //Caso o random esteja entre 1 e 4 o jogador acerta
                    {
                        if (Singleplayer == true)
                        {
                            Vida_Boss -= 20;
                            Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 20 de vida");
                        }
                        else if (player == 1)
                        {
                            Vida_Player_2 -= 20 - manto_2;
                            Console.WriteLine($"Você acerta sua Bola de Fogo. O inimigo perde {20 - manto_2} de vida");
                        }
                        else
                        {
                            Vida_Player_1 -= 20 - manto_1;
                            Console.WriteLine($"Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde {20 - manto_1} de vida");
                        }
                    }
                    else if (Magias == 5) //Caso o random seja 5 o jogador faz um acerto crítico
                    {
                        if (Singleplayer == true)
                        {
                            Vida_Boss -= 30;
                            Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 30 de vida");
                        }
                        else if (player == 1)
                        {
                            Vida_Player_2 -= 30 - manto_2;
                            Console.WriteLine($"Você acerta sua Bola de Fogo. O inimigo perde {30 - manto_2} de vida");
                        }
                        else
                        {
                            Vida_Player_1 -= 30 - manto_1;
                            Console.WriteLine($"Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde {30 - manto_1} de vida");
                        }

                        if (runas_1 == true && manto_2 == 0 || runas_2 == true && manto_1 == 0) //Caso o jogador tenha comprado as runas arcanas o jogador 2 fica queimado
                        {
                            Console.WriteLine("\nUma runa vermelha arde no seu bolso, você vê que seu inimigo ficou Queimado!");

                            if (player == 1)
                            {
                                queimadura_2 = 5;
                            }
                            else
                            {
                                queimadura_1 = 5;
                            }
                        }
                    }
                }
            }

            else if (player == 1 && magias_p1[Convert.ToInt32(op) - 1].Contains("Relâmpago") || player == 2 && magias_p2[Convert.ToInt32(op) - 1].Contains("Relâmpago")) //Caso o texto armazenado no array (magias_p1 ou 2) no índice [op (que acabou de ser digitada) - 1] seja igual a "Relâmpago"
            {
                if (player == 1 && Mana_Player_1 < 5 || player == 2 && Mana_Player_2 < 5) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                    AçõesJogadores();
                }
                else
                {
                    //Verificação de qual player está jogando (para perder 5 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 5;
                    }
                    else
                    {
                        Mana_Player_2 -= 5;
                    }

                    if (Magias == 0) //Caso o random seja 0 o jogador erra
                    {
                        Console.WriteLine("Você lança um raio e erra");
                    }
                    else if (Magias >= 1 && Magias <= 4) //Caso o random esteja entre 1 e 4 o jogador acerta
                    {
                        if (Singleplayer == true)
                        {
                            Vida_Boss -= 10;
                            Console.WriteLine($"Você acerta seu raio no inimigo. O inimigo perde 10 de vida");
                        }
                        else if (player == 1)
                        {
                            Vida_Player_2 -= 10 - manto_2;
                            Console.WriteLine($"Você acerta seu raio no inimigo. O inimigo perde {10 - manto_2} de vida");
                        }
                        else
                        {
                            Vida_Player_1 -= 10 - manto_1;
                            Console.WriteLine($"Você acerta seu raio no inimigo. O inimigo perde {10 - manto_1} de vida");
                        }
                    }
                    else if (Magias == 5) //Caso o random seja 5 o jogador faz um acerto crítico
                    {
                        if (Singleplayer == true)
                        {
                            Vida_Boss -= 20;
                            Console.WriteLine($"Você acerta um raio em cheio no peito do inimigo. O inimigo perde 20 de vida");
                        }
                        else if (player == 1)
                        {
                            Vida_Player_2 -= 20 - manto_2;
                            Console.WriteLine($"Você acerta um raio em cheio no peito do inimigo. O inimigo perde {20 - manto_2} de vida");
                        }
                        else
                        {
                            Vida_Player_1 -= 20 - manto_1;
                            Console.WriteLine($"Você acerta um raio em cheio no peito do inimigo. O inimigo perde {20 - manto_1} de vida");
                        }


                        if (runas_1 == true && manto_2 == 0) //Caso o jogador tenha comprado as runas arcanas o alvo fica paralizado
                        {
                            Console.WriteLine("Você vê uma runa azul brilhando no seu bolso, e seu inimigo fica paralizado!");
                            Paralizado_2 = true;
                        }
                    }
                }
            }

            else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Curar Ferimentos") || magias_p2[Convert.ToInt32(op) - 1].Contains("Curar Ferimentos")) //Caso o texto armazenado no array (magias_p1) no índice [op (que acabou de ser digitada) - 1] seja igual a "Curar Ferimentos"
            {
                if (player == 1 && Mana_Player_1 < 5 || player == 2 && Mana_Player_2 < 5) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                    AçõesJogadores();
                }

                else
                {
                    //Verificação de qual player está jogando
                    if (player == 1)
                    {
                        Mana_Player_1 -= 5;
                        Vida_Player_1 += 20;
                        Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                    }
                    else
                    {
                        Mana_Player_2 -= 5;
                        Vida_Player_2 += 20;
                        Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                    }

                    if (runas_1 == true || runas_2 == true) //Caso o jogador tenha comprado as runas arcanas ele recupera 10 de vida adicionais (totalizando 30 de cura)
                    {
                        Console.WriteLine("Uma runa amarela começa a brilhar no seu bolso, você sente uma sensação de alívio. Você recuperou mais 10 de vida!");
                        if (player == 1)
                        {
                            Vida_Player_1 += 10;
                        }
                        else
                        {
                            Vida_Player_2 += 10;
                        }
                    }
                }
            }

            else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Despedaçar") || magias_p2[Convert.ToInt32(op) - 1].Contains("Despedaçar")) //Caso o texto armazenado no array (magias_p1) no índice [op (que acabou de ser digitada) - 1] seja igual a "Despedaçar"
            {
                if (player == 1 && Mana_Player_1 < 5 || player == 2 && Mana_Player_2 < 5) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                }
                else
                {
                    //Verificação de qual player está jogando (para perder 5 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 5;
                    }
                    else
                    {
                        Mana_Player_2 -= 5;
                    }

                    int destruir = rPlayer2.Next(1, 12);

                    Console.WriteLine("Esta magia emite um som alto e agudo, com a tentativa de destruir uma armadura do seu oponente.");

                    if (destruir == 4 && (manto_2 > 0 || manto_1 > 0))
                    {
                        if (Singleplayer == true)
                        {
                            manto_2 = 10;
                        }
                        else if (player == 1)
                        {
                            manto_2 = 0;
                        }
                        else
                        {
                            manto_1 = 0;
                        }

                        Console.WriteLine("\nVocê destruiu o manto do inimigo!");
                    }
                    else if (destruir == 8 && (armadura_2 > 0 || armadura_1 > 0))
                    {
                        if (Singleplayer == true)
                        {
                            armadura_2 = 10;
                        }
                        else if (player == 1)
                        {
                            armadura_2 = 0;
                        }
                        else
                        {
                            armadura_1 = 0;
                        }

                        Console.WriteLine("Você destruiu a armadura do inimigo");
                    }
                    else if (destruir == 12 && (espada_2 > 0 || espada_1 > 0))
                    {
                        if (Singleplayer == true)
                        {
                            espada_2 = 10;
                        }
                        else if (player == 1)
                        {
                            espada_2 = 0;
                        }
                        else
                        {
                            espada_1 = 0;
                        }

                        Console.WriteLine("Voce destruiu a espada do inimigo");
                    }
                    else if (destruir == 4 && manto_2 == 0 || destruir == 8 && armadura_2 == 0 || destruir == 12 && espada_2 == 0 || destruir == 4 && manto_1 == 0 || destruir == 8 && armadura_1 == 0 || destruir == 12 && espada_1 == 0)
                    {
                        if (player == 1)
                        {
                            Vida_Player_2 -= 20;
                        }
                        else
                        {
                            Vida_Player_1 -= 20;
                        }

                        Console.WriteLine("causou 20 de dano ao seu inimigo");
                    }

                    if (runas_1 == true || runas_2 == true)
                    {
                        Console.WriteLine("Uma runa branca começa a vibrar no seu bolso e você vê objetos próximos do seu inimigo se estilhaçarem, o acertando");
                        if (Singleplayer == true)
                        {
                            Vida_Boss -= 5;
                        }
                        else if (player == 1)
                        {
                            Vida_Player_2 -= 5;
                        }
                        else
                        {
                            Vida_Player_1 -= 5;
                        }
                    }
                }
            }

            else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Confusão") || magias_p2[Convert.ToInt32(op) - 1].Contains("Confusão")) //Caso o texto armazenado no array (magias_p1) no índice [op (que acabou de ser digitada) - 1] seja igual a "Confusão"
            {
                if (player == 1 && Mana_Player_1 < 10 || player == 2 && Mana_Player_2 < 10) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                }
                else
                {
                    //Verificação de qual player está jogando (para perder 5 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 5;
                    }
                    else
                    {
                        Mana_Player_2 -= 5;
                    }

                    if (Magias <= 3)
                    {
                        if (Singleplayer == true)
                        {
                            Confusão_p2 = true;
                        }
                        else if (player == 1)
                        {
                            Confusão_p2 = true;
                        }
                        else
                        {
                            Confusão_p1 = true;
                        }
                        Console.WriteLine("Você conjura a magia confusão, e deixa o seu inimigo se comportando de modo aleatorio");
                    }
                    else if (player == 1 && manto_1 == 0 || player == 2 && manto_2 == 0)
                    {
                        if (Singleplayer == true && manto_1 == 0)
                        {
                            Confusão_p1 = true;
                        }
                        else if (player == 1 && manto_1 == 0)
                        {
                            Confusão_p1 = true;
                        }
                        else if (player == 2 && manto_2 == 0)
                        {
                            Confusão_p2 = true;
                        }
                        Console.WriteLine("Você conjura a magia confusão, e falha, e deixa seu comportamento em modo aleatorio");
                    }
                    else
                    {
                        Console.WriteLine("Você não consegue lançar a magia, mas algo impede o efeito de confusão de te afetar");
                    }
                }
            }

            else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Purificar") || magias_p2[Convert.ToInt32(op) - 1].Contains("Purificar")) //Caso o texto armazenado no array (magias_p1) no índice [op (que acabou de ser digitada) - 1] seja igual a "Purificar"
            {
                if (player == 1 && Mana_Player_1 < 5 || player == 2 && Mana_Player_2 < 5) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                }

                else
                {
                    //Verificação de qual player está jogando (para perder 5 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 5;
                    }
                    else
                    {
                        Mana_Player_2 -= 5;
                    }

                    if (player == 1)
                    {
                        Console.WriteLine("Com a ajuda dos espiritos você pede a benção deles, capaz de tirar os seus efeitos negativos");
                        enfraquecimento_p1 = 0;
                        queimadura_1 = 0;
                    }
                    else
                    {
                        Console.WriteLine("Com a ajuda dos espiritos você pede a benção deles, capaz de tirar os seus efeitos negativos");
                        enfraquecimento_p2 = 0;
                        queimadura_2 = 0;
                    }
                }
            }

            else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Raio do Enfraquecimento") || magias_p2[Convert.ToInt32(op) - 1].Contains("Raio do Enfraquecimento")) //Caso o texto armazenado no array (magias_p1) no índice [op (que acabou de ser digitada) - 1] seja igual a "Raio do Enfraquecimento"
            {
                if (player == 1 && Mana_Player_1 < 10 || player == 2 && Mana_Player_2 < 10) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                }

                else
                {
                    //Verificação de qual player está jogando (para perder 10 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 10;
                    }
                    else
                    {
                        Mana_Player_2 -= 10;
                    }

                    if (Singleplayer == true)
                    {
                        enfraquecimento_p2 = 10;
                        fraco2 = 3;
                    }
                    else if (player == 1)
                    {
                        enfraquecimento_p2 = 10;
                        fraco2 = 3;
                    }
                    else
                    {
                        enfraquecimento_p1 = 10;
                        fraco1 = 3;
                    }
                    Console.WriteLine("Você concentra sua magia, e solta um raio que enfraqueçe o seu adversario");
                }
            }

            else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Rogar Maldição") || magias_p2[Convert.ToInt32(op) - 1].Contains("Rogar Maldição")) //Caso o texto armazenado no array (magias_p1) no índice [op (que acabou de ser digitada) - 1] seja igual a "Rogar Maldição"
            {
                if (player == 1 && Mana_Player_1 < 10 || player == 2 && Mana_Player_2 < 10) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                }

                else
                {
                    //Verificação de qual player está jogando (para perder 10 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 10;
                    }
                    else
                    {
                        Mana_Player_2 -= 10;
                    }

                    Console.WriteLine("Você sussurra palavras e roga uma maldição em seu adversário\n1. Maldição da Fragilidade: Você faz com que o seu inimigo tenha uma chance enquanto te ataca de quebrar uma armadura\n2. Maldição da Cegueira: Aumenta a chance do seu inimigo de errar ataques\n3. Maldição do Silêncio: Gera uma área que torna tudo dentro dela silêncioso, fazendo com que seu inimigo não possa lançar magias\n");
                    Console.Write("Digite sua opção:");
                    op = Console.ReadLine();

                    if (op == "1")
                    {
                        if (Singleplayer == true)
                        {
                            fragil2 = true;
                        }
                        else if (player == 1)
                        {
                            fragil2 = true;
                        }
                        else
                        {
                            fragil1 = true;
                        }
                    }
                    else if (op == "2")
                    {
                        if (Singleplayer == true)
                        {
                            cego2 = true;
                        }
                        else if (player == 1)
                        {
                            cego2 = true;
                        }
                        else
                        {
                            cego1 = true;
                        }
                    }
                    else
                    {
                        if (Singleplayer == true)
                        {
                            mudo2 = true;
                        }
                        else if (player == 1)
                        {
                            mudo2 = true;
                        }
                        else
                        {
                            mudo1 = true;
                        }
                    }
                }
            }

            else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Campo de Força") || magias_p2[Convert.ToInt32(op) - 1].Contains("Campo de Força"))
            {
                if (player == 1 && Mana_Player_1 < 15 || player == 2 && Mana_Player_2 < 15) //Verificação se a Mana do player é insuficiênte
                {
                    Console.WriteLine("Você não consegue lançar essa magia");
                }

                else
                {
                    //Verificação de qual player está jogando (para perder 10 de Mana)
                    if (player == 1)
                    {
                        Mana_Player_1 -= 15;
                    }
                    else
                    {
                        Mana_Player_2 -= 15;
                    }

                    Console.WriteLine("Você concentra sua energia magica em sua volta, e cria um campo de força, reduzindo todo o dano que você receberia em 20");
                    if (Singleplayer == true)
                    {
                        campo_forca1 = 20;
                    }
                    else if (player == 1)
                    {
                        campo_forca1 = 20;
                    }
                    else
                    {
                        campo_forca2 = 20;
                    }
                }
            }

            if (player == 1 && fragil1 == true || player == 2 && fragil2 == true)
            {
                Fragil();
            }
        }


        static void Fragil()
        {
            Random r = new Random();
            int quebrar = r.Next(1, 13);

            if (quebrar == 4 && (manto_2 > 0 || manto_1 > 0))
            {
                if (Singleplayer == true)
                {
                    manto_2 = 10;
                }
                else if (player == 1)
                {
                    manto_2 = 0;
                }
                else
                {
                    manto_1 = 0;
                }

                Console.WriteLine("\nVocê destruiu o manto do inimigo!");
            }
            else if (quebrar == 8 && (armadura_2 > 0 || armadura_1 > 0))
            {
                if (Singleplayer == true)
                {
                    armadura_2 = 10;
                }
                else if (player == 1)
                {
                    armadura_2 = 0;
                }
                else
                {
                    armadura_1 = 0;
                }

                Console.WriteLine("Você destruiu a armadura do inimigo");
            }
            else if (quebrar == 12 && (espada_2 > 0 || espada_1 > 0))
            {
                if (Singleplayer == true)
                {
                    espada_2 = 10;
                }
                else if (player == 1)
                {
                    espada_2 = 0;
                }
                else
                {
                    espada_1 = 0;
                }

                Console.WriteLine("Voce destruiu a espada do inimigo");
            }
        }


        static void Item()
        {
            Random rPlayer = new Random();
            int Itens2 = rPlayer.Next(20);

            if (player == 1 && Poções_1 > 0 || player == 2 && Poções_2 > 0)
            {
                if (op == "4")
                {
                    if (Singleplayer == true)
                    {
                        BatalhaSingleplayer();
                    }
                    else
                    {
                        BatalhaMultiplayer();
                    }
                }

                if (op == "1" && Poção_de_Cura_1 > 0 || op == "1" && Poção_de_Cura_2 > 0)
                {
                    if (player == 1)
                    {
                        Vida_Player_1 += 10;
                        Poção_de_Cura_1 -= 1;
                    }
                    else
                    {
                        Vida_Player_2 += 10;
                        Poção_de_Cura_2 -= 1;
                    }
                    Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                }
                else
                {
                    Console.WriteLine("Você não tem nenhuma poção de cura");
                }

                if (op == "2" && Poção_de_Mana_1 > 0 || op == "2" && Poção_de_Mana_2 > 0)
                {
                    if (player == 1)
                    {
                        Mana_Player_1 += 5;
                        Poção_de_Mana_1 -= 1;
                    }
                    else
                    {
                        Mana_Player_2 += 5;
                        Poção_de_Mana_2 -= 1;
                    }
                    Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                }
                else
                {
                    Console.WriteLine("Você não tem nenhuma poção de mana");
                }

                if (op == "3" && Poção_Estranha_1 > 0 || op == "3" && Poção_Estranha_2 > 0)
                {
                    if (Itens2 == 0)
                    {
                        if (player == 1)
                        {
                            Vida_Player_1 = 0;
                        }
                        else
                        {
                            Vida_Player_2 = 0;
                        }
                        Console.WriteLine("Você bebe a poção e começa a se sentir tonto até cai desacordado");
                    }
                    else if (Itens2 >= 1 && Itens2 <= 5 && Poção_Estranha_1 > 0)
                    {
                        if (player == 1)
                        {
                            Vida_Player_1 = 100;
                            Mana_Player_1 = 20;
                            Poção_Estranha_1 -= 1;
                        }
                        else
                        {
                            Vida_Player_2 = 100;
                            Mana_Player_2 = 20;
                            Poção_Estranha_2 -= 1;
                        }
                        Console.WriteLine("Você bebe a poção e começa a se sentir completamente restaurado");
                    }
                    else if (Itens2 >= 6 && Poção_Estranha_1 > 0)
                    {
                        Console.WriteLine("Você bebe a poção e não sente nenhuma mudança");
                    }
                }
                else
                {
                    Console.WriteLine("Você não tem nenhuma poção estranha");
                }
            }
        }


        static void Boss()
        {
            Random rPlayer = new Random();
            int Boss = rPlayer.Next(20);

            while (Mana_Boss < 10 && Boss <= 10 && mudo2 == false)
            {
                Boss = rPlayer.Next(20);
            }

            if (cego2 == true && Boss >= 15)
            {
                Console.WriteLine("Seu adversário tenta te acertar, mas parece não conseguir te enxergar direito");
            }

            else
            {
                if (Boss == 0)
                {
                    if (manto_1 > 0)
                    {
                        Console.WriteLine("Seu inimigo começa a sussurar palavras estranhas, mas algo que você possui te protege");
                    }
                    else
                    {
                        Paralizado_1 = true;
                        Mana_Boss -= 10;
                        Console.WriteLine("Seu inimigo começa a sussurrar palavras estranhas. Você se sente congelado");
                    }
                }
                else if (Boss >= 1 && Boss <= 5)
                {
                    Mana_Boss -= 10;
                    Console.WriteLine("Seu inimigo canaliza uma torrente de energia negativa na sua direção, mas erra");
                }
                else if (Boss >= 6 && Boss <= 10)
                {
                    Vida_Player_1 -= 20 - manto_1;
                    Mana_Boss -= 10;
                    Console.Write($"Seu inimigo canaliza uma torrente de energia negativa na sua direção. Você perde {20 - manto_1} de vida");
                    if (manto_1 > 0)
                    {
                        Console.WriteLine(" e você começa a pegar fogo");
                        queimadura_1 = 3;
                    }
                }
                else if (Boss >= 11 && Boss <= 14)
                {
                    Console.WriteLine("Seu inimigo tenta te acertar com um ataque, mas erra.");
                }
                else if (Boss >= 15 && Boss <= 18)
                {
                    dano = 15 - armadura_1 - fraco2 - campo_forca1;
                    if (dano < 0)
                    {
                        dano = 0;
                    }
                    Vida_Player_1 -= dano;
                    Console.WriteLine($"Seu inimigo te acerta com um ataque. Você perde {dano} de vida.");
                }
                else
                {
                    dano = 30 - armadura_1 - fraco2 - campo_forca1;
                    if (dano < 0)
                    {
                        dano = 0;
                    }
                    Vida_Player_1 -= dano;
                    Console.WriteLine($"Seu inimigo te acerta em cheio. Você perde {dano} de vida.");
                }
            }

            Console.WriteLine("\nPressione Enter para continuar");
            Console.ReadLine();
            Console.Clear();

            if (fraco2 > 0)
            {
                fraco2--;
            }

            if (fragil2 == true)
            {
                Fragil();
            }
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
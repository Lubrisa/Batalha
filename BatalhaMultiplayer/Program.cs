using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;

namespace Batalha2
{
    class Program
    {
        //Atributos de player (para definir o player atual) e de escolha de opções
        static int player = 1;
        static string op = null;

        // Atributos do Jogador 1
        static int forca_1, Vida_Player_1 = 100, Mana_Player_1 = 10, Poção_de_Cura_1 = 0, Poção_de_Mana_1 = 0, Poção_Estranha_1 = 0, Poções_1 = Poção_Estranha_1 + Poção_de_Mana_1 + Poção_de_Cura_1, queimadura_1 = 0, armadura_1 = 0, manto_1 = 0, espada_1 = 0;
        static bool Paralizado_1 = false, runas_1;
        static string[] magias_p1 = { "0", "0", "0" };


        // Atributos do Jogador 2
        static int forca_2, Vida_Player_2 = 100, Mana_Player_2 = 10, Poção_de_Cura_2 = 0, Poção_de_Mana_2 = 0, Poção_Estranha_2 = 0, Poções_2 = Poção_Estranha_2 + Poção_de_Mana_2 + Poção_de_Cura_2, queimadura_2 = 0, armadura_2 = 0, manto_2 = 0, espada_2 = 0;
        static bool Paralizado_2 = false, runas_2;
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

Para começa, você deve selecionar um modo de jogo, SinglePlayer ou MultiPlayer
Caso você selecione SinglePlayer, você irá lutar contra um inimigo controlado pelo computador
Se você selecionar MultiPlayer, você e outro jogador poderão se enfrentar em uma série de turnos
Seu objetivo é levar seu adversário 0 de Vida o atacando, lançando poderosas magias, que consomem sua Mana, e usando seus itens, de um estoque limitado
Para selecionar uma opção digite o apenas número dela

Se você entendeu, pressione ENTER");

            //Trava
            Console.ReadLine();
            Console.Clear();

            //Escolher entre SinglePlayer e MultiPlayer
            EscolherPartida();
            if (Singleplayer == false)
            {
                BatalhaMultiplayer();
            }
            else if (Singleplayer == true)
            {
                //BatalhaSingleplayer();
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

            //Entrar Escolha
            Console.Write("\nEscolha o modo em que você irá jogar: ");
            op = Console.ReadLine();

            //Verificação da Escolha

            //Para SinglePlayer
            if (op == "1")
            {
                Singleplayer = true;
                Console.WriteLine("\nVocê escolheu o modo SinglePlayer");
            }
            //Para MultiPlayer
            else if (op == "2")
            {
                Singleplayer = false;
                Console.WriteLine("\nVocê escolheu o modo MultiPlayer");
            }

            //Trava
            Console.WriteLine("\nAperte ENTER para continuar");
            Console.ReadLine();
            Console.Clear();

            //Envia para o "Menu" de Escolha de Magias
            EscolherMagias();
            //Envia para a Loja (Comprar os Equipamentos)
            Loja();
            //Envia para o "Menu" de Atributos (Escolher os valores de força (que afeta a mana))
            EscolherAtributos();


            //Verificação do Tipo de Partida Escolhida, Enviando para o Método Específico para que a Ordem de Turnos esteja certa
            //Caso a Partida seja SinglePlayer
            if (Singleplayer == true)
            {
                BatalhaSingleplayer();
            }
            //Caso a Partida seja MultiPlayer
            else if (Singleplayer == false)
            {
                BatalhaMultiplayer();
            }
        }


        static void Loja()
        {
            int saldo_1 = 100;
            int saldo_2 = 100;


            Console.WriteLine("Bem vindo a loja player 1! Aqui você poderá comprar itens que te ajudarão durante sua batalha");

            while (saldo_1 > 0 && op != "8")
            {
                OpsLoja();

                Console.WriteLine($"\nSeu saldo: {saldo_1}\n\nO que você gostaria de comprar?");
                Console.Write("Digite sua escolha: ");

                op = Console.ReadLine();
                int quantidade = 0;
                Console.WriteLine("");

                if (op == "1")
                {
                    Console.WriteLine("Quantas unidades você gostaria de comprar?");
                    quantidade = int.Parse(Console.ReadLine());


                    while ((saldo_1 - quantidade * 10) < 0)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                        quantidade = int.Parse(Console.ReadLine());
                    }


                    saldo_1 -= 10 * quantidade;
                    Poção_de_Cura_1 += quantidade;
                    Console.WriteLine($"Você comprou {quantidade} poções de cura e gastou {10 * quantidade} pila");
                    Console.WriteLine("\n Digite ENTER para continuar");
                    Console.ReadLine();
                }

                if (op == "2")
                {
                    Console.WriteLine("Quantas unidades você gostaria de comprar?");
                    quantidade = int.Parse(Console.ReadLine());


                    while ((saldo_1 - quantidade * 15) < 0)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                        quantidade = int.Parse(Console.ReadLine());
                    }


                    saldo_1 -= 15 * quantidade;
                    Poção_de_Mana_1 += quantidade;
                    Console.WriteLine($"Você comprou {quantidade} poções de mana e gastou {15 * quantidade} pila");
                    Console.WriteLine("\n Digite ENTER para continuar");
                    Console.ReadLine();
                }

                if (op == "3")
                {
                    Console.WriteLine("Quantas unidades você gostaria de comprar?");
                    quantidade = int.Parse(Console.ReadLine());


                    while ((saldo_1 - quantidade * 1) < 0)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                        quantidade = int.Parse(Console.ReadLine());
                    }


                    saldo_1 -= quantidade * 1;
                    Poção_Estranha_1 += quantidade;
                    Console.WriteLine($"Você comprou {quantidade} poções estranhas e gastou {1 * quantidade} pila");
                    Console.WriteLine("\n Digite ENTER para continuar");
                    Console.ReadLine();
                }

                if (op == "4")
                {
                    if (saldo_1 < 30)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        armadura_1 = 10;
                        saldo_1 -= 30;
                        Console.WriteLine("Você gastou 30 pila e conseguiu uma armadura de malha capaz de te proteger de ataques corpo-a-corpo");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                }

                if (op == "5")
                {
                    if (saldo_1 < 40)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        armadura_1 = 5;
                        saldo_1 -= 40;
                        Console.WriteLine("Você gastou 40 pila e comprou robes capazes de te proteger de efeitos mágicos");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                }

                if (op == "6")
                {
                    if (saldo_1 < 30)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        espada_1 = 10;
                        saldo_1 -= 30;
                        Console.WriteLine("Você gastou 30 pila e conseguiu uma espada melhor");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                }

                if (op == "7")
                {
                    if (saldo_1 < 40)
                    {
                        Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        runas_1 = true;
                        saldo_1 -= 40;
                        Console.WriteLine("Você gastou 40 pila e comprou runas que emitem uma forte energia mágica");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
            }
            Console.WriteLine("Obrigado pela preferência! Volte sempre");
            Console.WriteLine("\n\nDigite ENTER para continuar");
            Console.ReadLine();
            op = null;

            if (Singleplayer == false)
            {
                player = 2;
                Console.Clear();
            }

            if (player == 2)
            {

                Console.WriteLine("Bem vindo a loja player 2! Aqui você poderá comprar itens que te ajudarão durante sua batalha");

                while (saldo_2 > 0 && op != "8")
                {
                    OpsLoja();

                    Console.WriteLine($"\nSeu saldo: {saldo_2}");

                    op = Console.ReadLine();
                    int quantidade = 0;
                    Console.WriteLine("");

                    if (op == "1")
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

                    if (op == "2")
                    {
                        Console.WriteLine("Quantas unidades você gostaria de comprar?");
                        quantidade = int.Parse(Console.ReadLine());


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

                    if (op == "3")
                    {
                        Console.WriteLine("Quantas unidades você gostaria de comprar?");
                        quantidade = int.Parse(Console.ReadLine());


                        while ((saldo_2 - quantidade * 1) < 0)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar menos");
                            quantidade = int.Parse(Console.ReadLine());
                        }


                        saldo_2 -= quantidade * 1;
                        Poção_Estranha_2 += quantidade;
                        Console.WriteLine($"Você comprou {quantidade} poções estranhas e gastou {1 * quantidade} pila");
                        Console.WriteLine("\n Digite ENTER para continuar");
                        Console.ReadLine();
                    }

                    if (op == "4" && armadura_2 == 0)
                    {
                        if (saldo_2 < 30)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            armadura_2 = 10;
                            saldo_2 -= 30;
                            Console.WriteLine("Você gastou 30 pila e conseguiu uma armadura de malha capaz de te proteger de ataques corpo-a-corpo");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                    }

                    if (op == "5" && manto_2 == 0)
                    {
                        if (saldo_2 < 40)
                        {
                            manto_2 = 5;
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            manto_2 = 10;
                            saldo_2 -= 40;
                            Console.WriteLine("Você gastou 40 pila e comprou robes capazes de te proteger de efeitos mágicos");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }

                    }

                    if (op == "6")
                    {
                        if (saldo_2 < 30)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            espada_2 = 10;
                            saldo_2 -= 30;
                            Console.WriteLine("Você gastou 30 pila e conseguiu uma espada melhor");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }

                    }

                    if (op == "7")
                    {
                        if (saldo_2 < 40)
                        {
                            Console.WriteLine("Opa! Você não tem dinheiro para bancar isso, sinto muito, mas você vai precisar comprar outra coisa");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            runas_2 = true;
                            saldo_2 -= 40;
                            Console.WriteLine("Você gastou 40 pila e comprou runas que emitem uma forte energia mágica");
                            Console.WriteLine("\n Digite ENTER para continuar");
                            Console.ReadLine();
                        }

                    }
                    Console.Clear();
                }
            }

            if (Singleplayer == false)
            {
                Console.WriteLine("Pressione ENTER para começar a seleção de atributos");
                Console.ReadLine();
            }
            Console.Clear();
        }


        static void OpsLoja()
        {
            Console.WriteLine(@"
Sumário
Consumíveis: Cada unidade é perdida após o uso
Armaduras: Afetam sua resistência contra efeitos de certo tipo, só é possível carregar uma por vez
Equipamentos: Afetam suas ações de ataque e magias


1. Poção de Cura: Restaura sua saúde. Item consumível, recupera 20 de vida, custa 10 pila 
2. Poção de Mana: Recupera parte da sua energia mágica. Item consumível, recupera 5 de mana, custa 15 pila
3. Poção Estranha: Um líquido preto estranho que se contorce dentro do frasco, não fazemos ideia do que pode fazer. Item consumível, ???????????, custa 1 pila");
            if (player == 1 && armadura_1 == 0 || (player == 2 && armadura_2 == 0))
            {
                Console.WriteLine("4. Armadura de Cota de Malha: Uma armadura feita de argolas de ferro, eficiente contra ataques corpo-a-corpo. Armadura, reduz 10 de dano de todo ataque físico, custa 30 pila");
            }
            if (player == 1 && manto_1 == 0 || (player == 2 && manto_2 == 0))
            {
                Console.WriteLine("5. Manto Arcano: Uma roupa marcada com diversos símbolos místicos, eficiente contra efeitos mágicos. Armadura, reduz todo dano mágico em 5, custa 40 pila");
            }
            if (player == 1 && espada_1 == 0 || (player == 2 && espada_2 == 0))
            {
                Console.WriteLine("6. Espada Balanceada: Uma espada feita por um ferreiro extremamente habilidoso, feita para golpes certeiros. Equipamento, aumenta seu dano físico em 10, custa 30 pila");
            }
            if (player == 1 && runas_1 == false || (player == 2 && runas_2 == false))
            {
                Console.WriteLine("7. Runas Arcanas: Uma bolsa com runas capazes de amplificar suas magias, mas de uma forma misteriosa. Equipamento, amplifica o efeito de suas magias, custa 40 pila");
            }

            Console.WriteLine("8. Sair da loja");
        }


        static void EscolherAtributos()
        {
            //escolhendo atributos SinglePlayer
            if (Singleplayer == true)
            {
                Console.WriteLine("Escolha seu modificador de Força, ele irá afetar seus ataques, dando mais dano a eles, e a sua Mana, reduzindo seu valor inicial");
                Console.Write("\nForça (0 - 10): ");
                forca_1 = int.Parse(Console.ReadLine());
                //trava para Força não ser menor ou maior que o estipulado
                while (forca_1 < 0 || forca_1 > 10)
                {
                    Console.WriteLine("\nERRO! O valor do seu modificador de Força deve estar entre 0 e 10, digite um valor nesse intervalo");
                    forca_1 = int.Parse(Console.ReadLine());
                }
                //mostrar Força e Mana
                Console.WriteLine("\nSua Força é: " + forca_1);
                Console.WriteLine("Sua Mana é: " + (Mana_Player_1 += 20 - forca_1));

                Console.WriteLine("\nAperte ENTER para começar a luta");
                Console.ReadLine();
                Console.Clear();
            }

            //escolhendo atributos MultiPlayer
            if (Singleplayer == false)
            {
                //definindo Força do jogador 1
                Console.WriteLine("Jogador 1, escolha seu modificador de Força. Ele irá afetar seus ataques, dando mais dano a eles, e a sua Mana, reduzindo seu valor inicial");
                Console.Write("Força (0 - 10): ");
                forca_1 = int.Parse(Console.ReadLine());

                //trava para Força não ser menor ou maior que o estipulado
                while (forca_1 < 0 || forca_1 > 10)
                {
                    Console.WriteLine("\nERRO! O valor do seu modificador de Força deve estar entre 0 e 10, digite um valor nesse intervalo");
                    forca_1 = int.Parse(Console.ReadLine());
                }

                //mostrar Força e Mana
                Console.WriteLine("Sua força é: " + forca_1);
                Mana_Player_1 += 20 - forca_1;
                Console.WriteLine("Sua mana é: " + Mana_Player_1);

                Console.WriteLine("Aperte ENTER para continuar");
                Console.ReadLine();
                Console.Clear();

                //definindo Força do jogador 2
                Console.WriteLine("Jogador 2, escolha seu modificador de Força. Ele irá afetar seus ataques, dando mais dano a eles, e a sua Mana, reduzindo seu valor inicial");
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
            player = 1;
            while (Vida_Player_1 > 0 && Vida_Player_2 > 0)
            {
                if (player == 1)
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
                    if (queimadura_1 > 0)
                    {
                        Console.WriteLine("As chamas consomem seu corpo lentamente, fazendo você receber 2 de dano");
                        Vida_Player_1 -= 2;
                        queimadura_1--;
                    }
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
                        Vida_Player_2 -= 25 + forca_1 - armadura_2;
                        Console.WriteLine($"Você acerta! O inimigo perde {25 + forca_1 - armadura_2} de vida");
                    }
                    else
                    {
                        Vida_Player_2 -= 15 + forca_1 - armadura_2;
                        Console.WriteLine($"Você acerta! O inimigo perde {15 + forca_1 - armadura_2} de vida");
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
                        Vida_Player_2 -= 40 + forca_1 - armadura_2;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {40 + forca_1 - armadura_2} de vida");
                    }
                    else
                    {
                        Vida_Player_2 -= 30 + forca_1 - armadura_2;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {30 + forca_1 - armadura_2} de vida");
                    }

                }
            }

            else if (Singleplayer == false && player == 2)
            {
                if (Ataque <= 2)
                {
                    if (espada_2 > 0)
                    {
                        Vida_Player_1 -= 25 + forca_2 - armadura_1;
                        Console.WriteLine($"Você acerta! O inimigo perde {25 + forca_2 - armadura_1} de vida");
                    }
                    else
                    {
                        Vida_Player_1 -= 15 + forca_2 - armadura_1;
                        Console.WriteLine($"Você acerta! O inimigo perde {15 + forca_2 - armadura_1} de vida");
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
                        Vida_Player_1 -= 40 + forca_2 - armadura_1;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {40 + forca_2 - armadura_1} de vida");
                    }
                    else
                    {
                        Vida_Player_1 -= 30 + forca_2 - armadura_1;
                        Console.WriteLine($"Você acerta em cheio! O inimigo perde {30 + forca_2 - armadura_1} de vida");
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
                    if (player == 1 && Singleplayer == false)
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
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Bola de Fogo"))
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
                        else if (magias_p1[Convert.ToInt32(op) - 1].Contains("Bola de Fogo"))
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
using System;
using System.Threading;

namespace Batalha2
{
    class Program
    {
        static int player = 1;
        static string op = null;
        // Jogador 1
        static int forca_1;
        static int Vida_Player_1 = 100;
        static int Mana_Player_1 = 10;
        static bool Paralizado_1 = false;
        static int Poção_de_Cura_1 = 5;
        static int Poção_de_Mana_1 = 3;
        static int Poção_Estranha_1 = 1;
        static int Poções_1 = Poção_Estranha_1 + Poção_de_Mana_1 + Poção_de_Cura_1;

        // Jogador 2
        static int forca_2;
        static int Vida_Player_2 = 100;
        static int Mana_Player_2 = 10;
        static bool Paralizado_2 = false;
        static int Poção_de_Cura_2 = 5;
        static int Poção_de_Mana_2 = 3;
        static int Poção_Estranha_2 = 1;
        static int Poções_2 = Poção_Estranha_2 + Poção_de_Mana_2 + Poção_de_Cura_2;

        // Singleplayer
        static bool Singleplayer = false;
        static int Vida_Boss = 100;
        static int Mana_Boss = 20;

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


        static void EscolherPartida()
        {

            Console.WriteLine(@"

░▀█▀░█▀█░▀█▀░█▀▀░▀█▀░█▀█░█▀▄░░░▀▀█░█▀█░█▀▀░█▀█
░░█░░█░█░░█░░█░░░░█░░█▀█░█▀▄░░░░░█░█░█░█░█░█░█
░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀░▀░░░▀▀░░▀▀▀░▀▀▀░▀▀▀
           ");
            //opções
            Console.WriteLine("1. SinglePlayer");
            Console.WriteLine("2. MultiPlayer");
            //entrar escolha
            Console.Write("\nEscolha o modo em que você irá jogar: ");
            string Op_0 = Console.ReadLine();
            //verificação da escolha
            if (Op_0 == "1")
            {
                Singleplayer = true;
                Console.WriteLine("\nVocê escolheu o modo SinglePlayer");
            }
            else if (Op_0 == "2")
            {
                Singleplayer = false;
                Console.WriteLine("\nVocê escolheu o modo MultiPlayer");
            }

            Console.WriteLine("\nAperte ENTER para continuar");
            Console.ReadLine();
            Console.Clear();

            EscolherAtributos();
            if (Singleplayer == true)
            {
                BatalhaSingleplayer();
            }
            if (Singleplayer == false)
            {
                BatalhaMultiplayer();
            }
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
                BatalhaSingleplayer();
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
            BatalhaMultiplayer();
        }


        static void BatalhaMultiplayer()
        {
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
                EndGame();
                player = 1;
                Console.WriteLine("\n Pressione ENTER para continuar");
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
            if (op == "2")
            {
                Magia();
            }

            //Opções de Itens
            if (op == "3")
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
                    Vida_Player_2 -= 10 + forca_1;
                    Console.WriteLine($"Você acerta! O inimigo perde {10 + forca_1} de vida");
                }
                else if (Ataque >= 3)
                {
                    Console.WriteLine("Você errou!");

                }
                else if (Ataque == 5)
                {
                    Vida_Player_2 -= 20 + forca_1;
                    Console.WriteLine($"Você acerta em cheio! O inimigo perde {20 + forca_1} de vida");
                }
            }

            else if (Singleplayer == false && player == 2)
            {
                if (Ataque <= 2)
                {
                    Vida_Player_1 -= 10 + forca_2;
                    Console.WriteLine($"Você acerta! O inimigo perde {10 + forca_2} de vida");
                }
                else if (Ataque >= 3)
                {
                    Console.WriteLine("Você errou!");
                }
                else if (Ataque == 5)
                {
                    Vida_Player_1 -= 20 + forca_2;
                    Console.WriteLine($"Você acerta em cheio! O inimigo perde {20 + forca_2} de vida");
                }
            }

            else if (Singleplayer == true)
            {
                if (Ataque <= 2)
                {
                    Vida_Boss -= 10 + forca_1;
                    Console.WriteLine($"Você acerta! O inimigo perde {10 + forca_1} de vida");
                }
                else if (Ataque >= 3)
                {
                    Console.WriteLine("Você errou!");
                }
                else if (Ataque == 5)
                {
                    Vida_Boss -= 20 + forca_1;
                    Console.WriteLine($"Você acerta em cheio! O inimigo perde {20 + forca_1} de vida");
                }
            }
        }


        static void Magia()
        {
            if (player == 1)
            {
                if (op == "2" && Mana_Player_1 >= 5)
                {
                    //opções
                    Random rPlayer2 = new Random();
                    int Magias = rPlayer2.Next(6);

                    Console.WriteLine("1. Bola de Fogo");
                    Console.WriteLine("Um projétil incandescente que explode no impacto. Custa 10 de mana.");
                    Console.WriteLine("");
                    Console.WriteLine("2. Relâmpago");
                    Console.WriteLine("Um raio concentrado que sai da ponta dos seus dedos na direção em que você estiver apontando. Custa 5 de mana");
                    Console.WriteLine("");
                    Console.WriteLine("3. Curar Ferimentos");
                    Console.WriteLine("Um poder que restaura sua energia vital ao absorver a energia da própria terra. custa 5 de mana e recupera 20 de vida");
                    Console.WriteLine("");
                    Console.WriteLine("4. Voltar");
                    Console.WriteLine("");

                    op = Console.ReadLine();
                    Console.WriteLine("");

                    if (op == "4")
                    {
                        BatalhaMultiplayer();
                    }
                    if (player == 1 && Singleplayer == false)
                    {
                        if (op == "1")
                        {
                            if (Mana_Player_1 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                                AçõesJogadores();
                            }
                            else if (Magias == 0 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 10;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 25;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 50;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                            }
                        }
                        else if (op == "2")
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
                                Vida_Player_2 -= 20;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 5)
                            {
                                Vida_Player_2 -= 40;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                            }
                        }
                        else if (op == "3")
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
                    else if (Singleplayer == true)
                    {
                        if (op == "1")
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
                                Vida_Boss -= 25;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 10)
                            {
                                Vida_Boss -= 50;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                            }
                        }
                        else if (op == "2")
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
                                Vida_Boss -= 20;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 5)
                            {
                                Vida_Boss -= 40;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                            }
                        }
                        else if (op == "3")
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
                    if (player == 2)
                    {
                        if (op == "1")
                        {
                            if (Mana_Player_2 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Magias == 0 && Mana_Player_2 >= 10)
                            {
                                Vida_Player_1 -= 10;
                                Mana_Player_2 -= 10;
                                Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_2 >= 10)
                            {
                                Vida_Player_1 -= 25;
                                Mana_Player_2 -= 10;
                                Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_2 >= 10)
                            {
                                Vida_Player_1 -= 50;
                                Mana_Player_2 -= 10;
                                Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                            }
                        }
                        else if (op == "2")
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
                                Vida_Player_1 -= 20;
                                Mana_Player_2 -= 5;
                                Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_2 >= 5)
                            {
                                Vida_Player_1 -= 40;
                                Mana_Player_2 -= 5;
                                Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                            }
                        }
                        else if (op == "3")
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
                            }
                        }
                    }
                }

                else if (op == "2" && Mana_Player_1 < 5)
                {
                    Console.WriteLine("Você não tem mana suficiênte, escolha outra opção.");
                    AçõesJogadores();
                }
            }
            if (player == 2)
            {
                if (op == "2" && Mana_Player_2 >= 5)
                {
                    //opções
                    Random rPlayer2 = new Random();
                    int Magias = rPlayer2.Next(6);

                    Console.WriteLine("1. Bola de Fogo");
                    Console.WriteLine("Um projétil incandescente que explode no impacto. Custa 10 de mana.");
                    Console.WriteLine("");
                    Console.WriteLine("2. Relâmpago");
                    Console.WriteLine("Um raio concentrado que sai da ponta dos seus dedos na direção em que você estiver apontando. Custa 5 de mana");
                    Console.WriteLine("");
                    Console.WriteLine("3. Curar Ferimentos");
                    Console.WriteLine("Um poder que restaura sua energia vital ao absorver a energia da própria terra. custa 5 de mana e recupera 20 de vida");
                    Console.WriteLine("");
                    Console.WriteLine("4. Voltar");
                    Console.WriteLine("");

                    op = Console.ReadLine();
                    Console.WriteLine("");

                    if (op == "4")
                    {
                        BatalhaMultiplayer();
                    }
                    if (player == 1 && Singleplayer == false)
                    {
                        if (op == "1")
                        {
                            if (Mana_Player_1 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                                AçõesJogadores();
                            }
                            else if (Magias == 0 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 10;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 25;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 10)
                            {
                                Vida_Player_2 -= 50;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                            }
                        }
                        else if (op == "2")
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
                                Vida_Player_2 -= 20;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 5)
                            {
                                Vida_Player_2 -= 40;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                            }
                        }
                        else if (op == "3")
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
                    else if (Singleplayer == true)
                    {
                        if (op == "1")
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
                                Vida_Boss -= 25;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 10)
                            {
                                Vida_Boss -= 50;
                                Mana_Player_1 -= 10;
                                Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                            }
                        }
                        else if (op == "2")
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
                                Vida_Boss -= 20;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_1 >= 5)
                            {
                                Vida_Boss -= 40;
                                Mana_Player_1 -= 5;
                                Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                            }
                        }
                        else if (op == "3")
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
                    if (player == 2)
                    {
                        if (op == "1")
                        {
                            if (Mana_Player_2 < 10)
                            {
                                Console.WriteLine("Você não consegue lançar essa magia");
                            }
                            else if (Magias == 0 && Mana_Player_2 >= 10)
                            {
                                Vida_Player_1 -= 10;
                                Mana_Player_2 -= 10;
                                Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                            }
                            else if (Magias >= 1 && Magias <= 4 && Mana_Player_2 >= 10)
                            {
                                Vida_Player_1 -= 25;
                                Mana_Player_2 -= 10;
                                Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_2 >= 10)
                            {
                                Vida_Player_1 -= 50;
                                Mana_Player_2 -= 10;
                                Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                            }
                        }
                        else if (op == "2")
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
                                Vida_Player_1 -= 20;
                                Mana_Player_2 -= 5;
                                Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                            }
                            else if (Magias == 5 && Mana_Player_2 >= 5)
                            {
                                Vida_Player_1 -= 40;
                                Mana_Player_2 -= 5;
                                Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                            }
                        }
                        else if (op == "3")
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
                            }
                        }
                    }
                }

                else if (op == "2" && Mana_Player_2 < 5)
                {
                    Console.WriteLine("Você não tem mana suficiênte, escolha outra opção.");
                    AçõesJogadores();
                }
            }
        }


        static void Item()
        {
            if (player == 1)
            {
                if (op == "3" && Poções_1 > 0)
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
                            EndGame();
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
                            EndGame();
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
                                EndGame();
                            }
                            else if (op == "3" && Poção_Estranha_1 == 0)
                            {
                                Console.WriteLine("Você não tem mais nenhuma poção estranha");
                            }
                        }
                    }
                    if (player == 2)
                    {

                        if (op == "1" && Poção_de_Cura_2 > 0)
                        {
                            Vida_Player_2 += 10;
                            Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                            Poção_de_Cura_2 -= 1;
                            EndGame();
                        }
                        else if (op == "1" && Poção_de_Cura_2 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de cura");
                        }

                        else if (op == "2" && Poção_de_Mana_2 > 0)
                        {
                            Mana_Player_2 += 5;
                            Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                            Poção_de_Mana_2 -= 1;
                            EndGame();
                        }
                        else if (op == "2" && Poção_de_Mana_2 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de mana");
                        }

                        else if (op == "3")
                        {
                            if (Itens2 == 0 && Poção_Estranha_2 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e começa a se sentir tonto até cai desacordado");
                                Console.WriteLine("");
                                Vida_Player_2 = 0;
                                EndGame();
                            }
                            else if (Itens2 >= 1 && Itens2 <= 5 && Poção_Estranha_2 > 0)
                            {
                                Vida_Player_2 = 100;
                                Mana_Player_2 = 20;
                                Console.WriteLine("Você bebe a poção e começa a se sentir completamente restaurado");
                                Poção_Estranha_2 -= 1;
                                EndGame();
                            }
                            else if (Itens2 >= 6 && Poção_Estranha_2 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e não sente nenhuma mudança");
                                EndGame();
                            }
                            else if (op == "3" && Poção_Estranha_2 == 0)
                            {
                                Console.WriteLine("Você não tem mais nenhuma poção estranha");
                            }
                        }
                    }
                }
                else if (op == "3" && Poções_1 == 0)
                {
                    Console.WriteLine("Você não tem nenhum item");
                    AçõesJogadores();
                }
            }
            if (player == 2)
            {
                if (op == "3" && Poções_2 > 0)
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
                            EndGame();
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
                            EndGame();
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
                                EndGame();
                            }
                            else if (op == "3" && Poção_Estranha_1 == 0)
                            {
                                Console.WriteLine("Você não tem mais nenhuma poção estranha");
                            }
                        }
                    }
                    if (player == 2)
                    {

                        if (op == "1" && Poção_de_Cura_2 > 0)
                        {
                            Vida_Player_2 += 10;
                            Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                            Poção_de_Cura_2 -= 1;
                            EndGame();
                        }
                        else if (op == "1" && Poção_de_Cura_2 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de cura");
                        }

                        else if (op == "2" && Poção_de_Mana_2 > 0)
                        {
                            Mana_Player_2 += 5;
                            Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                            Poção_de_Mana_2 -= 1;
                            EndGame();
                        }
                        else if (op == "2" && Poção_de_Mana_2 == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção de mana");
                        }

                        else if (op == "3")
                        {
                            if (Itens2 == 0 && Poção_Estranha_2 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e começa a se sentir tonto até cai desacordado");
                                Console.WriteLine("");
                                Vida_Player_2 = 0;
                                EndGame();
                            }
                            else if (Itens2 >= 1 && Itens2 <= 5 && Poção_Estranha_2 > 0)
                            {
                                Vida_Player_2 = 100;
                                Mana_Player_2 = 20;
                                Console.WriteLine("Você bebe a poção e começa a se sentir completamente restaurado");
                                Poção_Estranha_2 -= 1;
                                EndGame();
                            }
                            else if (Itens2 >= 6 && Poção_Estranha_2 > 0)
                            {
                                Console.WriteLine("Você bebe a poção e não sente nenhuma mudança");
                                EndGame();
                            }
                            else if (op == "3" && Poção_Estranha_2 == 0)
                            {
                                Console.WriteLine("Você não tem mais nenhuma poção estranha");
                            }
                        }
                    }
                }
                else if (op == "3" && Poções_2 == 0)
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
            else if (Singleplayer == true)
            {
                Boss();
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
    }
}
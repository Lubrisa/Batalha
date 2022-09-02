using System;
using System.Dynamic;

namespace Batalha2
{
    class Program
    {
        // Jogador 1
        static int forca_1;
        static int Vida_Player_1 = 100;
        static int Mana_Player_1 = 10 + (20 - (forca_1 * 2));
        static bool Paralizado_1 = false;
        static int Poção_de_Cura_1 = 5;
        static int Poção_de_Mana_1 = 3;
        static int Poção_Estranha_1 = 1;
        static int Poções_1 = Poção_Estranha_1 + Poção_de_Mana_1 + Poção_de_Cura_1;

        // Jogador 2
        static int forca_2;
        static int Vida_Player_2 = 100;
        static int Mana_Player_2 = 10 + (20 - (forca_1*2));
        static bool Paralizado_2 = false;
        static int Poção_de_Cura_2 = 5;
        static int Poção_de_Mana_2 = 3;
        static int Poção_Estranha_2 = 1;
        static int Poções_2 = Poção_Estranha_2 + Poção_de_Mana_2 + Poção_de_Cura_2;

        // Simgleplayer
        static bool Simgleplayer = false;

        static int Vida_Boss = 100;
        static int Mana_Boss = 20;

        static void Main()
        {
            Console.WriteLine(@"
▒█▀▀█ █▀▀ █▀▄▀█ 　 ▒█░░▒█ ░▀░ █▀▀▄ █▀▀▄ █▀▀█ 
▒█▀▀▄ █▀▀ █░▀░█ 　 ░▒█▒█░ ▀█▀ █░░█ █░░█ █░░█ 
▒█▄▄█ ▀▀▀ ▀░░░▀ 　 ░░▀▄▀░ ▀▀▀ ▀░░▀ ▀▀▀░ ▀▀▀▀ 
           ");
            Console.WriteLine("Você está prestes a entrar na batalha, para selecionar uma ação, escreva o número da opção\nSe você entendeu, pressione Enter");
            Console.ReadLine();
            Console.Clear();
            EscolherOsStatus();
            batalha();
        }
        static void EscolherOsStatus()
        {
            Console.WriteLine(@"

░█▀▀░█▀▀░█▀▀░█▀█░█░░░█░█░█▀█░░░█▀█░█▀▀░░░█▀█░█▀█░█▀▀░█▀█░█▀▀░█▀▀
░█▀▀░▀▀█░█░░░█░█░█░░░█▀█░█▀█░░░█▀█░▀▀█░░░█░█░█▀▀░█░░░█░█░█▀▀░▀▀█
░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀░▀░░░▀░▀░▀▀▀░░░▀▀▀░▀░░░▀▀▀░▀▀▀░▀▀▀░▀▀▀
           ");
            //opções
            Console.WriteLine("1. Sigleplayer");
            Console.WriteLine("2. Multiplayer");

            string Op_0 = Console.ReadLine();
            Console.WriteLine("");
            if (Op_0 == "1")
            {
                Simgleplayer = true;
            }
            if (Op_0 == "2")
            {
                Simgleplayer = false;
            }
            Console.WriteLine("Aperte ENTER para continuar");
            Console.ReadLine();

            if (Simgleplayer==true)
            {
                Console.WriteLine("Jogador 1: escolha sua força");
                Console.Write("Força (1 - 10): ");
                forca_1 = int.Parse(Console.ReadLine());
                //Travas
                if (forca_1<=0)
                {
                    forca_1 = 1;
                }
                if (forca_1 >= 10)
                {
                    forca_1 = 10;
                }
                Console.WriteLine("Sua força é: " + forca_1);
                Console.WriteLine("Sua mana é: " + Mana_Player_1);

                Console.WriteLine("Aperte ENTER para começar luta");
                Console.ReadLine();
            }

            if (Simgleplayer ==false)
            {
                Console.WriteLine("Jogador 1: escolha sua força");
                Console.Write("Força (1 - 10): ");
                forca_1 = int.Parse(Console.ReadLine());
                //Travas
                if (forca_1 <= 0)
                {
                    forca_1 = 1;
                }
                if (forca_1 >= 10)
                {
                    forca_1 = 10;
                }
                Console.WriteLine("Sua força é: " + forca_1);
                Console.WriteLine("Sua mana é: " + Mana_Player_1);

                Console.WriteLine("Aperte ENTER para continuar");
                Console.ReadLine();

                Console.WriteLine("Jogador 2: escolha sua força");
                Console.Write("Força (1 - 10): ");
                forca_2 = int.Parse(Console.ReadLine());
                //Travas
                if (forca_2 <= 0)
                {
                    forca_2 = 1;
                }
                if (forca_2 >= 10)
                {
                    forca_2 = 10;
                }

                Console.WriteLine("Sua força é: " + forca_2);
                Console.WriteLine("Sua mana é: " + Mana_Player_2);
                Console.WriteLine("Aperte ENTER para começar luta");
                Console.ReadLine();
            }
        }
        static void batalha()
        {
            while (Vida_Player_1 > 0 && Vida_Player_2 > 0)
            {
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.Write("Vida do Player 1: " + Vida_Player_1 + "         Mana do Player 1: " + Mana_Player_1 + "\n");

                Console.Write("Vida do Player 2: " + Vida_Player_2 + "        Mana do Player 2: " + Mana_Player_2 + "\n");

                Console.WriteLine("Jogador 1 escolha seu movimento?");
                Console.WriteLine("");
                //opções
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Magia");
                Console.WriteLine("3. Itens");
                Console.WriteLine("");

                AçõesJogador1();

                Hud();
            }
        }
        static void Hud()
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.Write("Vida do Player 1: " + Vida_Player_1 + "         Mana do Player 1: " + Mana_Player_1 + "\n");

            Console.Write("Vida do Player 2: " + Vida_Player_2 + "        Mana do Player 2: " + Mana_Player_2 + "\n");

            Console.WriteLine("Jogador 2 escolha seu movimento?");
            Console.WriteLine("");
            //opções
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Magia");
            Console.WriteLine("3. Itens");
            Console.WriteLine("");

            AçõesJogador2();
            Console.WriteLine("\nPressione ENTER para ir para a próxima rodada");
            Console.ReadLine();
            Console.Clear();
        }

        static void AçõesJogador1()
        {
            string op_1 = Console.ReadLine();
            Console.WriteLine("");

            //Opções de ataque
            if (Paralizado_1 == true)
            {
                Console.WriteLine("Você não consegue se mover!");
                Paralizado_1 = false;
                EndGame();
            }
            else if (op_1 == "1")
            {
                Random rPlayer = new Random();
                int Ataque = rPlayer.Next(6);

                if (Ataque <= 2 && Paralizado_1 == false)
                {
                    Vida_Player_2 -= 10 + forca_1;
                    Console.WriteLine("Você acerta! O inimigo perde 10 de vida");
                    EndGame();
                }
                else if (Ataque >= 3 || Ataque <= 4 && Paralizado_1 == false)
                {
                    Console.WriteLine("Você errou!");
                    EndGame();
                }
                else if (Ataque == 5 && Paralizado_1 == false)
                {
                    Vida_Player_2 -= 20 + forca_1;
                    Console.WriteLine("Você acerta em cheio! O inimigo perde 20 de vida");
                    EndGame();
                }
            }

            //Opcões de Magias
            else if (op_1 == "2" && Mana_Player_1 >= 5)
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

                string Opções_Magias = Console.ReadLine();
                Console.WriteLine("");
                string op2 = Opções_Magias;

                if (op2 == "4")
                {
                    batalha();
                }
                else if (op2 == "1")
                {
                    if (Mana_Player_1 < 10)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                        AçõesJogador1();
                    }
                    else if (Magias == 0 && Mana_Player_1 >= 10)
                    {
                        Vida_Player_2 -= 10;
                        Mana_Player_1 -= 10;
                        Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                        EndGame();
                    }
                    else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 10)
                    {
                        Vida_Player_2 -= 25;
                        Mana_Player_1 -= 10;
                        Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                        EndGame();
                    }
                    else if (Magias == 5 && Mana_Player_1 >= 10)
                    {
                        Vida_Player_2 -= 50;
                        Mana_Player_1 -= 10;
                        Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                        EndGame();
                    }
                }
                else if (op2 == "2")
                {
                    if (Mana_Player_1 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                        AçõesJogador1();
                    }
                    else if (Magias == 0 && Mana_Player_1 >= 5)
                    {
                        Mana_Player_1 -= 5;
                        Console.WriteLine("Você lança um raio e erra");
                        EndGame();
                    }
                    else if (Magias >= 1 && Magias <= 4 && Mana_Player_1 >= 5)
                    {
                        Vida_Player_2 -= 20;
                        Mana_Player_1 -= 5;
                        Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                        EndGame();
                    }
                    else if (Magias == 5 && Mana_Player_1 >= 5)
                    {
                        Vida_Player_2 -= 40;
                        Mana_Player_1 -= 5;
                        Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                        EndGame();
                    }
                }
                else if (op2 == "3")
                {
                    if (Mana_Player_1 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                        AçõesJogador1();
                    }
                    else if (Mana_Player_1 >= 5)
                    {
                        Vida_Player_1 += 20;
                        Mana_Player_1 -= 5;
                        Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                        EndGame();
                    }
                }
            }
            else if (op_1 == "2" && Mana_Player_1 < 5)
            {
                Console.WriteLine("Você não tem mana suficiênte, escolha outra opção.");
                AçõesJogador1();

            }

            //Opções de poções
            else if (op_1 == "3" && Poções_1 > 0)
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

                string Opções_Itens = Console.ReadLine();
                Console.WriteLine("");
                string op3 = Opções_Itens;

                if (op3 == "4")
                {
                    batalha();
                }
                if (op3 == "1" && Poção_de_Cura_1 > 0)
                {
                    Vida_Player_1 += 10;
                    Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                    Poção_de_Cura_1 -= 1;
                    EndGame();
                }
                else if (op3 == "1" && Poção_de_Cura_1 == 0)
                {
                    Console.WriteLine("Você não tem mais nenhuma poção de cura");
                }

                else if (op3 == "2" && Poção_de_Mana_1 > 0)
                {
                    Mana_Player_1 += 5;
                    Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                    Poção_de_Mana_1 -= 1;
                    EndGame();
                }
                else if (op3 == "2" && Poção_de_Mana_1 == 0)
                {
                    Console.WriteLine("Você não tem mais nenhuma poção de mana");
                }

                else if (op3 == "3")
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
                    else if (op3 == "3" && Poção_Estranha_1 == 0)
                    {
                        Console.WriteLine("Você não tem mais nenhuma poção estranha");
                    }
                }
            }
            else if (op_1 == "3" && Poções_1 == 0)
            {
                Console.WriteLine("Você não tem nenhum item");
            }
        }

        static void AçõesJogador2()
        {
            string op_2 = Console.ReadLine();
            Console.WriteLine("");

            //Opções de ataque
            if (Paralizado_2 == true)
            {
                Console.WriteLine("Você não consegue se mover!");
                Paralizado_2 = false;
                EndGame();
            }
            else if (op_2 == "1")
            {
                Random rPlayer = new Random();
                int Ataque = rPlayer.Next(6);

                if (Ataque <= 2 && Paralizado_2 == false)
                {
                    Vida_Player_1 -= 10 + forca_2;
                    Console.WriteLine("Você acerta! O inimigo perde 10 de vida");
                    EndGame();
                }
                else if (Ataque >= 3 || Ataque <= 4 && Paralizado_2 == false)
                {
                    Console.WriteLine("Você errou!");
                    EndGame();
                }
                else if (Ataque == 5 && Paralizado_2 == false)
                {
                    Vida_Player_1 -= 20 + forca_2;
                    Console.WriteLine("Você acerta em cheio! O inimigo perde 20 de vida");
                    EndGame();
                }
            }

            //Opcões de Magias
            else if (op_2 == "2" && Mana_Player_2 >= 5)
            {
                //opções
                Random rPlayer2 = new Random();
                int Magias = rPlayer2.Next(6);

                Console.WriteLine("1. Bola de Fogo");
                Console.WriteLine("Um porjétil incandescente que explode no impacto. Custa 10 de mana.");
                Console.WriteLine("");
                Console.WriteLine("2. Relâmpago");
                Console.WriteLine("Um raio concentrado que sai da ponta dos seus dedos na direção em que você estiver apontando. Custa 5 de mana");
                Console.WriteLine("");
                Console.WriteLine("3. Curar Ferimentos");
                Console.WriteLine("Um poder que restaura sua energia vital ao absorver a energia da própria terra. custa 5 de mana e recupera 20 de vida");
                Console.WriteLine("");
                Console.WriteLine("4. Voltar");
                Console.WriteLine("");

                string Opções_Magias = Console.ReadLine();
                Console.WriteLine("");
                string op2 = Opções_Magias;

                if (op2 == "4")
                {
                    batalha();
                }
                else if (op2 == "1")
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
                        EndGame();
                    }
                    else if (Magias >= 1 && Magias <= 4 && Mana_Player_2 >= 10)
                    {
                        Vida_Player_1 -= 25;
                        Mana_Player_2 -= 10;
                        Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                        EndGame();
                    }
                    else if (Magias == 5 && Mana_Player_2 >= 10)
                    {
                        Vida_Player_1 -= 50;
                        Mana_Player_2 -= 10;
                        Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                        EndGame();
                    }
                }
                else if (op2 == "2")
                {
                    if (Mana_Player_2 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                        AçõesJogador2();
                    }
                    else if (Magias == 0 && Mana_Player_2 >= 5)
                    {
                        Mana_Player_2 -= 5;
                        Console.WriteLine("Você lança um raio e erra");
                        EndGame();
                    }
                    else if (Magias >= 1 && Magias <= 4 && Mana_Player_2 >= 5)
                    {
                        Vida_Player_1 -= 20;
                        Mana_Player_2 -= 5;
                        Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                        EndGame();
                    }
                    else if (Magias == 5 && Mana_Player_2 >= 5)
                    {
                        Vida_Player_1 -= 40;
                        Mana_Player_2 -= 5;
                        Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                        EndGame();
                    }
                }
                else if (op2 == "3")
                {
                    if (Mana_Player_2 < 5)
                    {
                        Console.WriteLine("Você não consegue lançar essa magia");
                        AçõesJogador2();
                    }
                    else if (Mana_Player_2 >= 5)
                    {
                        Vida_Player_2 += 20;
                        Mana_Player_2 -= 5;
                        Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                        EndGame();
                    }
                }
            }
            else if (op_2 == "2" && Mana_Player_2 < 5)
            {
                Console.WriteLine("Você não tem mana suficiênte, escolha outra opção.");
                AçõesJogador2();
            }

            //Opções de poções
            else if (op_2 == "3" && Poções_2 > 0)
            {
                Random rPlayer = new Random();
                int Itens2 = rPlayer.Next(20);

                //opções
                Console.WriteLine("1. Poção de Cura");
                Console.WriteLine("Recupera 10 de vida");
                Console.WriteLine("Quantidade: " + Poção_de_Cura_2);
                Console.WriteLine("");
                Console.WriteLine("2. Poção de Mana");
                Console.WriteLine("Recupera 5 de mana");
                Console.WriteLine("Quantidade: " + Poção_de_Mana_2);
                Console.WriteLine("");
                Console.WriteLine("3. Poção Estranha");
                Console.WriteLine("????????");
                Console.WriteLine("Quantidade: " + Poção_Estranha_2);
                Console.WriteLine("");
                Console.WriteLine("4. Voltar");
                Console.WriteLine("");

                string Opções_Itens = Console.ReadLine();
                Console.WriteLine("");
                string op3 = Opções_Itens;

                if (op3 == "4")
                {
                    batalha();
                }
                if (op3 == "1" && Poção_de_Cura_2 > 0)
                {
                    Vida_Player_2 += 10;
                    Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                    Poção_de_Cura_2 -= 1;
                    EndGame();
                }
                else if (op3 == "1" && Poção_de_Cura_2 == 0)
                {
                    Console.WriteLine("Você não tem mais nenhuma poção de cura");
                }

                else if (op3 == "2" && Poção_de_Mana_2 > 0)
                {
                    Mana_Player_2 += 5;
                    Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                    Poção_de_Mana_2 -= 1;
                    EndGame();
                }
                else if (op3 == "2" && Poção_de_Mana_2 == 0)
                {
                    Console.WriteLine("Você não tem mais nenhuma poção de mana");
                }

                else if (op3 == "3")
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
                        Poção_Estranha_1 -= 1;
                        EndGame();
                    }
                    else if (Itens2 >= 6 && Poção_Estranha_2 > 0)
                    {
                        Console.WriteLine("Você bebe a poção e não sente nenhuma mudança");
                        EndGame();
                    }
                    else if (op3 == "3" && Poção_Estranha_2 == 0)
                    {
                        Console.WriteLine("Você não tem mais nenhuma poção estranha");
                    }
                }
            }
            else if (op_2 == "3" && Poções_2 == 0)
            {
                Console.WriteLine("Você não tem nenhum item");
            }
        }

        //Boss


        static void EndGame()
        {
            if (Simgleplayer == true)
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

            if (Vida_Player_2 > 0 && Vida_Player_1 <= 0)
            {
                Console.WriteLine(@"
░▀▀█░█▀█░█▀▀░█▀█░█▀▄░█▀█░█▀▄░░░▀█░░░░█▀▀░█▀█░█▀█░█░█░█▀█
░░░█░█░█░█░█░█▀█░█░█░█░█░█▀▄░░░░█░░░░█░█░█▀█░█░█░█▀█░█▀█
░▀▀░░▀▀▀░▀▀▀░▀░▀░▀▀░░▀▀▀░▀░▀░░░▀▀▀░░░▀▀▀░▀░▀░▀░▀░▀░▀░▀░▀
");
            }

            if (Vida_Player_2 <= 0 && Vida_Player_1 <= 0)
            {
                Console.WriteLine(@"
▒█▀▀▀ █▀▄▀█ █▀▀█ █▀▀█ ▀▀█▀▀ █▀▀ 
▒█▀▀▀ █░▀░█ █░░█ █▄▄█ ░░█░░ █▀▀ 
▒█▄▄▄ ▀░░░▀ █▀▀▀ ▀░░▀ ░░▀░░ ▀▀▀ 
");
            }

            if (Vida_Player_2 <= 0 && Vida_Player_1 > 0)
            {
                Console.WriteLine(@"
░▀▀█░█▀█░█▀▀░█▀█░█▀▄░█▀█░█▀▄░░░▀▀▄░░░█▀▀░█▀█░█▀█░█░█░█▀█
░░░█░█░█░█░█░█▀█░█░█░█░█░█▀▄░░░▄▀░░░░█░█░█▀█░█░█░█▀█░█▀█
░▀▀░░▀▀▀░▀▀▀░▀░▀░▀▀░░▀▀▀░▀░▀░░░▀▀▀░░░▀▀▀░▀░▀░▀░▀░▀░▀░▀░▀
");
            }

        }

    }
}
using System;
using System.Dynamic;

namespace Batalha2
{
    class Program
    {
        static int Vida_Boss = 100;
        static int Mana_Boss = 20;
        static int Vida_Player = 100;
        static int Mana_Player = 20;
        static bool Paralizado = false;
        static int Poção_de_Cura = 5;
        static int Poção_de_Mana = 3;
        static int Poção_Estranha = 1;
        static int Poções = Poção_Estranha + Poção_de_Mana + Poção_de_Cura;

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
            batalha();
        }
        static void batalha()
        {
            while (Vida_Boss > 0 && Vida_Player > 0)
            {
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.Write("Sua vida: " + Vida_Player + "         Sua mana: " + Mana_Player + "\n");
                Console.Write("Vida boss: " + Vida_Boss + "        Mana boss: " + Mana_Boss + "\n");
                Console.WriteLine("O que você faz?");
                Console.WriteLine("");
                //opções
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Magia");
                Console.WriteLine("3. Itens");
                Console.WriteLine("");

                string Opções = Console.ReadLine();
                Console.WriteLine("");
                string op = Opções;

                //opções

                if (Paralizado == true)
                {
                    Console.WriteLine("Você não consegue se mover!");
                    Paralizado = false;
                    Boss();
                }
                else if (op == "1")
                {
                    Random rPlayer = new Random();
                    int Ataque = rPlayer.Next(6);

                    if (Ataque <= 2 && Paralizado == false)
                    {
                        Vida_Boss -= 10;
                        Console.WriteLine("Você acerta! O inimigo perde 10 de vida");
                        Boss();
                    }
                    else if (Ataque >= 3 || Ataque <= 4 && Paralizado == false)
                    {
                        Console.WriteLine("Você errou!");
                        Boss();
                    }
                    else if (Ataque == 5 && Paralizado == false)
                    {
                        Vida_Boss -= 20;
                        Console.WriteLine("Você acerta em cheio! O inimigo perde 20 de vida");
                        Boss();
                    }
                }

                else if (op == "2" && Mana_Player >= 5)
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
                        if (Mana_Player < 10)
                        {
                            Console.WriteLine("Você não consegue lançar essa magia");
                        }
                        else if (Magias == 0 && Mana_Player >= 10)
                        {
                            Vida_Boss -= 10;
                            Mana_Player -= 10;
                            Console.WriteLine("Você erra, mas a explosão ainda acerta seu inimigo. O inimigo perde 10 de vida");
                            Boss();
                        }
                        else if (Magias >= 1 && Magias <= 4 && Mana_Player >= 10)
                        {
                            Vida_Boss -= 25;
                            Mana_Player -= 10;
                            Console.WriteLine("Você acerta sua Bola de Fogo. O inimigo perde 25 de vida");
                            Boss();
                        }
                        else if (Magias == 5 && Mana_Player >= 10)
                        {
                            Vida_Boss -= 50;
                            Mana_Player -= 10;
                            Console.WriteLine("Sua Bola de Fogo acerta seu inimigo em cheio! O inimigo perde 50 de vida");
                            Boss();
                        }
                    }
                    else if (op2 == "2")
                    {
                        if (Mana_Player < 5)
                        {
                            Console.WriteLine("Você não consegue lançar essa magia");
                        }
                        else if (Magias == 0 && Mana_Player >= 5)
                        {
                            Mana_Player -= 5;
                            Console.WriteLine("Você lança um raio e erra");
                            Boss();
                        }
                        else if (Magias >= 1 && Magias <= 4 && Mana_Player >= 5)
                        {
                            Vida_Boss -= 20;
                            Mana_Player -= 5;
                            Console.WriteLine("Você acerta seu raio no inimigo. O inimigo perde 20 de vida");
                            Boss();
                        }
                        else if (Magias == 5 && Mana_Player >= 5)
                        {
                            Vida_Boss -= 40;
                            Mana_Player -= 5;
                            Console.WriteLine("Você acerta um raio em cheio no peito do inimigo. O inimigo perde 40 de vida");
                            Boss();
                        }
                    }
                    else if (op2 == "3")
                    {
                        if (Mana_Player < 5)
                        {
                            Console.WriteLine("Você não consegue lançar essa magia");
                        }
                        else if (Mana_Player >= 5)
                        {
                            Vida_Player += 20;
                            Mana_Player -= 5;
                            Console.WriteLine("Você encosta no seu peito e sua mão brilha em uma luz amarela. Você se sente revigorado");
                            Boss();
                        }
                    }
                }

                else if (op == "2" && Mana_Player < 5)
                {
                    Console.WriteLine("Você não tem mana suficiênte");
                }

                else if (op == "3" && Poções > 0)
                {
                    Random rPlayer = new Random();
                    int Itens2 = rPlayer.Next(20);

                    //opções
                    Console.WriteLine("1. Poção de Cura");
                    Console.WriteLine("Recupera 10 de vida");
                    Console.WriteLine("Quantidade: " + Poção_de_Cura);
                    Console.WriteLine("");
                    Console.WriteLine("2. Poção de Mana");
                    Console.WriteLine("Recupera 5 de mana");
                    Console.WriteLine("Quantidade: " + Poção_de_Mana);
                    Console.WriteLine("");
                    Console.WriteLine("3. Poção Estranha");
                    Console.WriteLine("????????");
                    Console.WriteLine("Quantidade: " + Poção_Estranha);
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
                    if (op3 == "1" && Poção_de_Cura > 0)
                    {
                        Vida_Player += 10;
                        Console.WriteLine("Você bebe um líquido vermelho de um frasco e se sente revigorado");
                        Poção_de_Cura -= 1;
                        Boss();
                    }
                    else if (op3 == "1" && Poção_de_Cura == 0)
                    {
                        Console.WriteLine("Você não tem mais nenhuma poção de cura");
                    }

                    else if (op3 == "2" && Poção_de_Mana > 0)
                    {
                        Mana_Player += 5;
                        Console.WriteLine("Você bebe um líquido azul de um frasco e se sente energizado");
                        Poção_de_Mana -= 1;
                        Boss();
                    }
                    else if (op3 == "2" && Poção_de_Mana == 0)
                    {
                        Console.WriteLine("Você não tem mais nenhuma poção de mana");
                    }

                    else if (op3 == "3")
                    {
                        if (Itens2 == 0 && Poção_Estranha > 0)
                        {
                            Console.WriteLine("Você bebe a poção e começa a se sentir tonto até cai desacordado");
                            Console.WriteLine("");
                            Vida_Player = 0;
                            Boss();
                        }
                        else if (Itens2 >= 1 && Itens2 <= 5 && Poção_Estranha > 0)
                        {
                            Vida_Player = 100;
                            Mana_Player = 20;
                            Console.WriteLine("Você bebe a poção e começa a se sentir completamente restaurado");
                            Poção_Estranha -= 1;
                            Boss();
                        }
                        else if (Itens2 >= 6 && Poção_Estranha > 0)
                        {
                            Console.WriteLine("Você bebe a poção e não sente nenhuma mudança");
                            Boss();
                        }
                        else if (op3 == "3" && Poção_Estranha == 0)
                        {
                            Console.WriteLine("Você não tem mais nenhuma poção estranha");
                        }
                    }
                }
                else if (op == "3" && Poções == 0)
                {
                    Console.WriteLine("Você não tem nenhum item");
                }
            }
        }
        //Boss
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
                Paralizado = true;
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
                Vida_Player -= 20;
                Mana_Boss -= 10;
                Console.WriteLine("Seu inimigo canaliza uma torrente de energia negativa na sua direção. Você perde 20 de vida");
            }
            else if (Boss >= 11 && Boss <= 14)
            {
                Console.WriteLine("Seu inimigo tenta te acertar com um ataque, mas erra.");
            }
            else if (Boss >= 15 && Boss <= 18)
            {
                Vida_Player -= 15;
                Console.WriteLine("Seu inimigo te acerta com um ataque. Você perde 15 de vida.");
            }
            else
            {
                Vida_Player -= 30;
                Console.WriteLine("Seu inimigo te acerta em cheio. Você perde 30 de vida.");
            }
            Console.WriteLine("\nPressione Enter para continuar");
            Console.ReadLine();
            Console.Clear();
            if (Vida_Boss > 0 && Vida_Player <= 0)
            {
                Console.WriteLine(@"
▒█░░▒█ █▀▀█ █▀▀ █▀▀ 　 ▒█▀▄▀█ █▀▀█ █▀▀█ █▀▀█ █▀▀ █░░█ 
░▒█▒█░ █░░█ █░░ █▀▀ 　 ▒█▒█▒█ █░░█ █▄▄▀ █▄▄▀ █▀▀ █░░█ 
░░▀▄▀░ ▀▀▀▀ ▀▀▀ ▀▀▀ 　 ▒█░░▒█ ▀▀▀▀ ▀░▀▀ ▀░▀▀ ▀▀▀ ░▀▀▀ 
");
            }

            if (Vida_Boss <= 0 && Vida_Player <= 0)
            {
                Console.WriteLine(@"
▒█▀▀▀ █▀▄▀█ █▀▀█ █▀▀█ ▀▀█▀▀ █▀▀ 
▒█▀▀▀ █░▀░█ █░░█ █▄▄█ ░░█░░ █▀▀ 
▒█▄▄▄ ▀░░░▀ █▀▀▀ ▀░░▀ ░░▀░░ ▀▀▀ 
");
            }

            if (Vida_Boss <= 0 && Vida_Player > 0)
            {
                Console.WriteLine(@"
▒█░░▒█ █▀▀█ █▀▀ █▀▀ 　 ▒█░░▒█ █▀▀ █▀▀▄ █▀▀ █▀▀ █░░█ █ █ █ 
░▒█▒█░ █░░█ █░░ █▀▀ 　 ░▒█▒█░ █▀▀ █░░█ █░░ █▀▀ █░░█ ▀ ▀ ▀ 
░░▀▄▀░ ▀▀▀▀ ▀▀▀ ▀▀▀ 　 ░░▀▄▀░ ▀▀▀ ▀░░▀ ▀▀▀ ▀▀▀ ░▀▀▀ ▄ ▄ ▄ 
");
            }
        }
    }
}

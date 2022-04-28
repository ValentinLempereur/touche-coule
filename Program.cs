using System;

namespace toucher_couler
{
    class Program
    {
        static void Main(string[] args)
        {
            string restart = "";
            do
            {
                //------------initialisation--------------
                string[,] plan_jeu_ordi; //pour l'ordi
                string[,] plan_jeu_uti; // pour l'utilisateur -> mettre bateau toucher, etc...
                string[,] bat_ordi;
                string[,] bat_uti;
                bool victory = false;
                string message = "";
                string message2 = "";
                string Nombre;
                bool Nexty;
                //----------------------------------------

                //-------------création des jeu----------------
                creationMatriceJeu(out plan_jeu_ordi);
                creationMatriceJeu(out plan_jeu_uti);
                creationMatriceJeu(out bat_ordi);
                creationMatriceJeu(out bat_uti);
                //----------------------------------------
                Console.ForegroundColor = ConsoleColor.Green;
                asciiii();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nAppuyer sur ENTER pour commencer");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Entrez votre nom : \n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                string nom = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine($"Bonjour {nom}, vous allez commencer une partie de touché-coulé !!\n");
                Console.WriteLine("Vous allez encoder vos emplacements de bateau, appuie sur ENTER pour passer a la suite\n");
                Console.ReadLine();
                placementBateauUti(bat_uti, plan_jeu_ordi);
                Console.Clear();
                Console.WriteLine("Plusieurs navire ennemi on été détecté !!, êtes-vous prêt à les détruire");
                Console.ReadLine();
                placementBateauordi(bat_ordi, plan_jeu_ordi);


                do
                {
                    do
                    {
                        Console.Clear();
                        Nexty = false;
                        Console.WriteLine("Voulez-vous attaquer ou voire l'avancement de la bataille de votre coté ? (séléctionner un chiffre)\n");
                        Console.WriteLine("1. Attaquer \n2. Voire un aperçu\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Nombre = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        if (Nombre == "1" || Nombre == "2") 
                        {
                            Nexty = true;
                        }
                    } while (!Nexty);

                    Console.Clear();
                    if (Nombre == "2")
                    {
                        Console.WriteLine("Voici l'avancemnt du jeu\n");
                        Affiche(plan_jeu_ordi);
                        Console.WriteLine("\nAppuyer sur ENTER passer à l'attaque");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    tirUti(bat_ordi, plan_jeu_uti);
                    tirOrdi(bat_uti, plan_jeu_ordi);
                    win(plan_jeu_uti, plan_jeu_ordi, out message, out victory, out message2);
                    Console.Clear();
                } while (!victory);

                Console.WriteLine(message2);
                Console.WriteLine("appuyer sur ENTER pour lancer l'analyse");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("analyse en cours...\n");
                Console.WriteLine("analyse en cours 20%\n");
                Console.WriteLine("analyse en cours 46%\n");
                Console.WriteLine("analyse en cours 67%\n");
                Console.WriteLine("analyse en cours 85%\n");
                Console.WriteLine("analyse en cours 99%\n");
                Console.WriteLine("analyse en cours 100%\n");
                Console.WriteLine("analyse términé Y/N \n");
                Console.WriteLine("APPUYER SUR ENTER POUR AFFICHER LES RESULTAT DE L'ANALYSE");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine(message);
                Console.WriteLine("Passer à la suite -> ENTER");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Voulez-vous recommencer ? oui - non");
                restart = Console.ReadLine();
                Console.Clear();
            } while (restart == "oui");




        }


        //------------------------------------création de la matrice------------------------------------
        static void creationMatriceJeu(out string[,] plan_jeu)
        {
            plan_jeu = new string[11, 11]
            {
                { ".", " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", " 10" },
                { "A", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "B", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "C", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "D", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "E", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "F", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "G", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "H", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "I", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" },
                { "J", " O", " O", " O", " O", " O", " O", " O", " O", " O", " O" }
            };
        }
        //------------------------------------------------------------------------------------------------

        //--------------------afficher la matrix entière---------------------
        static void Affiche(string[,] plan_jeu)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(plan_jeu[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        //-------------------------------------------------------------------

        //-----------------------------------quelle lettre vaut quoi ?-----------------------------------
        static void caseselect(out int Ligne, out int NbrColonne)
        {
            string[] t = { "²", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            Ligne = 0;
            string ChoixLigne = "";
            bool ok;
            do
            {
                ok = false;
                Console.WriteLine("\nchoisisez la lettre que vous voulez séléctionner");
                Console.ForegroundColor = ConsoleColor.Magenta;
                ChoixLigne = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.Cyan;

                if (ChoixLigne == "A" || ChoixLigne == "B" || ChoixLigne == "C" || ChoixLigne == "D" || ChoixLigne == "E" || ChoixLigne == "F" || ChoixLigne == "G" || ChoixLigne == "H" || ChoixLigne == "I" || ChoixLigne == "J")
                {
                    ok = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nVous pouvez seulement encoder une lettre qui est présent sur la table du jeu et seulement une lettre !!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (!ok);



            for (int i = 0; i < t.Length; i++)
            {
                if (ChoixLigne == t[i])
                {
                    Ligne = i;
                }
            }


            do
            {
                ok = false;
                Console.WriteLine("\nchoisisez le chiffre que vous voulez séléctionner");
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (int.TryParse(Console.ReadLine(), out NbrColonne))
                {

                }
                Console.ForegroundColor = ConsoleColor.Cyan;

                if (NbrColonne == 1 || NbrColonne == 2 || NbrColonne == 3 || NbrColonne == 4 || NbrColonne == 5 || NbrColonne == 6 || NbrColonne == 7 || NbrColonne == 8 || NbrColonne == 9 || NbrColonne == 10)
                {
                    ok = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nVous pouvez seulement encoder un chiffre qui est présent sur la table du jeu et seulement un chiffre !!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            } while (!ok);
            

        }
        //-----------------------------------------------------------------------------------------------

        //-------------------------placement bateau utilisateur-------------------------
        static void placementBateauUti(string[,] bat_uti, string[,] plan_jeu_ordi)
        {
            string[] t = { "Porte-Avion (5 cases)", "Croisseur (4 cases)", "1 Sous-Marin (3 cases)", "2 Sous-Marin (3 cases)", "torpilleur (2 cases)"};
            int[] t2 = { 5, 4, 3, 3, 2 };
            int Ligne;
            int NbrColonne;
            bool bas;
            bool haut;
            bool droite;
            bool gauche;
            string user = "uti";
            bool ok;


            for (int i = 0; i < t.Length; i++)
            {
                string bateau = t[i];
                int nbrCase = t2[i];
                Console.Clear();
                Console.WriteLine($"Placer votre {bateau}\n");
                Affiche(bat_uti);
                caseselect(out Ligne, out NbrColonne);
                if (bat_uti[Ligne, NbrColonne] == " B")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vous avez déjà un navire présent sur cette case");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    i = i -  1;
                }
                else
                {
                    direction(Ligne, NbrColonne, out bas, out haut, out gauche, out droite, nbrCase, bat_uti);
                    encodageordi(bas, haut, gauche, droite, nbrCase, Ligne, NbrColonne, bat_uti, out ok, user, plan_jeu_ordi);
                }
            }
        }
        //-------------------------------------------------------------------------------


        //-------------------------placement bateau ordi--------------------------------------------------------------------------------------------
        static void placementBateauordi(string[,] bat_ordi, string[,] plan_jeu_ordi)
        {
            {
                Random Rligne = new Random();
                Random Rcolonne = new Random();
                bool bas;
                bool haut;
                bool droite;
                bool gauche;
                int nbrCase = 5;
                bool ok = false;
                string user = "";



                do
                {

                    int Ligne = Rligne.Next(1, 11);
                    int NbrColonne = Rcolonne.Next(1, 11);

                    if (bat_ordi[Ligne, NbrColonne] == " O")
                    {
                        direction(Ligne, NbrColonne, out bas, out haut, out gauche, out droite, nbrCase, bat_ordi);
                        encodageordi(bas, haut, gauche, droite, nbrCase, Ligne, NbrColonne, bat_ordi, out ok, user, plan_jeu_ordi);
                    }

                } while (!ok);

                do
                {
                    ok = false;
                    nbrCase = 4;
                    int Ligne = Rligne.Next(1, 11);
                    int NbrColonne = Rcolonne.Next(1, 11);

                    if (bat_ordi[Ligne, NbrColonne] == " O")
                    {
                        direction(Ligne, NbrColonne, out bas, out haut, out gauche, out droite, nbrCase, bat_ordi);
                        encodageordi(bas, haut, gauche, droite, nbrCase, Ligne, NbrColonne, bat_ordi, out ok, user, plan_jeu_ordi);
                    }

                } while (!ok);

                for (int i = 0; i < 2; i++)
                {
                    do
                    {
                        ok = false;
                        nbrCase = 3;
                        int Ligne = Rligne.Next(1, 11);
                        int NbrColonne = Rcolonne.Next(1, 11);

                        if (bat_ordi[Ligne, NbrColonne] == " O")
                        {
                            direction(Ligne, NbrColonne, out bas, out haut, out gauche, out droite, nbrCase, bat_ordi);
                            encodageordi(bas, haut, gauche, droite, nbrCase, Ligne, NbrColonne, bat_ordi, out ok, user, plan_jeu_ordi);
                        }
                    } while (!ok);
                }


                do
                {
                    ok = false;
                    nbrCase = 2;
                    int Ligne = Rligne.Next(1, 11);
                    int NbrColonne = Rcolonne.Next(1, 11);

                    if (bat_ordi[Ligne, NbrColonne] == " O")
                    {
                        direction(Ligne, NbrColonne, out bas, out haut, out gauche, out droite, nbrCase, bat_ordi);
                        encodageordi(bas, haut, gauche, droite, nbrCase, Ligne, NbrColonne, bat_ordi, out ok, user, plan_jeu_ordi);
                    }

                } while (!ok);


            }
        }

        static void direction(int Ligne, int NbrColonne, out bool bas, out bool haut, out bool gauche, out bool droite, int nbrCase, string[,] bat_ordi)
        {
            bas = true;
            haut = true;
            droite = true;
            gauche = true;



            for (int i = 0; i < nbrCase; i++)
            {

                if (!checkLimit(bat_ordi, Ligne + i, NbrColonne) || bat_ordi[Ligne + i, NbrColonne] == " B")
                {
                    bas = false;
                }

            }

            for (int i = 0; i < nbrCase; i++)
            {
                if (!checkLimit(bat_ordi, Ligne - i, NbrColonne) || bat_ordi[Ligne - i, NbrColonne] == " B")
                {
                    haut = false;
                }

            }

            for (int i = 0; i < nbrCase; i++)
            {
                if (!checkLimit(bat_ordi, Ligne, NbrColonne + i) || bat_ordi[Ligne, NbrColonne + i] == " B")
                {
                    droite = false;
                }

            }

            for (int i = 0; i < nbrCase; i++)
            {
                if (!checkLimit(bat_ordi, Ligne, NbrColonne - i) || bat_ordi[Ligne, NbrColonne - i] == " B")
                {
                    gauche = false;
                }

            }


        }



        static void encodageordi(bool bas, bool haut, bool gauche, bool droite, int nbrCase, int Ligne, int NbrColonne, string[,] bat_ordi, out bool ok, string user, string[,] plan_jeu_ordi)
        {
            ok = false;
            string[] t = { "BAS", "HAUT", "DROITE", "GAUCHE" };
            Random direct = new Random();
            string direction = "";


            do
            {
                if (user == "uti")
                {
                    Console.Clear();
                    Console.WriteLine("voici les option de placements\n");
                    if (bas)
                    {
                        Console.Write("   BAS   ");
                    }
                    if (haut)
                    {
                        Console.Write("   HAUT   ");
                    }
                    if (droite)
                    {
                        Console.Write("   DROITE   ");
                    }
                    if (gauche)
                    {
                        Console.Write("   GAUCHE   ");
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    direction = Console.ReadLine().ToUpper();
                    Console.ForegroundColor = ConsoleColor.Cyan;


                }
                else
                {
                    int j = direct.Next(0, 4);
                    direction = t[j];
                }
                

                if (direction == "BAS")
                {
                    if (bas)
                    {
                        for (int i = 0; i < nbrCase; i++)
                        {
                            bat_ordi[Ligne + i, NbrColonne] = " B";
                            if (user == "uti")
                            {
                                plan_jeu_ordi[Ligne + i, NbrColonne] = " B";
                            }
                            ok = true;
                        }
                    }
                }

                if (direction == "HAUT")
                {
                    if (haut)
                    {
                        for (int i = 0; i < nbrCase; i++)
                        {
                            bat_ordi[Ligne - i, NbrColonne] = " B";
                            if (user == "uti")
                            {
                                plan_jeu_ordi[Ligne - i, NbrColonne] = " B";
                            }
                            ok = true;
                        }
                    }
                }


                if (direction == "GAUCHE")
                {
                    if (gauche)
                    {
                        for (int i = 0; i < nbrCase; i++)
                        {
                            bat_ordi[Ligne, NbrColonne - i] = " B";
                            if (user == "uti")
                            {
                                plan_jeu_ordi[Ligne, NbrColonne - i] = " B";
                            }
                            ok = true;
                        }
                    }
                }


                if (direction == "DROITE")
                {
                    if (droite)
                    {
                        for (int i = 0; i < nbrCase; i++)
                        {
                            bat_ordi[Ligne, NbrColonne + i] = " B";
                            if (user == "uti")
                            {
                                plan_jeu_ordi[Ligne, NbrColonne + i] = " B";
                            }
                            ok = true;
                        }
                    }
                }


            } while (!ok);
        }

        static bool checkLimit(string[,] bat_ordi, int Ligne, int Nbrcolonne)
        {
            if (Ligne <= 0 || Ligne > bat_ordi.GetLength(0) - 1)
            {
                return false;
            }
            if (Nbrcolonne <= 0 || Nbrcolonne > bat_ordi.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------tir de l'ordinateur--------------------------------------------------
        static void tirOrdi(string[,] bat_uti, string[,] plan_jeu_ordi)
        {
            Random Rligne = new Random();
            Random Rcolonne = new Random();
            bool ok = false;

            Console.ReadLine();

            do
            {
                int Ligne = Rligne.Next(1, 11);
                int NbrColonne = Rcolonne.Next(1, 11);

                if (bat_uti[Ligne, NbrColonne] == " B")
                {
                    plan_jeu_ordi[Ligne, NbrColonne] = " R";
                    Console.Clear();
                    Console.WriteLine("Un de nos navire a été toucher, il repasse a l'attaque !\n");
                    Console.WriteLine("Activez vos défense en appuyant sur ENTER\n");
                    Console.ReadLine();
                    Console.Clear();
                    ok = false;
                }

                if (bat_uti[Ligne, NbrColonne] == " O")
                {
                    Console.Clear();
                    Console.WriteLine("L'ennemi vous à rater !\n");
                    Console.ReadLine();
                    plan_jeu_ordi[Ligne, NbrColonne] = " X";
                    ok = true;
                    Console.Clear();
                }

                if (bat_uti[Ligne, NbrColonne] == " X")
                {
                    ok = false;
                }

            } while (!ok);

        }
        //------------------------------------------------------------------------------------------------------------------------


        //--------------------------------------------------tir de l'utilisateur--------------------------------------------------
        static void tirUti(string[,] bat_ordi, string[,] plan_jeu_uti)
        {
            int Ligne;
            int NbrColonne;
            bool toucher = false;

            Console.Clear();
            Affiche(plan_jeu_uti);
            caseselect(out Ligne, out NbrColonne);
            do
            {
                if (bat_ordi[Ligne, NbrColonne] == " B")
                {
                    plan_jeu_uti[Ligne, NbrColonne] = " R";
                    Console.Clear();
                    Console.WriteLine("Bien jouez vous avez touchez un bateau ennemi ! appuiyez sur ENTER pour accedé au console de tire\n");
                    Console.ReadLine();
                    Console.Clear();
                    Affiche(plan_jeu_uti);
                    caseselect(out Ligne, out NbrColonne);
                    toucher = true;
                }

                if (bat_ordi[Ligne, NbrColonne] == " O")
                {
                    Console.Clear();
                    Console.WriteLine("Vous n'avez touché aucun n'avire ennemi, appuiyez sur ENTER pour voire les tir ennemi\n");
                    Console.ReadLine();
                    plan_jeu_uti[Ligne, NbrColonne] = " X";
                    toucher = false;
                    Console.Clear();
                }


            } while (toucher);
        }
        //------------------------------------------------------------------------------------------------------------------------


        //----------------------------vérifié si quelqu'un gange----------------------------
        static void win(string[,] plan_jeu_uti, string[,] plan_jeu_ordi, out string message, out bool victory, out string message2)
        {
            int conteurUti = 0;
            int conteurOrdi = 0;
            message = "";
            message2 = "";
            victory = false;

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (plan_jeu_uti[i, j] == " R")
                    {
                        conteurUti++;
                    }
                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (plan_jeu_ordi[i, j] == " R")
                    {
                        conteurOrdi++;
                    }
                }
            }

            if (conteurUti == 17)
            {
                message2 = "Nous ne détectons plus de navires ennemi, nous alons lancer une analyse\n";
                message = "Bien jouez, vous avez remporter la bataille en coulant tous les navires ennemi\n";
                victory = true;
            }

            if (conteurOrdi == 17)
            {
                message2 = "Nous ne détectons plus nos navires allié, nous alons lancer une analyse\n";
                message = "Dommage, vous avez perdu la bataille, l'équipe ennemi a coulé tous vos navires\n";
                victory = true;
            }
        }
        //-----------------------------------------------------------Code Ascii-----------------------------------------------------------
        static void asciiii()
        {
            Console.WriteLine(@"
                                                                     o o
                                                     o ooo
                                                       o oo
                                                          o o |   #)
                                                           oo     _ | _ | _#_
                                                             o | U505 |
                        __                    ___________________ |       | _________________
                       | -_______---------- -                                              \
                      >| _____--->     )
                       | __ - ---------_________________________________________________ /
                ");
        }

    }
}
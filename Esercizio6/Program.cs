
/*﻿Esercizio: Indovina Numero.
Il gioco consiste nell’indovinare un numero tra 1 e 100, generato in modo casuale.

L’utente accede e visualizza un messaggio di benvenuto. 
Gli viene chiesto di inserire il suo nome, quindi, una volta inserito, 
compare un messaggio del tipo “Ciao NOME!” ed un menu con delle scelte/opzioni.
In particolare potrà scegliere se iniziare a giocare una partita o uscire dal programma.

Se l’utente decide di uscire, verrà visualizzato un messaggio di arrivederci.

Se invece decide di giocare dovrà essere generato un numero casuale 
che ovviamente NON dovrà essere mostrato a video. 
(Opzionale: il numero può essere salvato in un file “NumeroDaIndovinare.txt”). 

Dopo la generazione e memorizzazione del numero casuale, 
si dovrà chiedere all’utente di provare ad indovinare il numero 
specificando a video (e quindi controllando in fase di inserimento) 
che si tratta di un numero compreso tra 1 e 100. 
(Opzionale: Se l’utente inserisce “0” interrompe la partita e 
gli verrà mostrato un messaggio di “Partita interrotta” quindi
svelato il numero che doveva indovinare. Ritornerà quindi al menu iniziale.)

Bisognerà tener traccia dei tentativi che fa, 
mostrando il numero dei tentativi che sono stati fatti.*/

using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Esercizio6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel gioco!");
            Console.WriteLine("\nCome ti chiami?");

            char continua;
            int tentativo = 0;

            do
            {
                String nome = Console.ReadLine();
                Console.WriteLine($"Ok {nome}, iniziamo a giocare!\n");
                Console.WriteLine("-----------------Menu----------------");
                Console.WriteLine("\n1) Gioca," +
                                  "\n2)Esci");

                int scelta = int.Parse(Console.ReadLine());


              
                int result = 0;
                int num = 0;

                Random rand = new Random();



                switch (scelta)
                {
                    case 1:
                      
                        Gioco(ref tentativo, ref rand, ref result);
                        Scelta(ref num, ref result);
                        if (num != 0)
                        {
                            Verifica(ref num, ref result, ref nome);
                        }
                        break;

                    case 2:
                        Esci();
                        break;

                    default:

                        Console.WriteLine("Hai inserito un valore non corretto.");

                        break;
                }
                Console.WriteLine("\nContinuare? s/n");
                continua = Console.ReadKey().KeyChar;

            } while (continua == 's' || continua == 'S');
        }

        private static void Esci()
        {
            Console.WriteLine("Hai deciso di uscire. Alla prossima!");
            Environment.Exit(0);
        }

        private static void Verifica(ref int num, ref int result, ref string nome)
        {
            if (num == result)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"Complimenti {nome}, hai vinto!");
                Console.WriteLine($"Era stato generato proprio il numero {num}");
                Console.WriteLine("\n-----------------------------------");
            }
            else
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"\nEra stato generato il numero: {result}");
                Console.WriteLine($"Mi dispiace {nome}, hai perso!");
                Console.WriteLine("\n-----------------------------------");
            }
        }

        private static void Scelta(ref int num, ref int result)
        {
            do
            {
                Console.WriteLine("Scegli un numero fra 1 e 100:\n");
                num = int.Parse(Console.ReadLine());
            } while (num >= 100);

            if (num == 0)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("\nPartita interrotta!");
                Console.WriteLine($"\nEra stato generato il numero: {result}");
                Console.WriteLine("\n-----------------------------------");

            }
            else
            {
                Console.WriteLine($"Hai scelto il numero: {num}\n");
            }



        }

        private static void Gioco(ref int tentativo, ref Random rand, ref int result)
        {

            StreamWriter sw = new StreamWriter(@"fileProva.txt"); //va di default nella cartella bin 
            
            
            tentativo++;
            Console.WriteLine($"\nComplimenti, hai scelto di giocare!");
            Console.WriteLine($"Questo è il tuo tentativo numero: {tentativo}");

            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("\nSto generando un numero fra 1 e 100");
            result = rand.Next(1, 101);
            sw.Write(result);
            sw.Close();
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("\nNumero generato, ora tocca a te!");


        }
    }
}

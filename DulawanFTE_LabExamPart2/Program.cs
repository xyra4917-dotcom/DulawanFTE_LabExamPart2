using System;

namespace CFRSystem
{
    class Program
    {
        static string[] participantnames = new string[3];
        static int[,] scores = new int[3, 3];
        static int[] totals = new int[3];

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("   COMMUNITY FUN RUN SYSTEM");
                Console.WriteLine("[1] RECORD SCORES");
                Console.WriteLine("[2] SHOW PARTICIPANT SCORES");
                Console.WriteLine("[3] SHOW RANKING");
                Console.WriteLine("[4] EXIT");

                Console.Write("\nEnter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RecordScores();
                        break;

                    case 2:
                        ShowParticipantScores();
                        break;

                    case 3:
                        ShowRanking();
                        break;

                    case 4:
                        Console.WriteLine("Program Terminated.");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

                if (choice != 4)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != 4);
        }

        static void RecordScores()
        {
            Console.Clear();
            Console.WriteLine("RECORD SCORES");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"\nEnter Participant {i + 1} Name: ");
                participantnames[i] = Console.ReadLine();

                totals[i] = 0;

                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Round {j + 1} Score: ");
                    scores[i, j] = Convert.ToInt32(Console.ReadLine());

                    totals[i] += scores[i, j];
                }
            }

            Console.WriteLine("\nScores recorded successfully!");
        }

        static void ShowParticipantScores()
        {
            Console.Clear();
            Console.WriteLine("PARTICIPANT SCORES\n");

            Console.WriteLine("PARTICIPANT\tR1\tR2\tR3\tTOTAL");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{participantnames[i]}\t\t{scores[i, 0]}\t{scores[i, 1]}\t{scores[i, 2]}\t{totals[i]}");
            }
        }
        static void ShowRanking()
        {
            Console.Clear();
            Console.WriteLine("SHOW RANKING\n");

            string[] rankedNames = new string[3];
            int[] rankedTotals = new int[3];

            for (int i = 0; i < 3; i++)
            {
                rankedNames[i] = participantnames[i];
                rankedTotals[i] = totals[i];
            }

                for (int i = 0; i < rankedTotals.Length - 1; i++)
                {
                    int maxIndex = i;

                    for (int j = i + 1; j < rankedTotals.Length; j++)
                    {
                        if (rankedTotals[j] > rankedTotals[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }

                    int tempTotal = rankedTotals[i];
                    rankedTotals[i] = rankedTotals[maxIndex];
                    rankedTotals[maxIndex] = tempTotal;

                    string tempName = rankedNames[i];
                    rankedNames[i] = rankedNames[maxIndex];
                    rankedNames[maxIndex] = tempName;

                    Console.WriteLine($"\nPass {i + 1}");
                    for (int k = 0; k < 3; k++)
                    {
                        Console.WriteLine($"{k + 1}. {rankedNames[k]} - {rankedTotals[k]}");
                    }
                }
                         }
        }
    }

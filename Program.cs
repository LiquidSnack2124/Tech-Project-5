using System;
using System.Linq;

namespace Tech_Project_5
{
    class Program
    {
        static void Main(string[] args)
        
        {
            bool Repeat = true;
            while (Repeat)
            {
                try
                {

                    Console.WriteLine("Enter number of candidates");

                    int NumberofCandidates = int.Parse(Console.ReadLine());
                    
                    if (NumberofCandidates < 2 || NumberofCandidates > 20)
                    {
                        Console.WriteLine("Number of Candidates should be between 2 and 20");
                        throw new Exception();
                    }
                    string[] CandidateNames = new string[NumberofCandidates];
                    string[] CandidatePartys = new string[NumberofCandidates];
                    int[] CandidateVotes = new int[NumberofCandidates];

                    for (int i = 0; i<NumberofCandidates; i++) 
                        {
                        Console.WriteLine("Enter Name of Candidate");
                        CandidateNames[i] = Console.ReadLine();
                        if (containsunicode (CandidateNames[i]))
                        {
                            Console.WriteLine("Detected non ASCII input restarting program");
                            throw new Exception();
                        }
                        Console.WriteLine("Enter Name for Candidate's Party");
                        CandidatePartys[i] = Console.ReadLine();
                        if (containsunicode(CandidatePartys[i]))
                        {
                            Console.WriteLine("Detected non ASCII input restarting program");
                            throw new Exception();
                        }
                        CandidateVotes[i] = 0;
                    }
                    Console.WriteLine("Enter the total number of votes");
                    int NumberofVotes = int.Parse(Console.ReadLine());
                    
                    if (NumberofVotes < 1 || NumberofVotes > 10000)
                    {
                        Console.WriteLine("Number of Votes should be between 1 and 10000");
                        throw new Exception();

                    }
                    
                    for (int i = 0; i < NumberofVotes; i++)
                    {
                        for (int j = 0; j < NumberofCandidates; j++)
                        {
                            Console.WriteLine("Enter Vote");
                            string Vote = Console.ReadLine();
                            if (containsunicode(Vote))
                            {
                                Console.WriteLine("Detected non ASCII input restarting program");
                                throw new Exception();
                            }

                            if (CandidateNames[j].Equals(Vote))
                            {
                                CandidateVotes[j]++;
                            }
                        }
                    }
                    int Winner = 0;
                    bool Tie = false;
                    for (int i = 1; i < NumberofCandidates; i++)
                    {
                        if (CandidateVotes[i] > CandidateVotes[Winner])
                        {
                            Winner = i;
                            Tie = false;

                        }
                        else if (CandidateVotes[i] == CandidateVotes[Winner])
                        {
                            Tie = true;
                        }


                    }
                    Console.WriteLine("The Winners Party is...");
                    Console.WriteLine(CandidatePartys[Winner]);
                    Console.ReadLine();
                    Environment.Exit (0);
                }
                catch
                {

                }
            }
        }

        private static bool containsunicode(string input)
        {
            const int MaxAnsiCode = 255;

            return input.Any(c => c > MaxAnsiCode);
        }
    }
}

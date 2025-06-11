using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        string secretNumber = rand.Next(1000, 10000).ToString(); 

        while (true)
        {
            Console.Write("Vuvedi 4 cifreno chislo: ");
            string guess = Console.ReadLine();

            if (guess.Length != 4 || !int.TryParse(guess, out _))
            {
                Console.WriteLine("Molq vuvedi 4 cifreno chislo.");
                continue;
            }

            int bulls = 0;
            int cows = 0;

            bool[] secretUsed = new bool[4];
            bool[] guessUsed = new bool[4];

            
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secretNumber[i])
                {
                    bulls++;
                    secretUsed[i] = true;
                    guessUsed[i] = true;
                }
            }

           
            for (int i = 0; i < 4; i++)
            {
                if (guessUsed[i]) continue;

                for (int j = 0; j < 4; j++)
                {
                    if (!secretUsed[j] && guess[i] == secretNumber[j])
                    {
                        cows++;
                        secretUsed[j] = true;
                        break;
                    }
                }
            }

            
            if (bulls == 4)
            {
                Console.WriteLine($"Pozdravleniq!Ti pozna choisloto: {secretNumber}");
                break;
            }
            else if (bulls == 0 && cows == 0)
            {
                Console.WriteLine("Nqmash verno chislo.");
            }
            else
            {
                for (int i = 0; i < bulls; i++)
                    Console.WriteLine("Imash veren bik.");
                for (int i = 0; i < cows; i++)
                    Console.WriteLine("imash edna krava" +
                        ".");
            }
        }
    }
}

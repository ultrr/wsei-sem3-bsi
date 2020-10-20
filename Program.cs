using System;

namespace bsi_3
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Wybierz szyfr:");
                Console.WriteLine("1. Szyfr Cezara");
                Console.WriteLine("2. Szyfr Vigenere");
                Console.WriteLine("3. Szyfr Playfair");
                Console.Write("> ");
                string choose1 = Console.ReadLine();
                if (choose1 != "1" && choose1 != "2" && choose1 != "3") throw new ArgumentException();

                Console.WriteLine("Wybierz czynność:");
                Console.WriteLine("1. Kodowanie");
                Console.WriteLine("2. Rozkodowywanie");
                Console.Write("> ");
                string choose2 = Console.ReadLine();
                if (choose2 != "1" && choose1 != "2") throw new ArgumentException();

                Console.WriteLine("Wprowadź ciąg znaków:");
                Console.Write("> ");
                string input = Console.ReadLine();
                Console.WriteLine("Wprowadź szyfr:");
                Console.Write("> ");
                string code = Console.ReadLine();
                Console.WriteLine();

                Ciphers.CipherBase cipher;

                switch (choose1)
                {
                    case "1":
                        cipher = new Ciphers.CipherCesar(input, code);
                        break;

                    case "2":
                        cipher = new Ciphers.CipherVigenere(input, code);
                        break;

                    case "3":
                        cipher = new Ciphers.CipherPlayfair(input, code);
                        break;

                    default:
                        throw new ArgumentException();
                }

                switch (choose2)
                {
                    case "1":
                        Console.Write("Zakodowany ciąg znaków: ");
                        Console.WriteLine(cipher.Encrypt());
                        break;

                    case "2":
                        Console.Write("Rozkodowany ciąg znaków: ");
                        Console.WriteLine(cipher.Decrypt());
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("=====");
                Console.WriteLine();



            }
        }
    }
}
using Crypto;
using System;
using System.IO;

namespace CryptoTool
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to XPChain Crypto Tool");
            Console.WriteLine("______________________________\n");
            Console.WriteLine("This helps you locally perform simple cryptographic tasks.");
            Console.WriteLine("Choose from the Menu:");
            Console.WriteLine("1. Generate Public-Private Key Pair");
            Console.WriteLine("2. Generate Signature");
            Console.WriteLine("3. Verify Signature\n");
            Console.Write("Enter your choice: ");

            var answer = Console.ReadLine();

            if (int.TryParse(answer, out var choice))
            {
                switch (choice)
                {
                    case 1:
                        var keyPair = KeyPair.NewKeyPair();

                        Console.WriteLine($"Public Key: {keyPair.PublicKey}\n");
                        Console.WriteLine($"Private Key: {keyPair.PrivateKey}\n\n\n");
                        Console.Write("Export to Text File? (Y/n): ");
                        if (Console.ReadLine()?.ToLower() != "n")
                        {
                            File.WriteAllLines("Keys.txt",
                                new[] {
                                    "Public Key: ",
                                    keyPair.PublicKey,
                                    "\nPrivate Key: ",
                                    keyPair.PrivateKey
                                });
                            Console.WriteLine("Keys.txt Saved.");
                        }
                        break;

                    case 2:
                        Console.Write("Message: ");
                        var data = Console.ReadLine();

                        Console.Write("Private Key: ");
                        var privateKey = Console.ReadLine();

                        var sign = SignatureProvider.GetSignature(data, privateKey);
                        Console.WriteLine($"\nSignature: {sign}\n\n\n");
                        break;

                    case 3:
                        Console.Write("Message: ");
                        var text = Console.ReadLine();

                        Console.Write("Signature: ");
                        var signature = Console.ReadLine();

                        Console.Write("Public Key: ");
                        var publicKey = Console.ReadLine();
                        var isValid = SignatureProvider.Verify(text, signature, publicKey);

                        Console.WriteLine($"Is Valid: {isValid}");
                        break;

                    default:
                        Console.WriteLine("Invalid Input. Exiting...");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input. Exiting...");
            }

            Console.ReadKey();
        }
    }
}

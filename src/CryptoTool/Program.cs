using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Crypto;

namespace CryptoTool
{
    class Program
    {
        static void Main()
        {
            const string menu = @"
Welcome to XPChain Crypto Tool
______________________________

This helps you locally perform small tasks.
Choose from the Menu:

1. Generate Public-Private Key Pair
2. Generate Signature
3. Verify Signature
            ";

            Console.WriteLine(menu);
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
                            File.WriteAllLines("Keys.txt", new []
                            {
                                "Public Key: ", keyPair.PublicKey,
                                "\nPrivate Key: ", keyPair.PrivateKey
                            });
                        }
                        break;

                    case 2:
                        Console.Write("Message: ");
                        var data = Encoding.UTF8.GetBytes(Console.ReadLine());

                        Console.Write("Private Key: ");
                        var privateKey = Console.ReadLine();

                        var sign  = SignatureProvider.GetSignature(data, privateKey);
                        Console.WriteLine($"\nSignature: {sign}\n\n\n");
                        break;

                    case 3:
                        Console.Write("Message: ");
                        var text = Encoding.UTF8.GetBytes(Console.ReadLine());

                        Console.Write("Signature: ");
                        var signature = Convert.FromBase64String(Console.ReadLine());
                        
                        Console.Write("Public Key: ");
                        var publicKey = Console.ReadLine();
                        var isValid =
                            SignatureProvider.Verify(text, signature, publicKey);
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

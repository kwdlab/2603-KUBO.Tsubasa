using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace MLKemDecapsulation
{
    class DecapsulationProfile
    {
        static void Main(string[] args)
        {
            var kemParam = MLKemParameters.ml_kem_1024;
            var kemName = "ML-KEM-1024";

            const int LoopCount = 100000;

            var random = new SecureRandom();

            var kpg = new MLKemKeyPairGenerator();
            kpg.Init(new MLKemKeyGenerationParameters(random, kemParam));
            var kp = kpg.GenerateKeyPair();

            var encapsulator = KemUtilities.GetEncapsulator(kemName);
            encapsulator.Init(kp.Public);

            byte[] ciphertext = new byte[encapsulator.EncapsulationLength];
            byte[] encapSecret = new byte[encapsulator.SecretLength];

            encapsulator.Encapsulate(
                ciphertext, 0, ciphertext.Length,
                encapSecret, 0, encapSecret.Length
            );

            var decapsulator = KemUtilities.GetDecapsulator(kemName);
            decapsulator.Init(kp.Private);

            byte[] decapSecret = new byte[decapsulator.SecretLength];

            for (int i = 0; i < 1000; i++)
            {
                decapsulator.Decapsulate(
                    ciphertext, 0, ciphertext.Length,
                    decapSecret, 0, decapSecret.Length
                );
            }

            Console.WriteLine("Warm-up done. Start profiling now.");
            Console.WriteLine("Press ENTER to start Decapsulation loop...");
            Console.ReadLine();

            for (int i = 0; i < LoopCount; i++)
            {
                decapsulator.Decapsulate(
                    ciphertext, 0, ciphertext.Length,
                    decapSecret, 0, decapSecret.Length
                );
            }

            Console.WriteLine($"ML-KEM Decapsulation finished: {kemParam.Name}");
        }
    }
}

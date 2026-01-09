using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace MLKemEncapsulation
{
    class EncapsulationProfile
    {
        static void Main(string[] args)
        {
            var kemParam = MLKemParameters.ml_kem_1024;
            var kemName = "ML-KEM-1024";

            const int LoopCount = 100000;

            var random = new SecureRandom();

            var kpg = new MLKemKeyPairGenerator();
            kpg.Init(new MLKemKeyGenerationParameters(
                random,
                kemParam
            ));
            var kp = kpg.GenerateKeyPair();

            var encapsulator = KemUtilities.GetEncapsulator(kemName);
            encapsulator.Init(kp.Public);

            byte[] encapsulation = new byte[encapsulator.EncapsulationLength];
            byte[] secret = new byte[encapsulator.SecretLength];

            for (int i = 0; i <1000; i++)
            {
                encapsulator.Encapsulate(
                    encapsulation, 0, encapsulation.Length,
                    secret, 0, secret.Length
                );
            }

            Console.WriteLine("Warm-up done. Start profiling now.");
            Console.WriteLine("Press ENTER to start Encapsulation loop...");
            Console.ReadLine();

            for (int i = 0; i < LoopCount; i++)
            {
                encapsulator.Encapsulate(
                    encapsulation, 0, encapsulation.Length,
                    secret, 0, secret.Length
                );
            }

            Console.WriteLine($"ML-KEM Encapsulation finished: {kemParam.Name}");
        }
    }
}

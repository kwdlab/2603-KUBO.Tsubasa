using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace MLKemKeyGeneration
{
    class KeyGenerationProfile
    {
        static void Main(string[] args)
        {
            var kemParam = MLKemParameters.ml_kem_1024;

            const int LoopCount = 100000;

            var random = new SecureRandom();

            var kpg = new MLKemKeyPairGenerator();
            kpg.Init(new MLKemKeyGenerationParameters(
                random,
                kemParam
            ));

            for (int i = 0; i < 1000; i++)
            {
                var kp = kpg.GenerateKeyPair();
            }

            Console.WriteLine("Warm-up done. Start profiling now.");
            Console.WriteLine("Press ENTER to start Key Generation loop...");
            Console.ReadLine();

            for (int i = 0; i < LoopCount; i++)
            {
                var kp = kpg.GenerateKeyPair();
            }

            Console.WriteLine($"ML-KEM Key Generation finished: {kemParam.Name}");
        }
    }
}

using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace MLKemKeyGeneration
{
    class Program
    {
        static readonly MLKemParameters KemParam =
            MLKemParameters.ml_kem_512;
        // MLKemParameters.ml_kem_768;
        // MLKemParameters.ml_kem_1024;

        static void Main(string[] args)
        {
            const int LoopCount = 100000;

            var random = new SecureRandom();

            var kpg = new MLKemKeyPairGenerator();
            kpg.Init(new MLKemKeyGenerationParameters(
                random,
                KemParam
            ));

            for (int i = 0; i < LoopCount; i++)
            {
                var kp = kpg.GenerateKeyPair();
            }

            Console.WriteLine($"ML-KEM Key Generation finished: {KemParam.Name}");
        }
    }
}

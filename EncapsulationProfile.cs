using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace MLKemEncapsulation
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
            var kp = kpg.GenerateKeyPair();

            var encapsulator = KemUtilities.GetEncapsulator("ML-KEM-512");
            encapsulator.Init(kp.Public);

            byte[] encapsulation = new byte[encapsulator.EncapsulationLength];
            byte[] secret = new byte[encapsulator.SecretLength];

            for (int i = 0; i < LoopCount; i++)
            {
                encapsulator.Encapsulate(
                    encapsulation, 0, encapsulation.Length,
                    secret, 0, secret.Length
                );
            }

            Console.WriteLine($"ML-KEM Encapsulation finished: {KemParam.Name}");
        }
    }
}

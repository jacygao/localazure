using KeyController;
using Emulator.Providers.StoreProvider;
using System.Security.Cryptography;
using System.Text.Json;
using Emulator.Services.KeyVault;
using Emulator.Providers.StoreProvider.Exceptions;

namespace Emulator.Controllers.KeyVault.KeyController
{
    public class KeyControllerImpl(IStoreProvider<object> store) : IController
    {
        private const int DefaultKeySize = 2048;
        private const JsonWebKeyCrv DefaultCrv = JsonWebKeyCrv.P256;
        private readonly List<string> DefaultKeyOps =
        [
            "encrypt", "decrypt", "sign", "verify", "wrapKey", "unwrapKey"
        ];

        private readonly IStoreProvider<object> _store = store;

        public Task<BackupKeyResult> BackupKeyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public async Task<KeyBundle> CreateKeyAsync(string key_name, KeyCreateParameters parameters, string api_version)
        {
            // Input validation
            if (parameters.Kty is not KeyCreateParametersKty.RSA)
            {
                throw new Exception("only RSA is supported by key vault emulator");
            }

            try
            {
                // Generate RSA key
                using var rsa = new RSACryptoServiceProvider(DefaultKeySize);
                var rsaParameters = rsa.ExportParameters(true);
                var currentUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                KeyBundle keyBundle = new()
                {
                    Key = new JsonWebKey
                    {
                        Kid = Utils.GenerateVersionIdentifier(),
                        Kty = (JsonWebKeyKty?)parameters.Kty,
                        Key_ops = parameters.Key_ops.Count > 0 ? parameters.Key_ops.Select(op => op.ToString()).ToList() : DefaultKeyOps,
                        N = Convert.ToBase64String(rsaParameters.Modulus),
                        E = Convert.ToBase64String(rsaParameters.Exponent),
                        D = Convert.ToBase64String(rsaParameters.D),
                        Dp = Convert.ToBase64String(rsaParameters.DP),
                        Dq = Convert.ToBase64String(rsaParameters.DQ),
                        Qi = Convert.ToBase64String(rsaParameters.InverseQ),
                        P = Convert.ToBase64String(rsaParameters.P),
                        Q = Convert.ToBase64String(rsaParameters.Q),
                        K = null, // Not applicable for RSA
                        Key_hsm = null, // Not applicable for this example
                        Crv = parameters.Crv == null ? (JsonWebKeyCrv?)parameters.Crv : DefaultCrv,
                        X = null, // Not applicable for RSA
                        Y = null // Not applicable for RSA
                    },
                    Attributes = new KeyAttributes
                    {
                        Created = (int?)currentUnixTimestamp,
                        Updated = (int?)currentUnixTimestamp,
                    }
                };

                _store.Save(key_name, keyBundle);
                
                return keyBundle;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<KeyOperationResult> DecryptAsync(string key_name, string key_version, KeyOperationsParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedKeyBundle> DeleteKeyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyOperationResult> EncryptAsync(string key_name, string key_version, KeyOperationsParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedKeyBundle> GetDeletedKeyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedKeyListResult> GetDeletedKeysAsync(int? maxresults, string api_version)
        {
            throw new NotImplementedException();
        }

        public async Task<KeyBundle> GetKeyAsync(string key_name, string key_version, string api_version)
        {
            // Validate Inputs
            ArgumentException.ThrowIfNullOrEmpty(key_name);
            ArgumentException.ThrowIfNullOrEmpty(key_version);
            ArgumentException.ThrowIfNullOrEmpty(api_version);

            return _store.Load(key_name);
        }

        public Task<KeyRotationPolicy> GetKeyRotationPolicyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyListResult> GetKeysAsync(int? maxresults, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyListResult> GetKeyVersionsAsync(string key_name, int? maxresults, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<RandomBytes> GetRandomBytesAsync(GetRandomBytesRequest parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyBundle> ImportKeyAsync(string key_name, KeyImportParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task PurgeDeletedKeyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyBundle> RecoverDeletedKeyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyReleaseResult> ReleaseAsync(string key_name, string key_version, KeyReleaseParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyBundle> RestoreKeyAsync(KeyRestoreParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyBundle> RotateKeyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyOperationResult> SignAsync(string key_name, string key_version, KeySignParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyOperationResult> UnwrapKeyAsync(string key_name, string key_version, KeyOperationsParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyBundle> UpdateKeyAsync(string key_name, string key_version, KeyUpdateParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyRotationPolicy> UpdateKeyRotationPolicyAsync(string key_name, KeyRotationPolicy keyRotationPolicy, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyVerifyResult> VerifyAsync(string key_name, string key_version, KeyVerifyParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyOperationResult> WrapKeyAsync(string key_name, string key_version, KeyOperationsParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }
    }
}

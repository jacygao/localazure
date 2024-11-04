using KeyController;
using KeyVaultEmulator.Providers.StoreProvider;
using System.Text.Json;

namespace KeyVaultEmulator.Controllers.KeyController
{
    public class KeyControllerImpl : IController
    {
        private IStoreProvider _store;
        public KeyControllerImpl(IStoreProvider store) {
            this._store = store;
        }

        public Task<BackupKeyResult> BackupKeyAsync(string key_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<KeyBundle> CreateKeyAsync(string key_name, KeyCreateParameters parameters, string api_version)
        {
            _store.Save(key_name, JsonSerializer.Serialize(parameters));
            throw new NotImplementedException();
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

        public Task<KeyBundle> GetKeyAsync(string key_name, string key_version, string api_version)
        {
            throw new NotImplementedException();
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

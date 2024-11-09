using Newtonsoft.Json;
using SecretController;

namespace Emulator.Controllers.KeyVault.SecretController
{
    public class SecretControllerImpl : IController
    {
        private readonly Mock? _mock;

        public SecretControllerImpl()
        {
            string jsonFilePath = "Mock/KeyVault/Secret.json";
            string jsonString = File.ReadAllText(jsonFilePath);

            _mock = JsonConvert.DeserializeObject<Mock>(jsonString);
        }

        public async Task<BackupSecretResult> BackupSecretAsync(string secret_name, string api_version)
        {
            return _mock?.BackupSecret!;
        }

        public async Task<DeletedSecretBundle> DeleteSecretAsync(string secret_name, string api_version)
        {
            return _mock?.DeleteSecret!;
        }

        public async Task<DeletedSecretBundle> GetDeletedSecretAsync(string secret_name, string api_version)
        {
            return _mock?.GetDeletedSecret!;
        }

        public async Task<DeletedSecretListResult> GetDeletedSecretsAsync(int? maxresults, string api_version)
        {
            return _mock?.GetDeletedSecrets!;
        }

        public async Task<SecretBundle> GetSecretAsync(string secret_name, string secret_version, string api_version)
        {
            return _mock?.GetSecret!;
        }

        public async Task<SecretListResult> GetSecretsAsync(int? maxresults, string api_version)
        {
            return _mock?.GetSecrets!;
        }

        public async Task<SecretListResult> GetSecretVersionsAsync(string secret_name, int? maxresults, string api_version)
        {
            return _mock?.GetSecretVersions!;
        }

        public async Task PurgeDeletedSecretAsync(string secret_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public async Task<SecretBundle> RecoverDeletedSecretAsync(string secret_name, string api_version)
        {
            return _mock?.RecoverDeletedSecret!;
        }

        public async Task<SecretBundle> RestoreSecretAsync(SecretRestoreParameters parameters, string api_version)
        {
            return _mock?.RestoreSecret!;
        }

        public async Task<SecretBundle> SetSecretAsync(string secret_name, SecretSetParameters parameters, string api_version)
        {
            return _mock?.SetSecret!;
        }

        public async Task<SecretBundle> UpdateSecretAsync(string secret_name, string secret_version, SecretUpdateParameters parameters, string api_version)
        {
            return _mock?.UpdateSecret!;
        }
    }
}

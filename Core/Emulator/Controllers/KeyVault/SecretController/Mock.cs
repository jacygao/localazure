using SecretController;

namespace Emulator.Controllers.KeyVault.SecretController
{
    public class Mock
    {
        public BackupSecretResult? BackupSecret { get; set; }

        public DeletedSecretBundle? DeleteSecret { get; set; }

        public DeletedSecretBundle? GetDeletedSecret { get; set; }

        public DeletedSecretListResult? GetDeletedSecrets { get; set; }

        public SecretBundle? GetSecret { get; set; }

        public SecretListResult? GetSecretVersions { get; set; }

        public SecretListResult? GetSecrets { get; set; }

        public SecretBundle? RecoverDeletedSecret { get; set; }

        public SecretBundle? RestoreSecret { get; set; }

        public SecretBundle? SetSecret { get; set; }

        public SecretBundle? UpdateSecret { get; set; }
    }
}

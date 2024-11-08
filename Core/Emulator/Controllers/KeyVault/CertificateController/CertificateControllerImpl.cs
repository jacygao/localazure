using CertificateController;
using Action = CertificateController.Action;

namespace Emulator.Controllers.KeyVault.CertificateController
{
    public class CertificateControllerImpl : IController
    {
        public Task<BackupCertificateResult> BackupCertificateAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateOperation> CreateCertificateAsync(string certificate_name, CertificateCreateParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedCertificateBundle> DeleteCertificateAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<Contacts> DeleteCertificateContactsAsync(string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<IssuerBundle> DeleteCertificateIssuerAsync(string issuer_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateOperation> DeleteCertificateOperationAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public async Task<CertificateBundle> GetCertificateAsync(string certificate_name, string certificate_version, string api_version)
        {
            CertificateBundle response = new()
            {
                Id = $"https://myvault.vault.localazure.net/certificates/{certificate_name}/f60f2a4f8ae442cfb41ca2090bd4b769",
                Kid = $"https://myvault.vault.localazure.net/keys/{certificate_name}/f60f2a4f8ae442cfb41ca2090bd4b769",
                Sid = $"https://myvault.vault.localazure.net/secrets/{certificate_name}/f60f2a4f8ae442cfb41ca2090bd4b769",
                X5t = "fLi3U52HunIVNXubkEnf8tP6Wbo",
                Cer = Convert.FromBase64String("MIICODCCAeagAwIBAgIQqHmpBAv+CY9IJFoUhlbziTAJBgUrDgMCHQUAMBYxFDASBgNVBAMTC1Jvb3QgQWdlbmN5MB4XDTE1MDQyOTIxNTM0MVoXDTM5MTIzMTIzNTk1OVowFzEVMBMGA1UEAxMMS2V5VmF1bHRUZXN0MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA5bVAT73zr4+N4WVv2+SvTunAw08ksS4BrJW/nNliz3S9XuzMBMXvmYzU5HJ8TtEgluBiZZYd5qsMJD+OXHSNbsLdmMhni0jYX09h3XlC2VJw2sGKeYF+xEaavXm337aZZaZyjrFBrrUl51UePaN+kVFXNlBb3N3TYpqa7KokXenJQuR+i9Gv9a77c0UsSsDSryxppYhKK7HvTZCpKrhVtulF5iPMswWe9np3uggfMamyIsK/0L7X9w9B2qN7993RR0A00nOk4H6CnkuwO77dSsD0KJsk6FyAoZBzRXDZh9+d9R76zCL506NcQy/jl0lCiQYwsUX73PG5pxOh02OwKwIDAQABo0swSTBHBgNVHQEEQDA+gBAS5AktBh0dTwCNYSHcFmRjoRgwFjEUMBIGA1UEAxMLUm9vdCBBZ2VuY3mCEAY3bACqAGSKEc+41KpcNfQwCQYFKw4DAh0FAANBAGqIjo2geVagzuzaZOe1ClGKhZeiCKfWAxklaGN+qlGUbVS4IN4V1lot3VKnzabasmkEHeNxPwLn1qvSD0cX9CE="),
                Attributes = new CertificateAttributes
                {
                    Enabled = true,
                    Nbf = 1430344421,
                    Exp = 2108988799,
                    Created = 1493938289,
                    Updated = 1493938291,
                    RecoveryLevel = CertificateAttributesRecoveryLevel.Recoverable_Purgeable,
                },
                Policy = new CertificatePolicy
                {
                    Id = $"https://myvault.vault.localazure.net/certificates/{certificate_name}/policy",
                    Key_props = new KeyProperties
                    {
                        Exportable = true,
                        Kty = KeyPropertiesKty.RSA,
                        Key_size = 2048,
                        Reuse_key = false,
                    },
                    Secret_props = new SecretProperties
                    {
                        ContentType = "application/x-pkcs12"
                    },
                    X509_props = new X509CertificateProperties
                    {
                        Subject = "CN=KeyVaultDefault",
                        Ekus = [],
                        Key_usage = [],
                        Validity_months = 297
                    },
                    Lifetime_actions =
                    [
                        new() {
                            Trigger = new Trigger
                            {
                                Lifetime_percentage = 80,
                            },
                            Action = new Action
                            {
                                Action_type = Action_type.EmailContacts
                            }
                        }
                    ],
                    Issuer = new IssuerParameters
                    {
                        Name = "Unknown"
                    }
                }
            };

            return response;
        }

        public Task<Contacts> GetCertificateContactsAsync(string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<IssuerBundle> GetCertificateIssuerAsync(string issuer_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateIssuerListResult> GetCertificateIssuersAsync(int? maxresults, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateOperation> GetCertificateOperationAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificatePolicy> GetCertificatePolicyAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateListResult> GetCertificatesAsync(int? maxresults, bool? includePending, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateListResult> GetCertificateVersionsAsync(string certificate_name, int? maxresults, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedCertificateBundle> GetDeletedCertificateAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedCertificateListResult> GetDeletedCertificatesAsync(int? maxresults, bool? includePending, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateBundle> ImportCertificateAsync(string certificate_name, CertificateImportParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateBundle> MergeCertificateAsync(string certificate_name, CertificateMergeParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task PurgeDeletedCertificateAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateBundle> RecoverDeletedCertificateAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateBundle> RestoreCertificateAsync(CertificateRestoreParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<Contacts> SetCertificateContactsAsync(Contacts contacts, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<IssuerBundle> SetCertificateIssuerAsync(string issuer_name, CertificateIssuerSetParameters parameter, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateBundle> UpdateCertificateAsync(string certificate_name, string certificate_version, CertificateUpdateParameters parameters, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<IssuerBundle> UpdateCertificateIssuerAsync(string issuer_name, CertificateIssuerUpdateParameters parameter, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateOperation> UpdateCertificateOperationAsync(string certificate_name, CertificateOperationUpdateParameter certificateOperation, string api_version)
        {
            throw new NotImplementedException();
        }

        public Task<CertificatePolicy> UpdateCertificatePolicyAsync(string certificate_name, CertificatePolicy certificatePolicy, string api_version)
        {
            throw new NotImplementedException();
        }
    }
}

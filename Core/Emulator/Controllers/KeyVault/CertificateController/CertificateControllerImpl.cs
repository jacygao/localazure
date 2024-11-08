using CertificateController;
using Newtonsoft.Json;
using Action = CertificateController.Action;

namespace Emulator.Controllers.KeyVault.CertificateController
{
    public class CertificateControllerImpl : IController
    {
        private readonly Mock? _mock;

        public CertificateControllerImpl()
        {
            string jsonFilePath = "Mock/KeyVault/Certificate/mock.json";
            string jsonString = File.ReadAllText(jsonFilePath);

            _mock = JsonConvert.DeserializeObject<Mock>(jsonString);
            Console.WriteLine(_mock);
        }

        public Task<BackupCertificateResult> BackupCertificateAsync(string certificate_name, string api_version)
        {
            throw new NotImplementedException();
        }

        public async Task<CertificateOperation> CreateCertificateAsync(string certificate_name, CertificateCreateParameters parameters, string api_version)
        {
            return _mock?.CreateCertificateAsync!;
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
            return _mock?.GetCertificateAsync!;
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

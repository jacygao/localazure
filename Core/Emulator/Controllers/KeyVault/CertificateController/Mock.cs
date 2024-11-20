using CertificateController;

namespace Emulator.Controllers.KeyVault.CertificateController
{
    public class Mock
    {
        public CertificateBundle? GetCertificate { get; set; }

        public CertificateOperation? CreateCertificate {  get; set; }

        public Contacts? GetCertificateContacts { get; set; }

        public IssuerBundle? GetCertificateIssuer { get; set; }

        public CertificateIssuerListResult? GetCertificateIssuers { get; set; }

        public CertificateOperation? GetCertificateOperaion { get; set; }

        public CertificatePolicy? GetCertificatePolicy { get; set; }

        public CertificateListResult? GetCertificates { get; set; }

        public DeletedCertificateBundle? GetDeletedCertificate {  get; set; }

        public DeletedCertificateListResult? GetDeletedCertificates { get; set; }

        public CertificateBundle? ImportCertificate { get; set; }

        public CertificateBundle? MergeCertificate { get; set; }

        public DeletedCertificateBundle? DeleteCertificate { get; set; }
    }
}

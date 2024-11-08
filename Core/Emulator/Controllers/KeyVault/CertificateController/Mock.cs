using CertificateController;

namespace Emulator.Controllers.KeyVault.CertificateController
{
    public class Mock
    {
        public CertificateBundle? GetCertificateAsync { get; set; }

        public CertificateOperation? CreateCertificateAsync {  get; set; }
    }
}

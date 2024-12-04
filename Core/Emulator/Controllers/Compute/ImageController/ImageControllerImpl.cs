using ImageController;
using Newtonsoft.Json;

namespace Emulator.Controllers.Compute.ImageController
{
    public class ImageControllerImpl : IImagesController
    {
        private readonly Mock? _mock;

        public ImageControllerImpl()
        {
            string jsonFilePath = "Mock/Compute/Image.json";
            string jsonString = File.ReadAllText(jsonFilePath);

            _mock = JsonConvert.DeserializeObject<Mock>(jsonString);
        }

        public Task<Image> CreateOrUpdateAsync(string resourceGroupName, string imageName, Image parameters, string api_version, string subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string resourceGroupName, string imageName, string api_version, string subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetAsync(string resourceGroupName, string imageName, string expand, string api_version, string subscriptionId)
        {
            return _mock?.Get!;
        }

        public Task<ImageListResult> ListAsync(string api_version, string subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<ImageListResult> ListByResourceGroupAsync(string resourceGroupName, string api_version, string subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> UpdateAsync(string resourceGroupName, string imageName, ImageUpdate parameters, string api_version, string subscriptionId)
        {
            throw new NotImplementedException();
        }
    }
}
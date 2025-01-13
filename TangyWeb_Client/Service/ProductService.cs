using Newtonsoft.Json;
using Tangy_Models;

namespace TangyWeb_Client.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDTO> Get(int id)
        {
            var response = _httpClient.GetAsync($"/api/product/{id}");
            var content = await response.Result.Content.ReadAsStringAsync();

            if (response.IsCompletedSuccessfully)
            {
                var product = JsonConvert.DeserializeObject<ProductDTO>(content);
                return product;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var response = _httpClient.GetAsync("/api/product");
            if (response.IsCompletedSuccessfully)
            {
                var content = await response.Result.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(content);
                return products;
            }
            return new List<ProductDTO>();

        }
    }
}

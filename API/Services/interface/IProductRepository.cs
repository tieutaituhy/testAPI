using API.Model;

namespace API.Services
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll(string seach);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventorySystem.Data
{
    public interface IProductRepository : IDisposable
    {
        Task<List<ProductDto>> GetProducts(int companyID);
        Task<ProductDto> GetProductByID(int studentID);

        void InsertProduct(ProductDto product);
        void DeleteProduct(ProductDto product);
        void UpdateProduct(ProductDto product);
        Task<int> Save();
    }
}

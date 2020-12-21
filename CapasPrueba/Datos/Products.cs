using Entidad;

namespace Datos
{
    public class Products
    {
        public GetProducts getProducts()
        {

            var products = new APIHelper<GetProducts>();
            var client = products.Client("/api/productos");
            var request = products.Request();
            var response = products.Response(client, request);
            var content = products.Content<GetProducts>(response);
            return content;

        }

        public GetProducts getProductById(int category_id)
        {

            var products = new APIHelper<GetProducts>();
            var client = products.Client("/api/productos/"+category_id);
            var request = products.Request();
            var response = products.Response(client, request);
            var content = products.Content<GetProducts>(response);
            return content;

        }
    }
}

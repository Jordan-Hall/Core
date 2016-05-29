using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace JordanHall.Core.HttpClientFactory
{
    public interface IHttpRequester
    {
        Task<T> Get<T>(string path) where T : class;
        Task<T> Post<T>(string path, HttpContent content) where T : class;
        Task<TR> PostAsJson<TP, TR>(string path, TP postObject) where TP : class where TR: class;
        Task<T> Post<T>(string path, string content) where T : class;
        Task<bool> Delete(string path);
    }
}

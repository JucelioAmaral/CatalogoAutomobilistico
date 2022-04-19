using System.Threading.Tasks;
using WebMotors.Domain;

namespace WebMotors.Infrastructure.Contract
{
    public interface IAnuncioRepo
    {
        Task<Anuncio> SelectAnuncio(string tema);
        Task<Anuncio> SelectAnuncioById(int id);
        Task<Anuncio> InsertAnuncio(Anuncio anuncio);
        Task<int> UpdateAnuncio(int id, Anuncio usuario);
        Task<int> DeleteAnuncio(int id);
    }
}

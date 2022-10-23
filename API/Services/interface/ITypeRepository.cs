
using API.Model;

namespace API.Services
{
    public interface ITypeRepository
    {
        List<TypeVM> GetAllTypes();
        TypeVM GetById(int Id);
        TypeVM Add(TypeModel type);
        void Update(TypeVM type);
        void Delete(int Id);
        //List<TypeVM> GetAllAllTypes();
    }
}

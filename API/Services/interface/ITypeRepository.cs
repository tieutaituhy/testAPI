
using API.Model;

namespace API.Services
{
    public interface ITypeRepository
    {
        List<TypeVM> GetAllTypes();
        TypeVM GetById(int Id);
        TypeVM Add(TypeModel type);
        void Update(TypeModel type, int Id);
        void Delete(int Id);
        //List<TypeVM> GetAllAllTypes();
    }
}

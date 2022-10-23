using API.Model;

namespace API.Services
{
    public class TypeRopositoryInMemory : ITypeRepository
    {
        static List<TypeVM> types = new List<TypeVM>()
        {
            new TypeVM {TypeId = 1, TypeName = "A"},
            new TypeVM {TypeId = 2, TypeName = "B"},
            new TypeVM {TypeId = 3, TypeName = "C"},
            new TypeVM {TypeId = 4, TypeName = "D"},
        };

        public TypeVM Add(TypeModel type)
        {
            var typess = new TypeVM
            {
                TypeId = types.Max(t => t.TypeId) + 1,
                TypeName = type.TypeName,
            };
            types.Add(typess);
            return typess;
        }

        public void Delete(int Id)
        {
            var typess = types.SingleOrDefault(t => t.TypeId == Id);
            types.Remove(typess);
        }

        public List<TypeVM> GetAllTypes()
        {
            return types;
        }

        public TypeVM GetById(int Id)
        {
            return types.SingleOrDefault(t => t.TypeId == Id);
        }

        public void Update(TypeVM type)
        {
            var typess = types.SingleOrDefault(t => t.TypeId == type.TypeId);
            if (typess != null)
            {
                typess.TypeName =type.TypeName;
            }
        }
    }
}

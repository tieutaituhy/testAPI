using API.Data;
using API.Helpers;
using API.Model;

namespace API.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DataContext _context;
        public TypeRepository(DataContext context)
        {
            _context = context;
        }
        public List<TypeVM> GetAllTypes()
        {
            var types = _context.TypeProducts.Select(t => new TypeVM
            {
                TypeId = t.TypeId,
                TypeName = t.TypeName,
            });
            return types.ToList();
        }

        public TypeVM GetById(int Id)
        {
            var types = _context.TypeProducts.SingleOrDefault(t => t.TypeId == Id);
            if (types == null)
            {
                return new TypeVM
                {
                    TypeId = types.TypeId,
                    TypeName = types.TypeName
                };
            }
            return null; 
        }

        public TypeVM Add(TypeModel type)
        {
            var types = new TypeProduct
            {
                TypeName = type.TypeName,

            };
            _context.Add(types);
            _context.SaveChanges();
            return new TypeVM
            {
                TypeId = types.TypeId,
                TypeName = types.TypeName
            };
        }

        public void Update(TypeModel type, int Id)
        {
            var types = _context.TypeProducts.SingleOrDefault(t => t.TypeId == Id);
            type.TypeName = types.TypeName;
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var types = _context.TypeProducts.SingleOrDefault(t => t.TypeId == Id);
            if(types != null)
            {
                _context.Remove(types);
                _context.SaveChanges();
            }
        }
    }
}
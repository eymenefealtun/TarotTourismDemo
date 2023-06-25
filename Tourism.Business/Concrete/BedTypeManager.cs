using Tourism.Entities.Abstract;


namespace Tourism.Entities.Concrete
{
    public class BedTypeManager : IBedTypeService
    {
        private IBedTypeDal _bedTypeDal;
        public BedTypeManager(IBedTypeDal bedTypedal )
        {
            _bedTypeDal = bedTypedal;       
        }

        public List<BedType> GetAll()
        {
            return _bedTypeDal.GetAll();
        }
    }
}

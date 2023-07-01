namespace Tourism.Entities.Concrete
{
    public interface ICustomerService
    {

        Customer Update(Customer customer);
        List<Customer> BulkUpdate(List<Customer> customer);
        List<Customer> GetByRoomId(int roomId);
    }
}

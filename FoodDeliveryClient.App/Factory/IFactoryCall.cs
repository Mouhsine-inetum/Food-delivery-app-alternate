namespace FoodDeliveryClient.App.Factory
{
    public interface IFactoryCall<T>
    {
        Task<bool> DeleteAsync(string resource);
        Task<IList<T>> GetAsync(string resource);
        Task<T> GetIdAsync(string resource);
        Task<bool> PostAsync(string path, T resource);
    }
}
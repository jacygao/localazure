namespace Emulator.Providers.StoreProvider.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string? message) : base(message)
        {
        }
    }
}

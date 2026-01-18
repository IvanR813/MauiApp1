namespace MauiApp1.Services
{
    public interface IWalletService
    {
        decimal GetBalance();
        void TopUp(decimal amount);
        bool Pay(decimal amount);
    }
}

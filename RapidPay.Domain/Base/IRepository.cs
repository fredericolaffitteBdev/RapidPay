namespace RapidPay.Domain
{
    public interface IRepository
    {
        public IUnitOfWork UnitOfWork { get; }
    }
}

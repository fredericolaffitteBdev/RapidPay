using RapidPay.Domain.Card;

namespace RapidPay.Infra.Repositories
{
    public class CardRepository : BaseRepository<CardData>, ICardRepository
    {
        public CardRepository(Context context) : base(context) { }
    }
}

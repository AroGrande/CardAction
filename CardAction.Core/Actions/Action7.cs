using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action7 : IAction
{
    public string ActionName => "ACTION7";

    public bool CanBeExecutedOnCard(CardDetails card) 
        => (card.CardStatus is CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active) && !card.IsPinSet
                   || (card.CardStatus == CardStatus.Blocked && card.IsPinSet);
}

using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action8 : IAction
{
    public string ActionName => "ACTION8";

    public bool CanBeExecutedOnCard(CardDetails card)
        => card.CardStatus is CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active or CardStatus.Blocked;
}
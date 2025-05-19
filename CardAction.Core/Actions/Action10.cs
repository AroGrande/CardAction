using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action10 : IAction
{
    public string ActionName => "ACTION10";

    public bool CanBeExecutedOnCard(CardDetails card) => card.CardStatus is CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active;
}

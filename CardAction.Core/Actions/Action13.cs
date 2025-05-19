using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action13 : IAction
{
    public string ActionName => "ACTION13";

    public bool CanBeExecutedOnCard(CardDetails card) => card.CardStatus is CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active;
}

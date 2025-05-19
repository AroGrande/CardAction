using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action11 : IAction
{
    public string ActionName => "ACTION11";

    public bool CanBeExecutedOnCard(CardDetails card) => card.CardStatus is CardStatus.Inactive or CardStatus.Active;
}

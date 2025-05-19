using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action2 : IAction
{
    public string ActionName => "ACTION2";

    public bool CanBeExecutedOnCard(CardDetails card) => card.CardStatus == CardStatus.Active;
}

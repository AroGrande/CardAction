using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action1 : IAction
{
    public string ActionName => "ACTION1";

    public bool CanBeExecutedOnCard(CardDetails card) => card.CardStatus == CardStatus.Active;
}

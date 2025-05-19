using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action5 : IAction
{
    public string ActionName => "ACTION5";

    public bool CanBeExecutedOnCard(CardDetails card) => card.CardType == CardType.Credit;
}

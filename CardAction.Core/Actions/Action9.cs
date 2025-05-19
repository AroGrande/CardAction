using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action9 : IAction
{
    public string ActionName => "ACTION9";

    public bool CanBeExecutedOnCard(CardDetails card) => true;
}

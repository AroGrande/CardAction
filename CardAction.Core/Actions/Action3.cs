using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action3 : IAction
{
    public string ActionName => "ACTION3";

    public bool CanBeExecutedOnCard(CardDetails card) => true;
}

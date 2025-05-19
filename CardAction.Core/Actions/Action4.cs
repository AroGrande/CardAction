using CardAction.Core.Models;

namespace CardAction.Core.Actions;

public class Action4 : IAction
{
    public string ActionName => "ACTION4";

    public bool CanBeExecutedOnCard(CardDetails card) => true;
}

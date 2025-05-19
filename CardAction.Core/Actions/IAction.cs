using CardAction.Core.Models;

namespace CardAction.Core.Actions;
public interface IAction
{
    string ActionName { get; }

    bool CanBeExecutedOnCard(CardDetails card);
}

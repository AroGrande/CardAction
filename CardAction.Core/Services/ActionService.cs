using CardAction.Core.Actions;
using CardAction.Core.Models;

namespace CardAction.Core.Services;
public class ActionService
{
    private readonly IEnumerable<IAction> _actions;

    public ActionService(IEnumerable<IAction> actions)
    {
        _actions = actions;
    }

    public List<string> GetAvailableActions(CardDetails card)
    {
        if (_actions == null || !(_actions.Any()))
        {
            throw new InvalidOperationException("No actions available");
        }

        var availableActions = _actions
            .Where(action => action.CanBeExecutedOnCard(card))
            .Select(action => action.ActionName)
            .ToList();

        return availableActions;
    }
}

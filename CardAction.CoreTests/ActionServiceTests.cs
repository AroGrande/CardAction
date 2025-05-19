using CardAction.Core.Actions;
using CardAction.Core.Models;
using CardAction.Core.Services;
using Xunit;

namespace CardAction.CoreTests;

public class ActionServiceTests
{
    private static readonly List<IAction> AllActions =
        [
            new Action1(), new Action2(), new Action3(), new Action4(), new Action5(), new Action6(), new Action7(),
            new Action8(), new Action9(), new Action10(), new Action11(), new Action12(), new Action13()
        ];

    private static ActionService CreateService() => new(AllActions);

    [Fact]
    public void GetAvailableActions_PrepaidClosed_Returns_3_4_9()
    {
        var card = new CardDetails("X1", CardType.Prepaid, CardStatus.Closed, false);
        var expected = new[] { "ACTION3", "ACTION4", "ACTION9" };
        var service = CreateService();

        var result = service.GetAvailableActions(card);

        Assert.Equal(expected.OrderBy(x => x), result.OrderBy(x => x));
    }

    [Fact]
    public void GetAvailableActions_CreditBlocked_PinSet_Returns_3_4_5_6_7_8_9()
    {
        var card = new CardDetails("X2", CardType.Credit, CardStatus.Blocked, true);
        var expected = new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION7", "ACTION8", "ACTION9" };
        var service = CreateService();

        var result = service.GetAvailableActions(card);

        Assert.Equal(expected.OrderBy(x => x), result.OrderBy(x => x));
    }

    [Fact]
    public void GetAvailableActions_CreditBlocked_NoPin_Returns_3_4_5_8_9()
    {
        var card = new CardDetails("X3", CardType.Credit, CardStatus.Blocked, false);
        var expected = new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9" };
        var service = CreateService();

        var result = service.GetAvailableActions(card);

        Assert.Equal(expected.OrderBy(x => x), result.OrderBy(x => x));
    }
}

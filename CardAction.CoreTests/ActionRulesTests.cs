using CardAction.Core.Actions;
using CardAction.Core.Models;
using Xunit;

namespace CardAction.CoreTests;

public class ActionRulesTests
{
    #region Helpers
    private static CardDetails Card(CardType type, CardStatus status, bool pin) => new("X1", type, status, pin);
    #endregion

    [Theory]
    [InlineData(CardStatus.Active, true)]
    [InlineData(CardStatus.Inactive, false)]
    [InlineData(CardStatus.Ordered, false)]
    public void Action1_rule(CardStatus status, bool expected)
    {
        var action = new Action1();

        var result = action.CanBeExecutedOnCard(Card(CardType.Debit, status, false));
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(CardStatus.Ordered, true)]
    [InlineData(CardStatus.Inactive, true)]
    [InlineData(CardStatus.Active, true)]
    [InlineData(CardStatus.Blocked, true)]
    [InlineData(CardStatus.Restricted, false)]
    [InlineData(CardStatus.Expired, false)]
    public void Action6_requires_pin_and_status(CardStatus status, bool expected)
    {
        var withPin = Card(CardType.Prepaid, status, true);
        var withoutPin = Card(CardType.Prepaid, status, false);

        var action = new Action6();

        Assert.Equal(expected, action.CanBeExecutedOnCard(withPin)); 
        Assert.False(action.CanBeExecutedOnCard(withoutPin));
    }

    [Theory]
    [InlineData(CardStatus.Ordered, false, true)]
    [InlineData(CardStatus.Inactive, false, true)]
    [InlineData(CardStatus.Active, false, true)]
    [InlineData(CardStatus.Blocked, true, true)]
    [InlineData(CardStatus.Blocked, false, false)]
    [InlineData(CardStatus.Restricted, false, false)]
    public void Action7_rule(CardStatus status, bool pin, bool expected)
    {
        var action = new Action7();

        var result = action.CanBeExecutedOnCard(Card(CardType.Credit, status, pin));
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Action5_only_credit()
    {
        var action = new Action5();

        Assert.False(action.CanBeExecutedOnCard(Card(CardType.Debit, CardStatus.Active, true)));
        Assert.True(action.CanBeExecutedOnCard(Card(CardType.Credit, CardStatus.Active, true)));
    }
}
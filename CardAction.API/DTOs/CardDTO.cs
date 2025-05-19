using CardAction.Core.Models;

namespace CardAction.API.DTOs;

public record CardDTO(string CardNumber,
    CardType CardType,
    CardStatus CardStatus,
    bool IsPinSet,
    List<string> AvailableActions);

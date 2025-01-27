namespace SaanSoft.Cqrs.Messages;

/// <summary>
/// You should never directly inherit from this interface
/// use <see cref="IMessage{TMessageId}"/> instead
/// </summary>
public interface IMessage
{
    /// <summary>
    /// Used to track related commands/events/queries.
    /// Should be propagated between related messages.
    ///
    /// The initial message could be populated by services such as Azure AppInsights, OpenTelemetry,
    /// Http header (e.g. "X-Request-Id"), or a simple guid (as string)
    /// </summary>
    string? CorrelationId { get; set; }

    /// <summary>
    /// Who triggered the command/event/query (eg UserId, third party (eg Auth0) Id)
    /// Should be propagated between related messages
    /// </summary>
    string? AuthenticationId { get; set; }

    /// <summary>
    /// When the command/event/query was raised.
    /// When running events in order, use MessageOnUtc to run them in the correct order
    /// </summary>
    DateTime MessageOnUtc { get; set; }

    /// <summary>
    /// FullName for the type of the event
    /// </summary>
    string TypeFullName { get; set; }

    /// <summary>
    /// Whether the message is being replayed or not
    /// </summary>
    bool IsReplay { get; set; }
}

/// <summary>
/// Base interface with common properties for all messages
/// You should never directly inherit from IMessage
/// Use <see cref="ICommand{TMessageId}"/>, <see cref="IEvent{TMessageId, TEntityKey}"/> or <see cref="IQuery{TMessageId, TQuery, TResponse}"/> instead
/// </summary>
public interface IMessage<TMessageId> : IMessage where TMessageId : struct
{
    /// <summary>
    /// Unique Id for the command/event/query
    /// This will normally be the EventStore (or CommandStore and QueryStore if using) primary key
    /// Also used to populate the TriggeredById property of any subsequent messages it raises
    /// </summary>
    TMessageId Id { get; set; }

    /// <summary>
    /// Record if this message was triggered by another command/event/query
    /// Should be populated by the initiating command/event/query/message Id
    /// Similar to CorrelationId, it provides a way to track messages through the system
    /// </summary>
    TMessageId? TriggeredById { get; set; }
}

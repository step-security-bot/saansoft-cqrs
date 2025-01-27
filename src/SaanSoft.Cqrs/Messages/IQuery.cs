namespace SaanSoft.Cqrs.Messages;

/// <summary>
/// You should never directly inherit from this interface
/// use <see cref="IQuery{TMessageId, TQuery, TResponse}"/> instead
/// </summary>
public interface IQuery : IMessage
{
}

/// <summary>
/// You should never directly inherit from this interface
/// use <see cref="IQuery{TMessageId, TQuery, TResponse}"/> instead
/// </summary>
public interface IQuery<TMessageId> : IMessage<TMessageId>, IQuery
    where TMessageId : struct
{
}

/// <summary>
/// You should never directly inherit from this interface
/// use <see cref="IQuery{TMessageId, TQuery, TResponse}"/> instead
/// </summary>
public interface IQuery<TQuery, TResponse> : IQuery
    where TQuery : IQuery<TQuery, TResponse>
    where TResponse : IQueryResponse
{
}

public interface IQuery<TMessageId, TQuery, TResponse> : IQuery<TMessageId>, IQuery<TQuery, TResponse>
    where TMessageId : struct
    where TQuery : IQuery<TMessageId, TQuery, TResponse>
    where TResponse : IQueryResponse
{
}

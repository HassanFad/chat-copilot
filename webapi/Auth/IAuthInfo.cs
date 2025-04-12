// Copyright (c) Microsoft. All rights reserved.

namespace CopilotChat.WebApi.Auth;

/// <summary>
/// Defines the interface for authenticated user information.
/// </summary>
public interface IAuthInfo
{
    /// <summary>
    /// The authenticated user's unique ID.
    /// </summary>
    public string UserId { get; }

    /// <summary>
    /// The authenticated user's name.
    /// </summary>
    public string Name { get; }
}

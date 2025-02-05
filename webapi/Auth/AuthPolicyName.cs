// Copyright (c) Microsoft. All rights reserved.

namespace CopilotChat.WebApi.Auth;

/// <summary>
/// Holds the policy names for custom authorization policies.
/// </summary>
public static class AuthPolicyName
{
    /// <summary>
    /// Policy name for requiring chat participant authorization.
    /// </summary>
    public const string RequireChatParticipant = "RequireChatParticipant";
}

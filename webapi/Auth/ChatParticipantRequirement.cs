// Copyright (c) Microsoft. All rights reserved.

using Microsoft.AspNetCore.Authorization;

namespace CopilotChat.WebApi.Auth;

/// <summary>
/// Used to require the chat to be owned by the authenticated user.
/// </summary>
public class ChatParticipantRequirement : IAuthorizationRequirement
{
    // This class is intentionally left empty as it serves as a marker for the authorization requirement.
}

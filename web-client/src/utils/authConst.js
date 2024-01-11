export const IDENTITY_CONFIG = {
    authority: process.env.REACT_APP_AUTH_URL,
    client_id: process.env.REACT_APP_IDENTITY_CLIENT_ID,
    redirect_uri: process.env.REACT_APP_REDIRECT_URL,
    silent_redirect_uri: process.env.REACT_APP_SILENT_REDIRECT_URL,
    post_logout_redirect_uri: process.env.REACT_APP_LOGOFF_REDIRECT_URL,
    audience: process.env.REACT_APP_AUDIENCE,
    response_type: "code",
    response_mode: "query",
    automaticSilentRenew: false,
    loadUserInfo: true,
    scope: "openid profile api1.full_access",
}

export const METADATA_OIDC = {
    issuer: process.env.REACT_APP_ISSUER,
    jwks_uri: "https://chatauth.local/.well-known/openid-configuration/jwks",
    authorization_endpoint: "https://chatauth.local/connect/authorize",
    token_endpoint: "https://chatauth.local/connect/token",
    userinfo_endpoint: "https://chatauth.local/connect/userinfo",
    end_session_endpoint: "https://chatauth.local/connect/endsession",
    check_session_iframe: "https://chatauth.local/connect/checksession",
    revocation_endpoint: "https://chatauth.local/connect/revocation",
    introspection_endpoint: "https://chatauth.local/connect/introspect",
}
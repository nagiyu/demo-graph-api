namespace Sample;

/// <summary>
/// Azure AD アプリ登録の設定値。
/// Azure Portal > アプリの登録 から取得した値を設定してください。
/// </summary>
internal static class AuthConfig
{
    /// <summary>
    /// アプリケーション (クライアント) ID
    /// </summary>
    public const string ClientId = "YOUR_CLIENT_ID";

    /// <summary>
    /// ディレクトリ (テナント) ID
    /// マルチテナントの場合は "common" を指定
    /// </summary>
    public const string TenantId = "YOUR_TENANT_ID";

    /// <summary>
    /// 要求するアクセス許可スコープ
    /// </summary>
    public static readonly string[] Scopes = ["User.Read", "Mail.Read", "Mail.Read.Shared"];
}

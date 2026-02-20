using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Sample
{
    public partial class Form1 : Form
    {
        private GraphServiceClient? _graphClient;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblStatus.Text = "状態: ログイン中...";
            rtbInfo.Clear();

            try
            {
                var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions
                {
                    ClientId = AuthConfig.ClientId,
                    TenantId = AuthConfig.TenantId,
                    RedirectUri = new Uri("http://localhost"),
                });

                _graphClient = new GraphServiceClient(credential, AuthConfig.Scopes);

                var me = await _graphClient.Me.GetAsync();

                rtbInfo.Text =
                    $"表示名       : {me?.DisplayName}\n" +
                    $"UPN          : {me?.UserPrincipalName}\n" +
                    $"メール       : {me?.Mail}\n" +
                    $"ユーザー ID  : {me?.Id}";

                lblStatus.Text = "状態: ログイン成功";
                btnLogout.Enabled = true;
                btnGetMailFolders.Enabled = true;
                btnGetSharedFolders.Enabled = true;
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "状態: ログインがキャンセルされました";
                btnLogin.Enabled = true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "状態: エラー";
                rtbInfo.Text = ex.Message;
                btnLogin.Enabled = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _graphClient = null;
            rtbInfo.Clear();
            lblStatus.Text = "状態: ログアウトしました";
            btnLogin.Enabled = true;
            btnLogout.Enabled = false;
            btnGetMailFolders.Enabled = false;
            btnGetSharedFolders.Enabled = false;
        }

        private async void btnGetMailFolders_Click(object sender, EventArgs e)
        {
            if (_graphClient == null) return;

            btnGetMailFolders.Enabled = false;
            lblStatus.Text = "状態: メールフォルダ取得中...";
            rtbInfo.Clear();

            try
            {
                var lines = new List<string>();
                await AppendMailFoldersAsync(parentId: null, depth: 0, lines, userEmail: null);
                rtbInfo.Text = string.Join("\n", lines);
                lblStatus.Text = $"状態: {lines.Count} フォルダ取得完了";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "状態: エラー";
                rtbInfo.Text = ex.Message;
            }
            finally
            {
                btnGetMailFolders.Enabled = true;
            }
        }

        private async void btnGetSharedFolders_Click(object sender, EventArgs e)
        {
            if (_graphClient == null) return;

            var sharedEmail = txtSharedMailbox.Text.Trim();
            if (string.IsNullOrEmpty(sharedEmail))
            {
                lblStatus.Text = "状態: 共有メールボックスのアドレスを入力してください";
                return;
            }

            btnGetSharedFolders.Enabled = false;
            lblStatus.Text = $"状態: {sharedEmail} のフォルダ取得中...";
            rtbInfo.Clear();

            try
            {
                var lines = new List<string>();
                await AppendMailFoldersAsync(parentId: null, depth: 0, lines, userEmail: sharedEmail);
                rtbInfo.Text = string.Join("\n", lines);
                lblStatus.Text = $"状態: {sharedEmail} — {lines.Count} フォルダ取得完了";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "状態: エラー";
                rtbInfo.Text = ex.Message;
            }
            finally
            {
                btnGetSharedFolders.Enabled = true;
            }
        }

        private async Task AppendMailFoldersAsync(string? parentId, int depth, List<string> lines, string? userEmail)
        {
            MailFolderCollectionResponse? response;

            if (parentId == null)
            {
                response = userEmail == null
                    ? await _graphClient!.Me.MailFolders.GetAsync(req => req.QueryParameters.Top = 100)
                    : await _graphClient!.Users[userEmail].MailFolders.GetAsync(req => req.QueryParameters.Top = 100);
            }
            else
            {
                response = userEmail == null
                    ? await _graphClient!.Me.MailFolders[parentId].ChildFolders.GetAsync(req => req.QueryParameters.Top = 100)
                    : await _graphClient!.Users[userEmail].MailFolders[parentId].ChildFolders.GetAsync(req => req.QueryParameters.Top = 100);
            }

            if (response?.Value == null) return;

            var indent = new string(' ', depth * 2);
            foreach (var folder in response.Value)
            {
                lines.Add($"{indent}{folder.DisplayName} (未読: {folder.UnreadItemCount}, 合計: {folder.TotalItemCount})");
                if (folder.ChildFolderCount > 0)
                {
                    await AppendMailFoldersAsync(folder.Id, depth + 1, lines, userEmail);
                }
            }
        }
    }
}

using Azure.Identity;
using Microsoft.Graph;

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
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "状態: ログインがキャンセルされました";
                btnLogin.Enabled = true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"状態: エラー";
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
        }
    }
}

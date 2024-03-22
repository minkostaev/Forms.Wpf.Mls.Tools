namespace Forms.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.Models;
using Forms.Wpf.Mls.Tools.Services;

public partial class Requests : UserControl
{
    public Requests()
    {
        InitializeComponent();

        var methods = new List<RequestMethod>
        {
            RequestMethod.GET,
            RequestMethod.POST,
            RequestMethod.PUT,
            RequestMethod.DELETE
        };

        cbMethod.DataSource = methods;
        cbMethod.SelectedIndexChanged += delegate
        {
            var method = (RequestMethod)cbMethod.SelectedValue!;
            switch (method)
            {
                case RequestMethod.GET:
                    txtInBody.Visible = false;
                    txtOutResult.Visible = true;
                    break;
                case RequestMethod.POST:
                    txtInBody.Visible = true;
                    txtOutResult.Visible = true;
                    break;
                case RequestMethod.PUT:
                    txtInBody.Visible = true;
                    txtOutResult.Visible = true;
                    break;
                case RequestMethod.DELETE:
                    txtInBody.Visible = false;
                    txtOutResult.Visible = false;
                    break;
            }
        };
        cbMethod.SelectedIndex = 1;
        cbMethod.SelectedIndex = 0;
        lblResult.Text = "...";

        btnSend.Click += async delegate
        {
            lblResult.Text = "...";
            var requestManager = new RequestManager();
            var response = await requestManager.SendRequest(txtUrl.Text, (RequestMethod)cbMethod.SelectedValue, txtInBody.Text);
            txtOutResult.Text = response.Content;
            lblResult.Text = $"Response Code: {response.Name} ({response.Code}).";
        };

    }
}
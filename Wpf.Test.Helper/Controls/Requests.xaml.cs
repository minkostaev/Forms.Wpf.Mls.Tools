namespace Wpf.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.Models;
using Forms.Wpf.Mls.Tools.Services;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

/// <summary>
/// Interaction logic for Requests.xaml
/// </summary>
public partial class Requests : UserControl
{
    public Requests()
    {
        InitializeComponent();

        this.Background = new SolidColorBrush(Colors.LightGray);

        var methods = new List<RequestMethod>
        {
            RequestMethod.GET,
            RequestMethod.POST,
            RequestMethod.PUT,
            RequestMethod.DELETE
        };

        cbMethod.ItemsSource = methods;
        cbMethod.SelectionChanged += delegate
        {
            var method = (RequestMethod)cbMethod.SelectedValue;
            switch (method)
            {
                case RequestMethod.GET:
                    txtInBody.Visibility = System.Windows.Visibility.Collapsed;
                    txtOutResult.Visibility = System.Windows.Visibility.Visible;
                    break;
                case RequestMethod.POST:
                    txtInBody.Visibility = System.Windows.Visibility.Visible;
                    txtOutResult.Visibility = System.Windows.Visibility.Visible;
                    break;
                case RequestMethod.PUT:
                    txtInBody.Visibility = System.Windows.Visibility.Visible;
                    txtOutResult.Visibility = System.Windows.Visibility.Visible;
                    break;
                case RequestMethod.DELETE:
                    txtInBody.Visibility = System.Windows.Visibility.Collapsed;
                    txtOutResult.Visibility = System.Windows.Visibility.Collapsed;
                    break;
            }
        };
        cbMethod.SelectedIndex = 0;
        tbResult.Text = "...";

        btnSend.Click += async delegate
        {
            tbResult.Text = "...";
            var requestManager = new RequestManager();
            var response = await requestManager.SendRequest(txtUrl.Text, (RequestMethod)cbMethod.SelectedValue, txtInBody.Text);
            txtOutResult.Text = response.Content;
            tbResult.Text = $"Response Code: {response.Name} ({response.Code}).";
        };

    }

}
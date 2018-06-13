using Hleb.Classes.DTO;
using Hleb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hleb
{
    /// <summary>
    /// Логика взаимодействия для BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        VKAPI vKAPI = new VKAPI();
        RegistrationWindow window = new RegistrationWindow();
        public BrowserWindow()
        {
            InitializeComponent();
        }
        public event Action<User> VkUser;
      
        string _redirectPage;
        private void GetUser(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(uri).Result;
                var friendsResponse = JsonConvert.DeserializeObject<Response>(result);
                User user = friendsResponse.Users[0];
                
               
            }
        }

        private void webBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString().StartsWith(_redirectPage))
            {

                vKAPI.AuthorizationRedirect(e.Uri);
                //нужно вернуть имя этого юзера в текстбокс окна регистрации
                var user = vKAPI.GetFriends();
                VkUser?.Invoke(user);
                //Name?.Invoke(user.Name);
                //window.textBoxname.Text = user.Name;
            
                Close();

            }

        }

        public void NavigateTo(string page, string redirectPage)
        {
            _redirectPage = redirectPage;
            webBrowser.Navigate(page);

           
        }
    }
}

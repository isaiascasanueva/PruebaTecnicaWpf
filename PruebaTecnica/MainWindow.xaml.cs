using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace PruebaTecnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result result = new Result();
            Peticiones peticiones = new Peticiones();
            peticiones.Url = "https://api.github.com/users";
            Task<string> res = peticiones.ExecuteRequest(result);

            if (result.Correct) {

                List<GitUsers> gitUsers = JsonConvert.DeserializeObject<List<GitUsers>>(res.Result);

                int Contador = 0;

                foreach (var user in gitUsers)
                {

                    txtLabel.Text = user.avatar_url + "|" + user.events_url + "|" + user.following_url + "|" + user.gists_url;
                    Contador++;

                    if (Contador == 10)
                    {

                        break;
                    }
                }

            }


            txtLabel.Text = "Datos";

        }


    }
}

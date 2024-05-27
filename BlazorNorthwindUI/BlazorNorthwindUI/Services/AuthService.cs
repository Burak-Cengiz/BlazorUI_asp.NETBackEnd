
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using BlazorNorthwindUI.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace BlazorNorthwindUI.Services
{
    public class AuthService : IAuthService
    {

        private HttpClient _httpClient;
        ILocalStorageService _localStorage;
        ISessionStorageService _sessionStorage;
        public bool IsLoggedIn { get; set; }
        public AuthService(HttpClient httpClient,ILocalStorageService localStorage,ISessionStorageService sessionStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _sessionStorage = sessionStorage;
        }

        public async Task Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44333/api/auth/login", loginModel);
            
            if (!String.IsNullOrEmpty(response.ToString()))

            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenObject = JObject.Parse(content);
                var token = tokenObject["token"].ToString();
                //await _localStorage.SetItem("token", token);
                
                await _sessionStorage.SetItemAsync("token", token);

                IsLoggedIn = true;

                
            }
            
            

        }

        public async Task Logout()

        {

            await _sessionStorage.RemoveItemAsync("token");

            IsLoggedIn = false;

        }

        private async Task SetAuthorizationHeader()
        {
            if(!_httpClient.DefaultRequestHeaders.Contains(name:"Authorization"))
            {
                var token = await _sessionStorage.GetItemAsync<string>("token");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", parameter: token);
            }
        }
    }
}

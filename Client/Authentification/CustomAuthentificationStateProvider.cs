using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Data;
using Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Client.Authentification
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    { 
        private readonly IJSRuntime jsRuntime;
        private readonly IUsersData userService;

    private Users cachedUser;

    public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUsersData userService) {
        this.jsRuntime = jsRuntime;
        this.userService = userService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        var identity = new ClaimsIdentity();
        if (cachedUser == null) {
            string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userAsJson)) {
                Users tmp = JsonSerializer.Deserialize<Users>(userAsJson);
                ValidateLogin(tmp.UserName, tmp.Password);
            }
        } else {
            identity = SetupClaimsForUser(cachedUser);
        }

        ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
    }

    public void ValidateLogin(string username, string password) {
        Console.WriteLine("Validating log in");
        if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
        if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

        ClaimsIdentity identity = new ClaimsIdentity();
        try {
            Users user = userService.ValidateUsers(username, password);
            identity = SetupClaimsForUser(user);
            string serialisedData = JsonSerializer.Serialize(user);
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
            cachedUser = user;
        } catch (Exception e) {
            throw e;
        }

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
    }

    public void Logout() {
        cachedUser = null;
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    private ClaimsIdentity SetupClaimsForUser(Users user) {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        claims.Add(new Claim("Password",user.Password));
        claims.Add(new Claim("IsAdmin", user.IsAdmin.ToString()));
        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
        return identity;
    }
    }
}
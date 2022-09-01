# Before Starting Development

Run The Following Commands on "Package Manager Console":

```
dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>" --project Bloggie

dotnet user-secrets set "Authentication:Google:ClientSecret" "<client-secret>" --project Bloggie

dotnet user-secrets set "EmailUserName" "<email-username>" --project Bloggie

dotnet user-secrets set "EmailPassword" "<email-password>" --project Bloggie
```

### Useful Links
https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows

https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=visual-studio

https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-6.0
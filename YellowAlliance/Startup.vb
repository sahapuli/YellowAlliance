Imports Owin
Imports Microsoft.Owin.Security.Cookies

Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        'this will establish the security with cookies as management of the token and security
        'the .loginpath isn't really being used here, but I kept it here for future enhancements
        'the expire time span sets the cookie to expire in 5 minutes



        'temporarily turning this off
        'app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
        '    .AuthenticationType = "ApplicationCookie",
        '    .LoginPath = New Microsoft.Owin.PathString("/login.html"),
        '    .ExpireTimeSpan = TimeSpan.FromMinutes(5)
        '})
    End Sub
End Class

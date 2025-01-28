using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Auth;

[SuppressMessage("ReSharper", "CommentTypo")]
public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Comprobar si existe la cabecera "Authorization"
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return await Task.FromResult(AuthenticateResult.NoResult());
        }

        var authorizationHeader = Request.Headers["Authorization"].ToString();
        
        // Validar que esté en formato BAsic <base64>
        if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
            return await Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
        }

        var token = authorizationHeader.Substring("Basic ".Length).Trim();
        
        // Decodificar base64
        string decodedCredentials;
        try
        {
            var credentialBytes = Convert.FromBase64String(token);
            decodedCredentials = Encoding.UTF8.GetString(credentialBytes);
        }
        catch
        {
            return await Task.FromResult(AuthenticateResult.Fail("Invalid base64 string"));
        }
        
        // Separar en username:password
        var parts = decodedCredentials.Split(':', 2);
        if (parts.Length != 2)
        {
            return await Task.FromResult(AuthenticateResult.Fail("Invalid credentials"));
        }
        
        var username = parts[0];
        var password = parts[1];
        
        // Validar usuario/contraseña
        bool isValidUser = (username == "admin" && password == "admin");
        
        if (!isValidUser)
        {
            return await Task.FromResult(AuthenticateResult.Fail("Invalid username or password"));
        }
        
        // Si es valido creamos la identidad y los claims
        var claims = new[]
        {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, username)
        };
        var identity = new System.Security.Claims.ClaimsIdentity(claims, Scheme.Name);
        var principal = new System.Security.Claims.ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        
        // Retornar exito
        return await Task.FromResult(AuthenticateResult.Success(ticket));
    }
}

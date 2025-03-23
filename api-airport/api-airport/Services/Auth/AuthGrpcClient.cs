using Auth;
using Grpc.Net.Client;

namespace api_airport.Services.Auth;

public class AuthGrpcClient
{
    private readonly AuthService.AuthServiceClient _client;

    public AuthGrpcClient(string grpcServerUrl)
    {
        var channel = GrpcChannel.ForAddress(grpcServerUrl);
        _client = new AuthService.AuthServiceClient(channel);
    }

    public async Task<ValidateTokenResponse> ValidateTokenAsync(string token)
    {
        var request = new ValidateTokenRequest { Token = token };
        return await _client.ValidateTokenAsync(request);
    }
}

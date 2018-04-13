public class BaseRequestH
{
    public string apiKey {get; set;}
    public string nameRequest {get; set;}
    public string accessToken {get; set;}
    public BaseRequestH(string apiKey, string nameRequest, string accessToken)
    {
        this.apiKey = apiKey;
        this.nameRequest = nameRequest;
        this.accessToken = accessToken;
    }
}
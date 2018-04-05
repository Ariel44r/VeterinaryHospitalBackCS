class LoginResponseC : BaseResponse 
{
    public string user {get; set;}
    public string password {get; set;}
    public LoginResponseC(double codeResponse, string message, string user, string password)
    {
        this.user = user;
        this.password = password;
        this.codeResponse = codeResponse;
        this.message = message;
    }
}
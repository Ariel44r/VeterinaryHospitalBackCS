class BadResponse : BaseResponse 
{
    public BadResponse(double codeResponse, string message)
    {
        this.codeResponse = codeResponse;
        this.message = message;
    }
}
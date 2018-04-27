using Microsoft.AspNetCore.Http;

struct Localizable
{
    public static string env = "Development";
    public static string lang = "Eng";
    public static string apiKey = "api-key-VeterinaryHospital-web-dev";
    public static string connectionString = "Server=localhost;Database=VeterinaryHospital;User Id=SA;Password=Etaigual120pi";
}

class Environment
{
    string enviromnment;
    bool production;
    string apiKey;
    public Environment()
    {
        this.enviromnment = Localizable.env;
        this.production = (this.enviromnment == "Production");
        this.apiKey = Localizable.apiKey;
    }

    public bool validateApiKey(string apiKey)
    {
        return (this.apiKey == apiKey);
    }

    public bool isInProduction()
    {
        return this.production;
    }
}

class S : Environment
{
    public string genericMessage;
    public string successAccess;
    public string notGrantedPrivileges;
    public string connectionString;
    public string currentQuery;
    public S()
    {

        this.successAccess = "success access";
        this.notGrantedPrivileges = "You don't have granted privileges";
        this.connectionString = Localizable.connectionString;  
        this.currentQuery = "SELECT * FROM tableTest;";      
        if(this.isInProduction())
        {
            //Variables on Production Environment
            this.genericMessage = "";
        } else {
            //variables on development environment
            this.genericMessage = "Hola Mamá!";
        }
    }
    public BaseRequestH parseHeaders(IHeaderDictionary headerDict)
    {
        return new BaseRequestH(headerDict["apiKey"], headerDict["nameRequest"], headerDict["accessToken"]);
    }
}

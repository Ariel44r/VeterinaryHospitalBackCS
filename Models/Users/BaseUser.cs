class BaseUser {
    public string user_Name {get; set;}
    public string password {get; set;}

    public BaseUser(string user_Name, string password) {
        this.user_Name = user_Name;
        this.password = password;
    }
}
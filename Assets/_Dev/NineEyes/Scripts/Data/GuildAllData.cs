using Grandora.Heimdall;

[System.Serializable]
public class GuildAllData : NetworkData
{
    public override string UserId => "";
}
[System.Serializable]
public struct GuildRequest
{
    public string name;
}
[System.Serializable]
public class GuildResponse
{
    public GameUser user;
    public string token;
}

public class GuildAcceptRequestResponse : GuildAllData
{
    public string title;
    public string content;
}

[System.Serializable]
public class GuildData
{
    public string id;
    public string name;
    public string email;
    public string userType;
    public string lls;
    public string token;
}
export class FileSystem 
{

    public static Save(name: string, value: string): void 
    {
        var date = new Date();
        date.setTime(date.getTime() + (24 * 60 * 60 * 1000));
        var expires = "expires=" + date.toUTCString();

        document.cookie = name + "=" + value + ";" + expires;
    }

    public static Get(name: string): string 
    {
        var cname = name + "=";
        var cookie = document.cookie.split(";");

        for (var i = 0; i < cookie.length; i++) 
        {
            while (cookie[i].charAt(0) == ' ') 
            {
                cookie[i] = cookie[i].substring(1);
            }

            if (cookie[i].indexOf(cname) == 0) 
            {
                return cookie[i].substring(cname.length, cookie[i].length);
            }
        }

        return "";
    }
}
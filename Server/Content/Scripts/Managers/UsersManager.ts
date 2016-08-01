import { User } from '../DataTypes/User';
import { FileSystem } from './Tools/FileSystem';

export class UsersManager
{
    private static _accessToken: string = "";
    private static _accessTokenKey: string = "AccessToken";
    public static get AccessToken(): string
    {
        return UsersManager._accessToken;
    }
    public static get IsAuth(): boolean
    {
        if ("" == UsersManager.AccessToken)
        {
            var token = FileSystem.Get(UsersManager._accessTokenKey)
            if (null == token)
                token = "";

            UsersManager._accessToken = token;

            return "" != UsersManager.AccessToken;
        }
        else
        {
            return true;
        }
    }

    public static SignUp(email: string, password: string): Promise<string>
    {
        return new Promise<string>((resolve, reject) =>
        {
            $.post("/api/Users/SignUp",
                {
                    email: email,
                    password: password
                })
                .done((accessToken: string) =>
                {
                    UsersManager._accessToken = accessToken;
                    if ("" == accessToken)
                        reject(null);

                    resolve(accessToken);
                })
                .fail(() =>
                {
                    UsersManager._accessToken = "";
                    reject(null);
                })
                .always(() =>
                {
                    UsersManager.Save();
                });
        });
    }
    public static LogIn(email: string, password: string): Promise<string>
    {
        return new Promise<string>((resolve, reject) =>
        {
            $.get("/api/Users/LogIn",
                {
                    email: email,
                    password: password
                })
                .done((accessToken: string) =>
                {
                    UsersManager._accessToken = accessToken;
                    if ("" == accessToken)
                        reject(null);

                    resolve(accessToken);
                })
                .fail(() =>
                {
                    UsersManager._accessToken = "";
                    reject(null);
                })
                .always(() =>
                {
                    UsersManager.Save();
                });
        });
    }
    public static async Get(): Promise<User>
    {
        return new Promise<User>((resolve, reject) =>
        {
            $.get("/api/Users/Get",
                {
                    accessToken: UsersManager.AccessToken
                })
                .done((response: string) =>
                {
                    if ("" == response)
                        reject(null);

                    resolve(<User>JSON.parse(response));
                })
                .fail(() =>
                {
                    reject(null);
                })
        });
    }
    public static Logout(): void
    {
        UsersManager._accessToken = "";
        UsersManager.Save();
    }
    public static Load(): void
    {
        UsersManager.IsAuth;
    }
    private static Save(): void
    {
        FileSystem.Save(UsersManager._accessTokenKey, UsersManager._accessToken);
    }

    static ChangePassword(password: string): Promise<boolean>
    {
        return new Promise<boolean>((resolve, reject) =>
        {
            $.post("./Users/ChangePassword",
                {
                    accessToken: UsersManager.AccessToken,
                    password: password
                })
                .done((response: string) =>
                {
                    resolve(<boolean>JSON.parse(response));
                })
                .fail(() =>
                {
                    reject(null);
                });
        });
    }
    static ResetPassword(email: string): Promise<boolean>
    {
        return new Promise<boolean>((resolve, reject) =>
        {
            $.post("./Users/ResetPassword",
                {
                    email: email
                })
                .done((response: string) =>
                {
                    if ("" != response)
                        reject(null);

                    console.log(response);
                    resolve(true);
                })
                .fail(function ()
                {
                    reject(null);
                });
        });
    }
    static JoinToSquad(key: string): Promise<boolean>
    {
        return new Promise<boolean>((resolve, reject) =>
        {
            $.post("api/Users/JoinToSquad",
                {
                    accessToken: UsersManager.AccessToken,
                    key: key
                })
                .done(function ()
                {
                    resolve(true);
                })
                .fail(function ()
                {
                    reject(false);
                });
        });
    }
}
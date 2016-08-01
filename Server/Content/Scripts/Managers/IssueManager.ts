import { Issue } from '../DataTypes/Issues/Issue';
import {UsersManager} from './UsersManager';

export class IssueManager
{
    public static All(): Promise<Array<Issue>>
    {
        return new Promise<Array<Issue>>((resolve, reject) =>
        {
            $.get("./Issues/All",
                {
                    accessToken: UsersManager.AccessToken,
                })
                .done((response: string) =>
                {
                    resolve(<Array<Issue>>JSON.parse(response));
                })
                .fail(() =>
                {
                    reject(null);
                });
        });
    }
    public static MyIssues(): Promise<Array<Issue>>
    {
        return new Promise<Array<Issue>>((resolve, reject) =>
        {
            $.get("./Issues/MyIssues",
                {
                    accessToken: UsersManager.AccessToken,
                })
                .done((response: string) =>
                {
                    resolve(<Array<Issue>>JSON.parse(response));
                })
                .fail(() =>
                {
                    reject(null);
                });
        });
    }
    public static Get(Id: number): Promise<Issue>
    {
        return new Promise<Issue>((resolve, reject) =>
        {
            $.get("./Issues/Get",
                {
                    accessToken: UsersManager.AccessToken,
                    Id: Id
                })
                .done((response: string) =>
                {
                    resolve(<Issue>JSON.parse(response));
                })
                .fail(() =>
                {
                    reject(null);
                });
        });
    }

    public static Add(issue: Issue): Promise<Issue>
    {
        return new Promise<Issue>((resolve, reject) =>
        {
            $.post("./Issues/Add",
                {
                    accessToken: UsersManager.AccessToken,
                    issue: issue
                })
                .done((response: string) =>
                {
                    resolve(<Issue>JSON.parse(response));
                })
                .fail(() =>
                {
                    reject(null);
                });
        });
    }
    public static Edit(issue: Issue): Promise<Issue>
    {
        return new Promise<Issue>((resolve, reject) =>
        {
            $.post("./Issues/Edit",
                {
                    accessToken: UsersManager.AccessToken,
                    issue: issue
                })
                .done((response: string) =>
                {
                    resolve(<Issue>JSON.parse(response));
                })
                .fail(() =>
                {
                    reject(null);
                });
        });
    }
    public static Remove(id: number): Promise<boolean>
    {
        return new Promise<boolean>((resolve, reject) =>
        {
            $.post("./Issues/Remove",
                {
                    accessToken: UsersManager.AccessToken,
                    id: id
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

}
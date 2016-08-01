import { Squad } from '../DataTypes/Squad';
import { UsersManager } from './UsersManager';
import { FileSystem } from './Tools/FileSystem';

export class SquadManager
{
    public static Squad: Squad;

    static Add(name: string, key: string): Promise<Squad>
    {
        return new Promise<Squad>((resolve, reject) =>
        {
            let squad = new Squad();
            squad.Key = key;
            squad.Name = name;

            $.post("/api/Squads/Add",
                {
                    accessToken: UsersManager.AccessToken,
                    squad: squad
                })
                .done(function (response: string) 
                {
                    if ("" == response)
                        reject(null);

                    let squad = <Squad>JSON.parse(response);
                    SquadManager.Squad = squad;

                    resolve(squad);
                })
                .fail(function ()
                {
                    reject(null);
                });
        });
    }

    static Get(): Promise<Squad>
    {
        return new Promise<Squad>((resolve, reject) =>
        {
            $.get("./Squads/Get",
                {
                    accessToken: UsersManager.AccessToken,
                })
                .done((response: string) =>
                {
                    if ("" == response)
                        reject(null);

                    let squad = <Squad>JSON.parse(response);
                    SquadManager.Squad = squad;

                    resolve(squad);
                })
                .fail(function ()
                {
                    reject(null);
                });
        });
    }


    static async Edit(squad: Squad): Promise<{}>
    {
        return new Promise(() =>
        {
            $.post("./Squads/Edit", { squad: squad })
                .done(() => { })
                .fail(() => { })
        });
    }


    static Remove(id: number): Promise<{}>
    {
        return new Promise(() =>
        {
            $.post("./Squads/Remove", { id: id })
                .done(() => { })
                .fail(() => { })
        });
    }
} 
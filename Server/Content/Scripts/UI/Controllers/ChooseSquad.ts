/// <reference path="../../typings/tsd.d.ts"/>

import { SquadManager } from '../../Managers/SquadManager';
import { UsersManager } from '../../Managers/UsersManager';
import { Squad } from '../../DataTypes/squad';

export class ChooseSquadController
{
    SquadID: number;
    SquadKey: string;
    SquadForCreateOrEdit: Squad;
    SquadName: string;

    static $inject = ["$rootScope", "$location"];

    constructor(private $rootScope: ng.IRootScopeService, private $location: ng.ILocationService)
    {
        this.SquadKey = "";
        this.SquadID = 0;
        this.SquadForCreateOrEdit;
        this.SquadName = "";

        UsersManager.Load();
    }

    public async JoinSquad(): Promise<void>
    {
        await UsersManager.JoinToSquad(this.SquadKey);
        try
        {
            this.$location.path("/profile");
            this.$rootScope.$applyAsync();
        }
        catch (error)
        {
            console.log("Die Ts.");

            this.$location.path("/auth/choose");
            this.$rootScope.$applyAsync();
        }
    }

    public async CreateSquad(): Promise<void>
    {
        await SquadManager.Add(this.SquadName, this.SquadKey);
        this.$location.path("/profile");
        this.$rootScope.$applyAsync();
        //try
        //{
        //    //this.$location.path("/profile");
        //    //this.$rootScope.$applyAsync();
        //}
        //catch (error)
        //{
        //    console.log("Die Ts.");

        //    this.$location.path("/auth/choose");
        //    this.$rootScope.$applyAsync();
        //}

    }
}
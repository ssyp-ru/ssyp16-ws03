/// <reference path="../../typings/tsd.d.ts"/>

import { UsersManager } from '../../Managers/UsersManager';
import { User } from '../../DataTypes/User';

import { FileSystem } from '../../Managers/Tools/FileSystem';
import { Alert } from '../Tools/Alert';

export class LoginController
{

    public Email: string;
    public Password: string;

    static $inject = ["$rootScope", "$location"];
    constructor(private $rootScope: ng.IRootScopeService, private $location: ng.ILocationService)
    {
        this.Email = "";
        this.Password = "";
    }

    public async Login(): Promise<void>
    {
        //console.log(this.Email, this.Password);

        var self = this;
        try
        {
            if (!(("" == this.Email) || (undefined == this.Email)))
            {
            //console.log(" lol ");
            var token = await UsersManager.LogIn(this.Email, this.Password);

            self.$location.path("/profile");
            self.$rootScope.$applyAsync();
            }
            else
            {
                console.log("SSSSSempai notice me");
                Alert.Error("Email is not correct!");
            }

        }
        catch (error)
        {
            console.log("Die TS.lol");
        }
    }

    public async ResetPassword(email: string): Promise<void>
    {
         try
        {
            if (!(("" == this.Email) || (undefined == this.Email)))
            {
                var success = await UsersManager.ResetPassword(this.Email);        
            }
            else
            {
                Alert.Error("Email is not correct!");
            }

        }
        catch (error)
        {
            console.log("Die TS.lol");
        }
 
        console.log(success);
    }
}
/// <reference path="../../typings/tsd.d.ts"/>

import { UsersManager } from '../../Managers/UsersManager';
import { User } from '../../DataTypes/User';
import { Alert } from '../Tools/Alert';

export class SignUpController
{
    public Email: string;
    public Password: string;

    static $inject = ["$rootScope", "$location"];
    constructor(private $rootScope: ng.IRootScopeService, private $location: ng.ILocationService)
    {
        this.Email = "";
        this.Password = "";
    }

    public async SignUp(): Promise<void>
    {
        console.log(this.Email, this.Password);
        try
        {
            if (!(("" == this.Email) || (undefined == this.Email)))
            {
                var token = await UsersManager.SignUp(this.Email, this.Password);
                console.log(token);

                this.$location.path("/auth/choose");
                this.$rootScope.$applyAsync();
            }
            else
            {
                console.log("SSSSSempai notice me");
                Alert.Error("Email is not correct!");
            }
               
        }
        catch (error)
        {
            console.log("Die TS.");
        }
    }
}

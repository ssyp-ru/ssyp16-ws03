/// <reference path="../typings/tsd.d.ts"/>
import { UsersManager } from '../Managers/UsersManager';

import { SignUpController  } from "./Controllers/SignUp";
import { LoginController  } from "./Controllers/Login";
import { AuthController  } from "./Controllers/Auth";
import { ProfileController  } from "./Controllers/Profile";
// import { SquadController  } from "./Controllers/Squad";
// import { SprintController  } from "./Controllers/Sprint";
import { ChooseSquadController  } from "./Controllers/ChooseSquad";
import { IssueController  } from "./Controllers/Issue";

var IFKApp = angular.module("IFKApp", ["ngRoute"]);

IFKApp.controller("SignUpCtrl", SignUpController);
IFKApp.controller("LoginCtrl", LoginController);
IFKApp.controller("AuthCtrl", AuthController);
IFKApp.controller("ProfileCtrl", ProfileController);
// IFKApp.controller("SquadCtrl", SquadController);
// IFKApp.controller("SprintCtrl", SprintController);
IFKApp.controller("ChooseSquadCtrl", ChooseSquadController);
IFKApp.controller("IssueCtrl", IssueController);

IFKApp.config(routeConfig);

routeConfig.$inject = ["$routeProvider"];
function routeConfig($routeProvider: ng.route.IRouteProvider): void
{
    $routeProvider
        .when("/profile/",
        {
            templateUrl: "/Partial/Profile"
        })
        .when("/auth/",
        {
            templateUrl: "/Partial/Auth"
        })
        .when("/auth/login",
        {
            templateUrl: "/Partial/Login"
        })
        .when("/auth/signup",
        {
            templateUrl: "/Partial/SignUp"
        })
        .when("/auth/choose",
        {
            templateUrl: "/Partial/ChooseSquad"
        })
        .when("/issue",
        {
            templateUrl: "/Partial/Issue"
        })
        .when("/issue/:issueId",
        {
            templateUrl: "/Partial/Issue"
        })
        .otherwise("/profile");
    // .when("/profile/logout",
    // {
    //     templateUrl:"/.html",
    // })
    // .when("/profile/issue",
    // {
    //     templateUrl:"/.html",
    // })
    // .when("/profile/squad",
    // {
    //     templateUrl:"/.html",
    // })
    // .when("/profile/squad/sprint",
    // {
    //     templateUrl:"/.html",
    // })
    // .when("/profile/squad/backlog",
    // {
    //     templateUrl:"/.html",
    // })
    // .when("/profile/squad/members",
    // {
    //     templateUrl:"/.html",
    // })
    // .when("/profile/auth",
    // {
    //     templateUrl:"/.html",
    // })
    // .when("/profile/auth/signup",
    // {
    //     templateUrl:"/Views/SignUp.cshtml",
    // })
    // .when("/profile/auth/signup/choosesquad",
    // {
    //     templateUrl:"/.html",
    // })
    //  .when("/profile/auth/login",
    // {
    //     templateUrl:"/Views/Login.cshtml",
    // })
}

export function Logout()
{
    UsersManager.Logout();
}
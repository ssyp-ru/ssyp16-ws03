import { UsersManager } from '../../Managers/UsersManager';
import { User } from '../../DataTypes/User';
import { NotificationManager } from '../../Managers/NotificationsManagers';
import { Notification } from '../../DataTypes/Notifications/Notification';
import { Issue } from '../../Datatypes/Issues/Issue';
import { IssueManager } from '../../Managers/IssueManager';
import { Status } from '../../Datatypes/Issues/Status';
import { Priority } from '../../Datatypes/Issues/Priority';
import { Squad } from '../../Datatypes/Squad';
import { SquadManager } from '../../Managers/SquadManager';

export class ProfileController
{
    private Inited: boolean;

    public Squad: Squad;
    public User: User;
    public Issues: Array<Issue>;
    public NewPassword: string;

    static $inject = ["$scope", "$rootScope", "$location"];
    constructor(private $scope: ng.IScope, private $rootScope: ng.IRootScopeService, private $location: ng.ILocationService)
    {
        UsersManager.Load();

        this.Inited = false;
        this.Squad = null;
        this.User = null;
        this.Issues = [];
        this.NewPassword = "";
    }

    public async Init(): Promise<void>
    {
        if (!this.Inited)
        {
            this.Inited = true;
            if (!UsersManager.IsAuth)
            {
                this.$location.path("/auth");
                this.$rootScope.$applyAsync();
            }
            else 
            {
                this.Squad = await SquadManager.Get();
                console.log(this.Squad);
                this.User = await UsersManager.Get();
                console.log(this.User);
                this.Issues = this.GetIssues(await IssueManager.MyIssues());
                console.log(this.Issues);
                this.$scope.$applyAsync();
            }
        }
    }
    private GetIssues(issues: Array<Issue>): Array<Issue>
    {
        //return issues;
        var work: Array<Issue> = new Array<Issue>();

        for (let issue of issues)
        {
            if (Status.Backlog != issue.Status && Status.Closed != issue.Status) 
            {
                work.push(issue);
            }
        }

        return work;
    }
    public AddIssue(): void
    {
        this.$location.path("/issue");
        this.$rootScope.$applyAsync();
    }
    public SelectIssue(Id: number): void
    {
        this.$location.path("/issue/" + Id);
        this.$rootScope.$applyAsync();
    }
    public async ChangePassword(): Promise<void>
    {
        await UsersManager.ChangePassword(this.NewPassword);
    }

    public GetPriority(priority: Priority): string
    {
        switch (priority)
        {
            case Priority.Must:
                return 'highPriority';
            case Priority.Should:
                return 'middlePriority';
            case Priority.Maybe:
                return 'lowPriority';
            default: return "";
        }
    }

    public Logout(): void
    {
        UsersManager.Logout();

        this.$location.path("/auth");
        this.$rootScope.$applyAsync();
    }
}
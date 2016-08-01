
import { Issue } from '../../DataTypes/Issues/Issue';
import { Priority } from '../../DataTypes/Issues/Priority';
import { Status } from '../../DataTypes/Issues/Status';
import { User } from '../../DataTypes/User';
import { Squad } from '../../DataTypes/Squad';
import { IssueManager } from '../../Managers/IssueManager';
import { SquadManager } from '../../Managers/SquadManager';
import { UsersManager } from '../../Managers/UsersManager';

export interface IIssueParams extends ng.route.IRouteParamsService {
    issueId?: number;
}
export class IssueController {
    public Issue: Issue;
    public IsNew: boolean;
    public IsMyIssue: boolean;
    public Squad: Squad;
    public User: User;
    public CurrentUser: User;

    static $inject = ["$scope", "$rootScope", "$location", "$routeParams"];
    constructor(
        private $scope: ng.IScope,
        private $rootScope: ng.IRootScopeService,
        private $location: ng.ILocationService,
        private $routeParams: IIssueParams) {
        UsersManager.Load();
        if (null == $routeParams.issueId) {
            this.Issue = new Issue();
            this.IsNew = true;
        }
        else {
            this.IsNew = false;

            let self = this;
            IssueManager.Get($routeParams.issueId).then((issue) => {
                self.Issue = issue;
                self.SelectUser();
                self.$scope.$applyAsync();
            });
            UsersManager.Get().then((user)=>{
                self.CurrentUser = user;
                self.SelectUser();
                self.$scope.$applyAsync();
            })
        }
        let self = this;
        SquadManager.Get().then((squad) => {
            console.log(squad);
            self.Squad = squad;
            self.SelectUser();
            self.$scope.$applyAsync();
        });
    }
    public SelectUser(): void {
        if (this.IsNew || null == this.Squad || null == this.Issue) {
            return;
        }

        for (let user of this.Squad.Composition) {
            if (user.ID == this.Issue.UserID) {
                this.User = user;
                break;
            }
        }
        if (null != this.CurrentUser){
            this.IsMyIssue = this.CurrentUser.ID == this.User.ID;
        }

    }
    public GetPriority(priority: Priority | string): string {
        priority = <Priority>parseInt(<string>priority);
        switch (priority) {
            case Priority.Maybe:
                return "Maybe";
            case Priority.Should:
                return "Should";
            case Priority.Must:
                return "Must";
        }
    }
    public GetStatus(status: Status | string): string {
        status = <Status>parseInt(<string>status);
        switch (status) {
            case Status.Backlog:
                return "Backlog";
            case Status.Started:
                return "Started";
            case Status.InProgress:
                return "In progress";
            case Status.Testing:
                return "Testing";
            case Status.Done:
                return "Done";
            case Status.Closed:
                return "Closed";
        }
    }

    public async Add(): Promise<void> {
        console.log(this.Issue);
        let issue = await IssueManager.Add(this.Issue);
        this.$location.path("/issue/" + issue.ID);
        this.$rootScope.$applyAsync();
    }
    public async Remove(): Promise<void> {
        await IssueManager.Remove(this.Issue.ID);
        this.Back();
    }
    public Back(): void {
        this.$location.path("/profile");
        this.$rootScope.$applyAsync();
    }
    public async Edit(): Promise<void> {
        this.$scope.$applyAsync();
        await IssueManager.Edit(this.Issue);
        this.Back();
    }
    // public async EditText(): Promise<void>
    // {
    //     this.TextForEdit = this.IssueForEdit.Description;
    //     await $.get("./Profile/OneIssue/EditText", { Description: this.TextForEdit })

    //         .done(function ()
    //         {
    //             this.IssueForEdit.Description = this.TextForEdit;
    //         });
    // }

    // public async PointsForIssue(): Promise<void>
    // {
    //     await $.get("./Profile/OneIssue/POintsPerIssue", { Points: this.PointsPerIssue })

    //         .done(function ()
    //         {
    //             this.IssueForEdit.Points = this.PointsPerIssue;
    //         });
    // }

    // public async WorkerOfTheIssues(): Promise<void>
    // {
    //     await $.post("./Profile/OneIssue/WorkerOfIssues", { User: this.WorkerOfIssues })

    //         .done(function ()
    //         {
    //             this.IssueForEdit.User = this.WorkerOfIssues;
    //         });
    // }

    // public async Remove(): Promise<void>
    // {
    //     this.IssueForEdit.Cost = null;
    //     this.IssueForEdit.Description = "";
    //     this.IssueForEdit.ID = null;
    //     this.IssueForEdit.Name = "";
    //     this.IssueForEdit.Priority = null;

    //     await $.post("./Profile/OneIssue/Remove", { Issue: this.IssueForEdit })
    // }
}
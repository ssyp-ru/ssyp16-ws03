import { Issue } from "../../Datatypes/Issues/Issue"
import { Status } from "../../Datatypes/Issues/Status"

import { SquadManager } from "../../Managers/SquadManager"

export class SprintController
{
    public Issues: Issue[];

    constructor() {
        //this.Issues = 
    }

      public get IssuesCompleted() : Issue[]
    {
        return this.getIssues(issue => issue.PriorityStatus == Status.Done);
    }

    public get IssueOpen() : Issue[] 
    {
        return this.getIssues(issue => issue.PriorityStatus == Status.Started);
    }

    public get IssueInProgress() : Issue[]
    {
        return this.getIssues(issue => issue.PriorityStatus == Status.InProgress);
    }

    private getIssues(sort : (Issue)=>boolean) : Issue[] 
    {
        var issues = [];
        for(var i = 0; i < this.Issues.length; i++) 
        {
            if(sort(this.Issues[i])) 
            {
                issues.push(this.Issues[i]);
            }
        }

        return issues;
    }
}
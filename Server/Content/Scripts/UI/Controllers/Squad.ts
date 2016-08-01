import { User } from "../../Datatypes/User";
import { Issue } from "../../Datatypes/Issues/Issue";
import { Status } from "../../Datatypes/Issues/Status";

import { SquadManager } from "../../Managers/SquadManager"

export class SquadController
{
    public Users: User[];
    public Issues: Issue[];

    constructor() 
    {
        //this.Users = 
        //this.Issue = 
    }     

    public get GetSprint() : Issue[]
    {
        var issues = [];
        for(var i = 0; i < this.Issues.length; i++) 
        {
            if(this.Issues[i].ProgressStatus > Status.NotStarted) 
            {
                issues.push(this.Issues[i]);
            }
        }

        return issues;
    }

}
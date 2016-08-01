import { BaseDataType } from './BaseDataType';
import { Issue } from './Issues/Issue';
import { Notification } from './Notifications/Notification';
import { Sprint } from './Sprint';
import { User } from './User';

export class Squad extends BaseDataType
{
    public Key: string;
    public Name: string;
    public Description: string;

    public Composition: Array<User>;
    public Issues: Array<Issue>;

    public constructor()
    {
        super();
        this.Key = "";
        this.Name = "";
        this.Description = "";

        this.Composition = new Array<User>();
        this.Issues = new Array<Issue>();
    }
}
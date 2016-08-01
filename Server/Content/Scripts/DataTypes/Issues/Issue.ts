import { BaseDataType } from '../BaseDataType';
import { Status } from './Status';
import { Priority } from './Priority';
import { User } from '../User';

export class Issue extends BaseDataType
{
    public Key: string;
    public Name: string;
    public Description: string;
    public UserID: number;
    public User: User;
    public Priority: Priority;
    public Cost: number;
    public Status: Status;

    public constructor()
    {
        super();
        this.Key = "";
        this.Name = "";
        this.Description = "";
        this.UserID = 0;
        this.User = null;
        this.Priority = Priority.Should;
        this.Cost = 0;
        this.Status = Status.Backlog;
    }
}
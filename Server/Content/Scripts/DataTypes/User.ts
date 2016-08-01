import { BaseDataType } from './BaseDataType';

export class User extends BaseDataType
{
    public Name: string;
    public Email: string;
    public Password: string;
    public Points: number;
    public AccessToken: string;

    public constructor()
    {
        super();
        this.Name = "";
        this.Email = "";
        this.Password = "";
        this.Points = 0;
        this.AccessToken = "";
    }
}
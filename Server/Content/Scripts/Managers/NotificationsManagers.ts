import { User } from '../DataTypes/User';
import { Notification } from '../DataTypes/Notifications/Notification';


export class NotificationManager
{
     static CreateByUser(Content : string, user : User) : Promise<Notification>
    {
        return new Promise<Notification>((resolve, reject) =>
        {

            $.post("./Notification/CreateByUser", { Content : Content, user : user })

            .done( function (notification : Notification)
            {
                resolve ( notification );    
            })
            .fail( function()
            { 
                reject ( null );
            });
        });
    }
    
    
    static CreateByProgram(Content : string) : Promise<Notification>
    {
        return new Promise<Notification>((resolve, reject) =>
        {
            $.post("./Notification/CreateByProgram", { Content : Content })
            .done( function (notification : Notification)
            {
                resolve ( notification );    
            })
            .fail( function()
            {
                reject ( null );
            });
        });
    }
}
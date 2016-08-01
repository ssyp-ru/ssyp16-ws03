import { User } from '../User';
import { NotificationTypes } from './NotificationTypes';

export class Notification
{
    ID : number; 
    Content : string;
    Sender : User;
    NotificationType = NotificationTypes.Comment;

}
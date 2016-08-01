/// <reference path="../../typings/tsd.d.ts"/>

export class Alert
{
    public static Success(text: string): void
    {
        Materialize.toast(text, 4000, "green");
    }
    public static Warning(text: string): void
    {
        Materialize.toast(text, 4000, "yellow");
    }
    public static Error(text: string): void
    {
        Materialize.toast(text, 4000, "red");
    }
}
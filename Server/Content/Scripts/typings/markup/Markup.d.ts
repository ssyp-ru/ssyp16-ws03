declare namespace Restoman.Restomania.Markup {
    enum AlertType {
        Info = 1,
        Warning = 2,
        Error = 3,
        Success = 4,
        Loading = 5,
    }
    class AlertButton {
        Name: string;
        Method: () => void;
    }
    class Alert {
        Text: string;
        Buttons: Array<AlertButton>;
        Type: AlertType;
        private _modal;
        constructor(text: string, type: AlertType, buttons?: Array<AlertButton>);
        Show(): JQuery;
        Hide(): void;
        private Remove();
        private CreateModal();
        private static TypeToColor(type);
        private static TypeToTitle(type);
    }
}
declare namespace Restoman.Restomania.Markup {
    class Loading {
        static ShowFull(): void;
        static HideFull(): void;
        static ShowPage(): void;
        static HidePage(): void;
    }
}
interface JQuery {
    ShowLoader(fullscreen?: boolean): void;
    HideLoader(): void;
}
declare namespace Restoman.Restomania.Markup {
    class Notifications {
        private static showTime;
        private static Notify(message, icon, color);
        static Info(message: string): void;
        static Success(message: string): void;
        static Warning(message: string): void;
        static Error(message: string): void;
    }
}
interface JQuery {
    InitRating(maxValue: number): JQuery;
    RatingValue(value?: number): number;
}
declare namespace Restoman.Restomania.Markup {
    function SetFixedNavPos(): void;
    function SetNavPosFinal(): void;
}
interface JQuery {
    Pickatime(options: PickatimeOptions): void;
}
interface PickatimeOptions {
    default?: string;
    fromnow?: number;
    donetext?: string;
    autoclose?: boolean;
    ampmclickable?: boolean;
    darktheme?: boolean;
    twelvehour?: boolean;
    vibrate?: boolean;
}

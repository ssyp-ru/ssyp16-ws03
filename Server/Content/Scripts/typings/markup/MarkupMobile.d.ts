declare namespace Restoman.Restomania.Mobile.Markup {
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
        static Show(settings: Alert): JQuery;
        static Hide(modal: JQuery): void;
        Text: string;
        Buttons: AlertButton[];
        Type: AlertType;
    }
}
interface JQuery {
    ShowBottomBar(): void;
}
interface JQuery {
    ShowBottomControl(): void;
    HideBottomControl(): void;
}
interface JQuery {
    ShowBottomModal(callback?: () => void): void;
    HideBottomModal(): void;
}
declare namespace Restoman.Restomania.Mobile.Markup {
    function InitFields(parentSelecter: string): void;
    function InitBottomControl(): void;
    function InitSelect(): void;
    function InitCollapse(): void;
    function InitReservePanel(parentSelecter: string, callback: (success: boolean) => void): void;
    function InitBottomBar(parentSelecter: string): void;
    function CenterReserveSlider(parentSelector: string): void;
    function CenterSchedule(parentSelector: string): void;
}
declare namespace Restoman.Restomania.Mobile.Markup {
    function ShowLoader(callback?: () => void): void;
    function HideLoader(): void;
}

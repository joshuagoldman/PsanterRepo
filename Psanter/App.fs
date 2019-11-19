module App

open Elmish
open Fable.React
open Elmish
open Definitions

let initMainPageInfo = 

let init() : State = MainPage()

let update (msg : Msg) (state : State) = 
    match msg with
    | New(page) -> ""
    | Ongoing(page) -> ""
    | DoIntro(page) -> ""
    | PlayLeftOrRight(parts) -> ""
    | PlayPart(compositionInfo) -> ""

let view (state : State) (dispatch : Msg -> unit) = div [] []

Program.mkSimple init update view
|> Program.withReactSynchronous "elmish-app"
|> Program.run
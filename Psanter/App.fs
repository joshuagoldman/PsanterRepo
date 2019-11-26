module App

open Elmish.React
open Fable.React
open Definitions

let InitControls =
    seq [
            ChooseGenreComboBoxAppearance ;
            MuteButton ;
            MainMenuDiv
        ]

let initActivity = 
    BackgroundMusic({Value = "MusicSource"})

let init() : State = 
    {
        PageActivity = initActivity  ;
        PageInfo = InitControls ;
        PageName = "MainMenu"
    }

let update (msg : Msg) (state : State) = 
    match msg with
    | MusicGenreClicked(music) -> 
        match music with    
        | Classic(comp) -> 
            {state with PageActivity = Classic(comp)}
        | Pop(comp) -> 
            {state with PageActivity = Pop(comp)}
        | BoogiWoogie(comp) -> 
            {state with PageActivity = BoogiWoogie(comp)}
        | NoMusic(comp) -> 
            {state with PageActivity = NoMusic(comp)}
        | BackgroundMusic(comp) -> 
            {state with PageActivity = BackgroundMusic(comp)}

    | PlayLeftOrRight(parts) -> 
        { state with state.PageActivity = music}
        

    | PlayPart(compositionInfo) -> ""

let view (state : State) (dispatch : Msg -> unit) = div [] []

Program.mkSimple init update view
|> Program.withReactSynchronous "elmish-app"
|> Program.run
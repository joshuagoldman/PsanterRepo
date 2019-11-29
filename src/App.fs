module App

open Elmish.React
open Fable.React
open Elmish
open Definitions
open Controls
open MainMenu
open MusicData
open ExercisePage

let init() : State = 
    {
        PageActivity = allMusicPieces |> Seq.item(0) ;
        PageInfo = initPages ;
        PageName = "MainMenu"
    }

let update (msg : Msg) (state : State) = 
    match msg with
    | HoverOverGenreButton(opacity) -> 
        {state with
            PageInfo = { state.PageInfo with
                          MainMenu =
                            { state.PageInfo.MainMenu with
                               MainDivButton =
                                { state.PageInfo.MainMenu.MainDivButton with
                                   Opacity = opacity }}}}

    | MutButtonClicked(pic,mute) -> 
        {state with
            PageInfo = { state.PageInfo with
                          MainMenu =
                            { state.PageInfo.MainMenu with
                               MuteButton =
                                { state.PageInfo.MainMenu.MuteButton with
                                   Picture = pic ; MuteMusic = mute }}}}

    | GenreChosen(stateNew) -> stateNew

    | MusicGenreClicked(music) -> 
        state

    | PlayLeftOrRight(parts) -> 
        state
        

    | PlayPart(compositionInfo) -> 
        state

let render (state : State) (dispatch : Msg -> unit) = 
    match state.PageName with
    | "MainMenu" -> MainMenuPage state dispatch
    | "ExercisePage" -> exercisePage state dispatch
    | _ -> MainMenuPage state dispatch
    



Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
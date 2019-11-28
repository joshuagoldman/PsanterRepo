module MainMenu

open Definitions
open Controls
open Fable.React.Standard
open Fable.React
open Fable.React.Props

let MainMenuPage ( state : State) (dispatch : Msg -> unit) =
    header [classList [ "Header", true ] ]
        [
            div [ ClassName "row"]
                [
                     button
                        [
                            ClassName "MainDivButton" 
                            Props.Style[ 
                                            Color state.PageInfo.MainMenu.MainDivButton.Color ; 
                                            BorderRadius "15px" ;
                                            Padding("1em 2em") ;
                                            Width("40%")
                                            Float "center"]
                            OnClick (fun _ -> if state.PageInfo.MainMenu.MainDivButton.Color = "red" 
                                              then MainMenuButtonClicked("blue")
                                              else MainMenuButtonClicked("red") 
                                              |> dispatch
                                              )
                        ]

                        [
                            
                        ]
                ]
            
        ]

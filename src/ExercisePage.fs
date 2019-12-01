module ExercisePage

open Definitions
open Controls
open Fable.React.Standard
open MusicData
open Fable.React
open Fable.React.Props
open Feliz
open System

let compositions =
    seq [
            { Duration = 1.0 ;
              Notes =  TwinkleLittleStarLeftHand }
            { Duration = 1.0 ;
              Notes =  TwinkleLittleStarRightHand }
        ]

let allMusicPieces = 
    seq [
            { Genre = "Pop" ;
              Composition = "Twinkle Twinkle Little Star" ;
              Hand = Parts.Both ;
              Data = compositions ;
              NotesCurrentlyPushed =  compositions 
                                      |> Seq.item(0)
                                      |> fun x -> x.Notes
                                                  |> Seq.item(0)
                                                  |> fun x -> x.NotesPushed}
        ]

let goBackButton (state : State) ( dispatch : Msg -> unit ) = 
    let opacity = state.PageInfo.ExercisePage.GoBackButton.Opacity

    div
        [
        ]
        [
            button
                [
                    Style (List.append (configMuteButtonStyle opacity) 
                                       [Float FloatOptions.Right])

                    OnClick (fun _ -> { state with PageName = "MainMenu" }
                                      |> NewPage
                                      |> dispatch)
                ]
                [
                    str "Go Back"
                ]
        ]

let blackOrWhite ( keyName : string ) =
    seq [ "c#" ; "d#" ; "f#" ; "g#" ; "a#" ]
    |> Seq.tryFind (fun key -> key = keyName)
    |> function 
       | res when res = None -> "white"
       | _ -> "black"

let getKeyColor ( state : State ) 
                ( octave : int )
                ( note : string ) =
    let result =
        state.PageActivity.NotesCurrentlyPushed
        |> Seq.tryFind (fun currNote -> currNote.Octave = octave &&
                                        currNote.Value = note)
        |> function 
           | res when res = None -> blackOrWhite note
           | _ -> "red"
           
    result

let blackKeys ( state : State )
              ( dispatch : Msg -> unit )
              ( info : {| Margin : int ;
                          Note : string ;
                          Octave : int |} ) =
    
    Html.div
        [
            prop.style
                [
                    style.width 20
                    style.height 70
                    style.border("2px", borderStyle.groove , "black")
                    style.backgroundColor (getKeyColor state
                                                       info.Octave
                                                       info.Note)
                    style.display.inlineBlock
                    style.marginRight info.Margin
                ]

            prop.children
                [
                    
                ]
        ]
let whiteKeys ( state : State ) 
              ( dispatch : Msg -> unit )
              ( info : {| Note : string ;
                          Octave : int |} ) =
    
    Html.div
        [
            prop.style
                [
                    style.width 30
                    style.height 120
                    style.border("2px", borderStyle.groove , "black")
                    style.backgroundColor (getKeyColor state
                                                       info.Octave
                                                       info.Note)
                    style.display.inlineBlock
                ]

            prop.children
                [
                    
                ]
        ]

let whiteKeysStyle = 
    prop.style
        [
            style.position.inheritFromParent
            style.margin(80, 20, 0, 15)
        ]

let blackKeysStyle = 
    prop.style
        [
            style.position.inheritFromParent
            style.margin(80, 40, 0, 35)
        ]
    
let piano ( state : State ) ( dispatch : Msg -> unit ) =
    let allWhiteKeys = whiteKeysInfo
                       |> Seq.map (fun info -> whiteKeys state
                                                         dispatch
                                                         info)

    let allBlackKeys = BlackKeysInfo
                       |> Seq.map (fun info -> blackKeys state
                                                           dispatch
                                                           info)
    Html.div
        [
            
            prop.style
                [
                    style.opacity 0.95
                    style.backgroundImage "linear-gradient(#E4A91E,#884E06)"
                    style.height 450
                    style.width 1300
                    style.borderRadius 20
                    style.border("5px", borderStyle.groove , "#130907")
                    style.position.fixedRelativeToWindow
                    style.margin(100, 30, 500, 20)
                ]
            
            prop.children
                [

                    Html.div
                        [
                            whiteKeysStyle
                            prop.children allWhiteKeys
                        ] 

                    Html.div
                        [
                            blackKeysStyle
                            prop.children allBlackKeys
                        ]
                ]
        ]

let exercisePage ( state : State) ( dispatch : Msg -> unit) =

    Html.header
        [
            prop.style
                [
                    style.backgroundImage "url(Pictures/ExercisePagePicture.jpg)"
                    style.backgroundSize.cover
                ]

            prop.children
                [
                   goBackButton state dispatch
                   piano state dispatch
                ]
        ]


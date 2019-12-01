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
            { Genre = "Pop" ; Composition = "Twinkle Twinkle Little Star" ;
              Hand = Parts.Both ;
              Data = compositions }
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

let blackKeys ( state : State )
              ( dispatch : Msg -> unit )
              ( margin : int )=
    
    Html.div
        [
            prop.style
                [
                    style.width 20
                    style.height 70
                    style.border("2px", borderStyle.groove , "black")
                    style.backgroundColor "black"
                    style.display.inlineBlock
                    style.marginRight margin
                ]

            prop.children
                [
                    
                ]
        ]
let whiteKeys ( state : State ) ( dispatch : Msg -> unit ) =
    
    Html.div
        [
            prop.style
                [
                    style.width 30
                    style.height 120
                    style.border("2px", borderStyle.groove , "black")
                    style.backgroundColor "white"
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
    let whiteKeysCodes = [ 1..7 ]
    let allWhiteKeys = Seq.append whiteKeysCodes whiteKeysCodes
                       |> Seq.append whiteKeysCodes
                       |> Seq.append whiteKeysCodes
                       |> Seq.append whiteKeysCodes
                       |> Seq.append whiteKeysCodes
                       |> Seq.map (fun _ -> whiteKeys state dispatch)
    
    let blackKeysCodes = [ 10 ; 41 ; 9 ; 9 ; 41]
    let allBlackKeys = Seq.append blackKeysCodes [ 10 ; 41 ; 9 ; 9 ; 0] 
                       |> Seq.append blackKeysCodes
                       |> Seq.append blackKeysCodes
                       |> Seq.append blackKeysCodes
                       |> Seq.append blackKeysCodes
                       |> Seq.map (fun margin -> blackKeys state
                                                           dispatch
                                                           margin)
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


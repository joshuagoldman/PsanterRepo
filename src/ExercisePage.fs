module ExercisePage

open Definitions
open Controls
open Fable.React.Standard
open MusicData
open Fable.React
open Fable.React.Props
open System

let compositions =
    seq [
            { Duration = 1.0 ;
              Notes =  TwinkleLittleStarRightHand }
        ]

let allMusicPieces = 
    seq [
            { Genre = "Pop" ; Composition = "Twinkle Twinklw Little Star" ;
              Hand = Parts.Both ;
              Data = compositions|> Seq.item(0)}
        ]

let exercisePage ( state : State) ( dispatch : Msg -> unit) =
    
    header
        [
            Props.Style
                [
                    BackgroundImage "Pictures/ExercisePagePicture"
                ]
        ]
        [
            
        ]


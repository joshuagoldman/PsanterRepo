module MainMenu

open Definitions
open Controls
open Fable.React.Standard
open Fable.React
open Fable.React.Props
open System

let configMainMenuButtonStyle ( opacity : string) = 
    Props.Style[ 
                    BorderRadius "50px"
                    Height "20%"
                    Padding("10em") 
                    Width("fit-content")
                    Padding "5px"
                    Background "radial-gradient(circle at 0px 0px, #E4A91E 0%, #884E06 100%)" 
                    Opacity opacity
                    FontSize "25px"
                    FontWeight "bold"
                    BorderWidth "5px"
                    BorderColor "black"
                    Margin "1.5em 1em 0.5em 0.5em"
                    FontFamily "Comic Sans MS, Comic Sans, cursive"
                    Outline "none"]

let configMuteButtonStyle ( opacity : string) = 
    Props.Style[ 
                    BorderRadius "50px"
                    Height "10%"
                    Padding("10em") 
                    Width("fit-content")
                    Padding "5px"
                    Background "radial-gradient(circle at 0px 0px, #E4A91E 0%, #884E06 100%)" 
                    Opacity opacity
                    FontSize "15px"
                    FontWeight "bold"
                    BorderWidth "5px"
                    BorderColor "black"
                    Margin "1.5em 1em 0.5em 0.5em"
                    FontFamily "Comic Sans MS, Comic Sans, cursive"
                    Outline "none"]

let selectOpacity (xPos : float) (yPos : float) =
   let xCnst = 1349.0
   let yCnst = 694.0
   let x = xPos / xCnst
   let y = 1.0 - yPos / yCnst
   sqrt( x * x + y * y ) * 0.6 + 0.4|> string

let ChangeMuteIcon (value : string) =
    if value = "Pictures/MutePicture.jpg" ||
       value = ""
    then "Pictures/MusicPicture.jpg" 
    else "Pictures/MutePicture.jpg"

let MuteMusicOrTurnItOn (value : bool) =
    if value = true 
    then false
    else true
        
let createSelectItem ( value : string) ( pos : string) =
    option [
                Value (if pos = "0" then "" else pos)
                Props.Style
                    [
                        AlignContent AlignContentOptions.Center
                        FontSize "15px"
                        FontWeight "bold"
                        Padding("1em 2em")
                        BorderWidth "5px"
                        BorderColor "black"
                    ]
           ] [ str value]

let mutButtonHtml (picture : string)
                  ( configMuteButtonStyle : HTMLAttr)
                  ( muteMusicOrNot : bool)
                  (dispatch : Msg -> unit) =
    button 
     [
         configMuteButtonStyle 

         OnClick (fun _ -> (ChangeMuteIcon picture,
                            MuteMusicOrTurnItOn muteMusicOrNot)
                            |> MutButtonClicked
                            |> dispatch)
                    
     ]
     [
         str "Mute Music"
         div []
             [ 
                 img
                     [ 
                         Src(picture)
                         Props.Style
                             [
                                 Height "30px"
                             ]
                     ]
             ]

     ]

let audioHtml ( muteMusicOrNot : bool ) =
    audio 
        [ 
            AutoPlay true
            Muted muteMusicOrNot
            Loop true
        ]
        [
            source
                [
                    Src "Music/Debussy_Reveie.mp3"
                    Typeof "audio/mpeg"
                ]
        ]

let backgroundVideo = 
    video 
        [
            AutoPlay true
            Loop true
            Muted true
            Props.Style
                [
                    BackgroundSize "cover"
                    Position PositionOptions.Fixed
                    ZIndex "-99"
                ]
        ] 
        [
            source
                [
                    Src "Videos/Fall.mp4"
                    Typeof "video/mp4"
                ]
        ]

let SelectItems (selecteItemsDropDown : seq<string>)  =
    Seq.zip selecteItemsDropDown [0..(selecteItemsDropDown |> Seq.length) - 1]
    |> Seq.map (fun (item,position) -> createSelectItem item (position |> string))

let mainMenuButtons (state : State) (dispatch : Msg -> unit) =
    let selecteItemsDropDown = state.PageInfo.MainMenu.MainDivButton.SelectItems
    let opacity = state.PageInfo.MainMenu.MainDivButton.Opacity
    let MainMenuButtonStyle = configMainMenuButtonStyle opacity
    let mutePicture = state.PageInfo.MainMenu.MuteButton.Picture
    let muteMusicOrNot = state.PageInfo.MainMenu.MuteButton.MuteMusic

    [
        div
            [
                Props.Style 
                    [
                        Position PositionOptions.Relative
                        Float "right"
                    ]
            ]
            [ 
                mutButtonHtml (mutePicture)
                              (configMuteButtonStyle opacity)
                              (muteMusicOrNot)
                              (dispatch)
            ]

        div
            [
                Props.Style 
                    [
                        Margin "1.5em 1em 0.5em 0.5em"
                        Position PositionOptions.Absolute
                        Left "37%"
                        Top "30%"
                    ]
            ]
            [
                   select
                        [
                            MainMenuButtonStyle
                        ]

                        (SelectItems selecteItemsDropDown) ;
               
                   audioHtml muteMusicOrNot
        ] 
    ]

let MainMenuPage ( state : State) (dispatch : Msg -> unit) =


    header 
        [

            OnMouseMove (fun ev -> 
                            HoverOverGenreButton(selectOpacity ev.pageX ev.pageY)
                            |> dispatch)
        ]
        [
            div[]
                (Seq.append [backgroundVideo] (mainMenuButtons state dispatch))
        ] 

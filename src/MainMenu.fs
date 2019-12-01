module MainMenu

open Definitions
open Controls
open MusicData
open MusicLogic
open Fable.React.Standard
open Fable.React
open Fable.React.Props
open System

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
        
let createSelectItem ( value : string ) 
                     ( pos : string )
                     ( state : State )
                     ( dispatch : Msg -> unit ) =
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

let loader (state : State )  = 
        div
            [
                Style
                    [
                        Border "16px solid #f3f3f3" 
                        BorderTop "16px solid #3498db" 
                        BorderRadius "50%"
                        Width "120px"
                        Height "120px"
                        Visibility "hidden"
                        Position PositionOptions.Absolute
                        Left "45%"
                        Top "60%"
                    ]
            ]
            []

let mutButtonHtml ( picture : string )
                  ( configMuteButtonStyle : HTMLAttr )
                  ( muteMusicOrNot : bool )
                  ( dispatch : Msg -> unit ) =
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

let audioHtml ( state : State ) ( dispatch : Msg -> unit) =
    let muteMusicOrNot = state.PageInfo.MainMenu.MuteButton.MuteMusic

    let currentMusicPlayed = 
        if state.PageInfo.MainMenu.MuteButton.BackgroundMusic = ""
        then allMusic |> Seq.item(0)
        else state.PageInfo.MainMenu.MuteButton.BackgroundMusic

    audio 
        [ 
            AutoPlay true
            Muted muteMusicOrNot
            Hidden true
        ]
        [
            source
                [
                    Src "Music/Playlist.mp3"
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

let SelectItems (selecteItemsDropDown : seq<string>)
                ( state : State )
                ( dispatch : Msg -> unit ) =
    Seq.zip selecteItemsDropDown [0..(selecteItemsDropDown |> Seq.length) - 1]
    |> Seq.map (fun (item,position) -> createSelectItem item
                                                        (position |> string)
                                                        state
                                                        dispatch)

let GenreSelectedActions ( state : State )
                         ( dispatch : Msg -> unit ) =
    { state with PageName = "ExercisePage" }
    |> fun newState -> { newState with          
                          PageActivity = 
                            { newState.PageActivity with
                               Data = (getRightMusic newState.PageActivity.Composition)
                            }
                        }
    |> NewPage 
    |> dispatch 

let muteButtonDiv ( state : State) ( dispatch : Msg -> unit ) =
    let mutePicture = state.PageInfo.MainMenu.MuteButton.Picture
    let opacity = state.PageInfo.MainMenu.MainDivButton.Opacity
    let muteMusicOrNot = state.PageInfo.MainMenu.MuteButton.MuteMusic
    [
        div
            [
                Props.Style 
                    [
                        Position PositionOptions.Relative
                        Float FloatOptions.Right
                    ]
            ]
            [ 
                mutButtonHtml (mutePicture)
                              (Style (configMuteButtonStyle opacity))
                              (muteMusicOrNot)
                              (dispatch)
            ]

        audioHtml state dispatch
    ]

let mainMenuButton (state : State) (dispatch : Msg -> unit) =
    let selecteItemsDropDown = state.PageInfo.MainMenu.MainDivButton.SelectItems
    let opacity = state.PageInfo.MainMenu.MainDivButton.Opacity
    let MainMenuButtonStyle = configMainMenuButtonStyle opacity

    div
        [
            Props.Style 
                [
                    Margin "1.5em 1em 0.5em 0.5em"
                    Position PositionOptions.Absolute
                    Right "37%"
                    TextAlign TextAlignOptions.Center
                    Top "30%"
                ]

        ]
        [
               select
                    [
                        Style MainMenuButtonStyle

                        OnChange (fun _ -> 
                                    GenreSelectedActions state
                                                         dispatch)
                    ]

                    (SelectItems selecteItemsDropDown state dispatch) 
    ] 
    
let mainMenuButtons (state : State) (dispatch : Msg -> unit) =
    
    muteButtonDiv state dispatch
    |> List.append [mainMenuButton state dispatch]
    |> List.append [loader state]

let MainMenuPage ( state : State ) ( dispatch : Msg -> unit ) =

    header 
        [

            OnMouseMove (fun ev -> 
                            HoverOverGenreButton(selectOpacity ev.pageX ev.pageY)
                            |> dispatch)
        ]
        [
            div[]
                (mainMenuButtons state dispatch
                |> List.append [backgroundVideo])

            div[] [ str state.PageInfo.MainMenu.MuteButton.BackgroundMusic]
        ] 

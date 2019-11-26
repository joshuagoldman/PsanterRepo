module MainMenuView

open Controls
open Definitions

let GenreAlternatives : seq<Text> = 
    seq[
            { TextVal = "Classic" } ;
            { TextVal = "Pop" } ;
            { TextVal = "BoogieWoogie" }
       ]

let ChooseGenreComboBoxAppearance =
    ComboBox(
                { ID = "ChooseGenreComboBoxAppearance"},
                { AlternativesVal = GenreAlternatives},
                { FontVal = ""},
                { TextSizeVal = ""},
                { FontFamilyVal = ""},
                { VisibleVal = true}
            )

let MuteButton = 
    Button(
            { ID = "MuteButton"},
            { BackgroundColorVal = "" },
            { TextVal = "" },
            { FontVal = "" },
            { TextSizeVal = "" },
            { FontFamilyVal = "" },
            { VisibleVal = true }
          )

let getControl (ctrl : Control) =
    match ctrl with
        | Button(id,color,txt,font,txtSize,fontFamily,visible) ->
            
        | TextArea(id,color,txt,font,txtSize,fontFamily,visible) ->
        | Picture(id,source,visible) ->
        | Video(id,source,visible) ->
        | Block(id,color,txt,font,txtSize,fontFamily,visible) ->
        | ComboBox(id,color,txt,font,txtSize,fontFamily,visible) ->
        | Div(id,color,txt,font,txtSize,fontFamily,visible) -> 
    

let DefineVars (state : State) =
    state.PageInfo
    |> Seq.map ( fun ctrl -> )
     

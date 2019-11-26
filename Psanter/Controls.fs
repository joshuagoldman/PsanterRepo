module Controls


type BackgroundColor = {BackgroundColorVal : string}
type Text = {TextVal : string}
type TextColor = {TextColorVal : string}
type VideoSource = {VideoSourceVal : string}
type PictureSource = {PictureSourceVal : string}
type Font = {FontVal : string}
type TextSize = {TextSizeVal : string}
type FontFamily = {FontFamilyVal : string}
type Visible = {VisibleVal : bool}
type Alternatives = {AlternativesVal : seq<Text>}
type ControlID = {ID : string}

type Control =
    | Button of ControlID * BackgroundColor * Text * Font * TextSize * FontFamily * Visible
    | TextArea of ControlID * BackgroundColor * Text * Font * TextSize * FontFamily * Visible
    | Picture of ControlID * PictureSource * Visible
    | Video of ControlID * VideoSource * Visible
    | Block of ControlID * BackgroundColor * Text * Font * TextSize * FontFamily * Visible
    | ComboBox of ControlID * Alternatives * Font * TextSize * FontFamily * Visible
    | Div of ControlID * PictureSource

type Button =
    {
        ButtonColor : BackgroundColor
        ButtonText : Text
        ButtonFont : Font
        ButtonTextSize : TextSize
        ButtonFontFamily : FontFamily
        ButtonVisibility : Visible

    }

type TextArea =
    {
        TextAreaColor : BackgroundColor
        TextAreaText : Text
        TextAreaFont : Font
        TextAreaTextSize : TextSize
        TextAreaFontFamily : FontFamily
        TextAreaVisibility : Visible

    }

type Picture =
    {
        Source : PictureSource
        PictureVisibility : Visible
    }

type Video =
    {
        Source : VideoSource
        VideoVisibility : Visible
    }

type TextBlock =
    {
        TextBlockColor : BackgroundColor
        TextBlockText : Text
        TextBlockFont : Font
        TextBlockTextSize : TextSize
        TextBlockFontFamily : FontFamily
        TextBlockVisibility : Visible
    }

type ComboBox =
    {
        ComboBoxAlternatives : Alternatives
        ComboBoxBlockText : Text
        ComboBoxBlockFont : Font
        ComboBoxBlockTextSize : TextSize
        ComboBoxBlockFontFamily : FontFamily
        ComboBoxBlockVisibility : Visible
    }



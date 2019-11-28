module Controls

type AppearanceAttributes =
    {
        Color : string
        Text_decoration : string
        Padding : string
        Font_Family : seq<string>
        Font_Size : string
        Position : string
        top : float
        left : float
        Background : string
        height : string
        width : string
        transition : string
        Display : string
    }

type MainMenuElements =
    {
        MainDivButton : AppearanceAttributes
        GenreCombobox : AppearanceAttributes
        MuteButton : AppearanceAttributes
    }

type Page =
    {
        MainMenu : MainMenuElements
    }


let defaultAppearanceAttributes = 
    {
        Color = "White" ;
        Text_decoration = "none" ;
        Padding = "5px 20px" ;
        Font_Family = seq[ "Roboto" ; "sans-serif"] ;
        Font_Size = "15px"
        Position = "" ;
        top = 10.0 ;
        left = 10.0 ;
        Background = "" ;
        height = "" ;
        width = "" ;
        transition = "" ;
        Display = "inline-block"
    }

let initPage = { MainMenu = 
                    { MainDivButton = defaultAppearanceAttributes ;
                      GenreCombobox = defaultAppearanceAttributes ;
                      MuteButton = defaultAppearanceAttributes }}


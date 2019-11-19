module Definitions

type Octave =
    {
        Value : string
    }

type Notes =
    | C of Octave
    | CSharp of Octave
    | D of Octave
    | DSharp of Octave
    | E of Octave
    | F of Octave
    | FSharp of Octave
    | G of Octave
    | GSharp of Octave
    | A of Octave
    | ASharp of Octave
    | B of Octave

type NotInfo =
    {
        Note : Notes
        NoteFracInit : float
        NoteFracDuration : float
    }

type CompositionInfo = 
    {
        Duration : float
        Notes : seq<NotInfo>
        Color : string
    }

type Parts =
    | LeftHand of seq<CompositionInfo>
    | RightHand of seq<CompositionInfo>

type Compsition =
    | TwinkleLittleStar of Parts
    | ImprovisationMinor of Parts

type Music =
    | Classic
    | Pop
    | BoogiWoogie

type IntroInfo =
    {
        Video : string
    }

type MainPageInfo =
    {
        BackGroundPicture : string
    }

type Page =
    | MainPage of MainPageInfo
    | Intro of IntroInfo
    | Training of Music

type State =
    {
        Activity : Page
    }


type Msg = 
    | New of Page
    | Ongoing of Page
    | DoIntro of Page
    | PlayLeftOrRight of Parts
    | PlayPart of CompositionInfo
module Definitions

open Controls


type Note =
    {
        Octave : int
        Value : string
    }

type NoteInfo =
    {
        NoteFracInit : float
        NoteFracDuration : float
        NotesPushed : seq<Note>
    }

type CompositionInfo = 
    {
        Duration : float
        Notes : seq<NoteInfo>
    }

type Parts =
    | LeftHand 
    | RightHand
    | Both

type MusicSource = {Value : string}

type Music =
    {
        Genre : string
        Composition : string
        Hand : Parts
        Data : CompositionInfo
    }


type State =
    {
        PageName : string
        PageActivity : Music
        PageInfo : Page
    }


type Msg = 
    | MainMenuButtonClicked of string
    | MusicGenreClicked of Music
    | PlayLeftOrRight of Parts
    | PlayPart of CompositionInfo


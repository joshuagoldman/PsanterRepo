module Definitions

open Controls


type Note =
    {
        Octave : int
        Value : string
        Appearance : AppearanceAttributes
    }

type NoteInfo =
    {
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
        Data : seq<CompositionInfo>
        NotesCurrentlyPushed : seq<Note>
    }


type State =
    {
        PageName : string
        PageActivity : Music
        PageInfo : Page
    }


type Msg = 
    | HoverOverGenreButton of string
    | MutButtonClicked of string * bool
    | NewPage of State
    | NewMusicToPlay of string
    | MusicGenreClicked of Music
    | PlayLeftOrRight of Parts
    | PlayPart of CompositionInfo



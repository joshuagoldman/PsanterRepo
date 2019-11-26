module MusicData

open Controls
open Definitions

let TwinkleLittleStarRightHand =
    seq[
            { NoteFracInit = 1.0 ;
              NoteFracDuration = 1.0 ;
              NotesPushed =
                seq[
                        { Octave = 3 ; Value = "C" }
                   ]} ;

            { NoteFracInit = 1.0 ;
              NoteFracDuration = 1.0 ;
              NotesPushed =
                seq[
                        { Octave = 3 ; Value = "C" }
                   ]} ;

            { NoteFracInit = 1.0 ;
              NoteFracDuration = 1.0 ;
              NotesPushed =
                seq[
                        { Octave = 3 ; Value = "E" }
                   ]} ;

            { NoteFracInit = 1.0 ;
              NoteFracDuration = 1.0 ;
              NotesPushed =
                seq[
                        { Octave = 3 ; Value = "E" }
                   ]} ;
       ]

let TwinkleLittleStarLeftHand =
    seq[
            { NoteFracInit = 1.0 ;
              NoteFracDuration = 1.0 ;
              NotesPushed =
                seq[
                        { Octave = 3 ; Value = "C" } ;
                        { Octave = 3 ; Value = "E" } ;
                        { Octave = 3 ; Value = "G" }
                   ]} ;

            { NoteFracInit = 1.0 ;
              NoteFracDuration = 1.0 ;
              NotesPushed =
                seq[
                        { Octave = 3 ; Value = "C" } ;
                        { Octave = 3 ; Value = "E" } ;
                        { Octave = 3 ; Value = "G" }
                   ]} ;
       ]


let compositions =
    seq [
            { Duration = 1.0 ;
              Notes =  TwinkleLittleStarRightHand }
        ]

let allMusicPieces = 
    seq [
            { Genre = "" ; Composition = "" ;
              Hand = Parts.Both ;
              Data = compositions|> Seq.item(0)}
        ]
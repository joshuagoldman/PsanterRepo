module MusicLogic

open Controls
open Definitions

let getNoteAppearance ( str : string ) =
    let whiteKeys = [ "c" ; "d" ; "e" ; "f" ; "g" ; "a" ; "b" ]  
    let BlackKeys = [ "c#" ; "d#" ; "f#" ; "g#" ; "a#" ]

    str
    |> function
       | _ when whiteKeys
                |> Seq.exists (fun note -> note = str) ->
                    defaultAppearanceAttributes
       | _ when BlackKeys
                |> Seq.exists (fun note -> note = str) ->
                    defaultAppearanceAttributes
       | _ -> defaultAppearanceAttributes

let getNotesPushed ( str : string ) =
        str.Split ','
        |> Array.map (fun info -> 
                            { Octave = info.Substring(0, 1) |> int ;
                              Value = info.Substring(1, 1).ToLower() ;
                              Appearance = 
                                getNoteAppearance (info.Substring(1, 1).ToLower())
                              })
        |> Array.toSeq

let parseNote ( note : string ) = 
    note.Split ';'
    |> fun info ->
        { NoteFracDuration = info.[0] |> float 
          NotesPushed = getNotesPushed info.[1]
            }

let noteParser ( notesToeParse : seq<string> ) = 
    notesToeParse
    |> Seq.map ( fun note -> parseNote note )
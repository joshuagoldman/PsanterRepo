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

let getNoteValue ( note : string ) =
    if note |> String.length > 2
    then note.Substring(1,2).ToLower()
    else note.Substring(1,1).ToLower()


let getNotesPushed ( str : string ) =
        str.Split ','
        |> Array.map (fun info -> 
                            { Octave = info.Substring(0, 1) |> int ;
                              Value = getNoteValue info ;
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

let BlackKeysInfo =
    let octaves = seq[0..5]

    let repeatingPattern =
        seq 
            [
                {| Margin = 10 ; Note = "c#"|}
                {| Margin = 41 ; Note = "d#"|}
                {| Margin = 9 ; Note = "f#"|}
                {| Margin = 9 ; Note = "g#"|}
                {| Margin = 41 ; Note = "a#"|}
            ]
    
    octaves
    |> Seq.collect (fun octave -> repeatingPattern
                                  |> Seq.map (fun note ->
                                            {|
                                                Margin = note.Margin 
                                                Note = note.Note 
                                                Octave = octave
                                            |}
                                            ))

    |> fun x -> Seq.zip x [0..x |> Seq.length |> fun y -> y - 1]       
                |> Seq.filter (fun (_,pos) -> pos <> (x |> Seq.length |> fun y -> y - 1))
                |> Seq.map (fun (info,_) -> info)
                |> fun x -> Seq.append x [ {| Margin = 0 ; Note = "a#" ; Octave = 5|} ]

let whiteKeysInfo =
    let octaves = seq[0..5]

    let repeatingPattern =
        seq 
            [
                "c"
                "d"
                "e"
                "f"
                "g"
                "a"
                "b"
            ]
    
    octaves
    |> Seq.collect (fun octave -> repeatingPattern
                                  |> Seq.map (fun note ->
                                            {|
                                                Note = note
                                                Octave = octave
                                            |}
                                            ))
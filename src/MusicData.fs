
module MusicData

open Controls
open Definitions
open MusicLogic

let allMusic = 
    seq
        [
           "Music/Crow.mp3"
           "Music/ClairDeLune.mp3"
           "Music/EvgenisWaltz.mp3"
           "Music/Debussy_Reverie.mp3"
           "Music/MoonlightSonata.mp3"
        ]

let twinkleLittleStarRightHandData =
    seq
        [
            "1.0;2e,2g,3c"
            "1.0;2e,2g,3c"
            "1.0;2c,3e,3g"
            "1.0;2c,3e,3g"
            "1.0;2c,3f,3a"
            "1.0;2c,3f,3a"
            "2.0;2c,3e,3g"
            "1.0;2a,3c,2f"
            "1.0;2a,3c,2f"
            "1.0;2g,3c,3e"
            "1.0;2g,3c,3e"
            "1.0;2g,2b,2d"
            "1.0;2g,2b,2d"
            "2.0;2e,2g,3c"
        ]

let TwinkleLittleStarRightHand =
    noteParser twinkleLittleStarRightHandData

let twinkleLittleStarLeftHandData =
    seq
        [
            "0.5;1c,4g"
            "0.5;1g"
            "0.5;2c"
            "0.5;1g"
            "0.5;1c"
            "0.5;1g"
            "0.5;2c"
            "0.5;1g"
            "0.5;1f"
            "0.5;2c"
            "0.5;2f"
            "0.5;2c"
            "0.5;1c"
            "0.5;1g"
            "0.5;2c"
            "0.5;1g"
            "0.5;1f"
            "0.5;2c"
            "0.5;2f"
            "0.5;2c"
            "0.5;1c"
            "0.5;1g"
            "0.5;2c"
            "0.5;1g"
            "0.5;1g"
            "0.5;2d"
            "0.5;2f"
            "0.5;2d"
            "0.25;1c"
            "0.25;1e"
            "0.25;1g"
            "0.25;2c"
            "1;1c,1e,1g,2c"
        ]

let TwinkleLittleStarLeftHand =
    noteParser twinkleLittleStarLeftHandData

let getRightMusic ( composition : string ) = 
    match composition with
    | "TwinkleLittleStar" -> seq
                                [
                                    {
                                        Duration = 1.0
                                        Notes = TwinkleLittleStarLeftHand
                                    }
                                    {
                                       Duration = 1.0
                                       Notes = TwinkleLittleStarRightHand
                                    }
                                ]
    | _ -> seq
            [
                {
                    Duration = 1.0
                    Notes = TwinkleLittleStarLeftHand
                }
                {
                   Duration = 1.0
                   Notes = TwinkleLittleStarRightHand
                }
            ]


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


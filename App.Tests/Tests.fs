module Tests

open System
open MainMenu
open Definitions
open Controls
open MusicLogic
open Xunit

[<Fact>]
let ``TestMusicParser`` () =
    
    let testingSequence =
        seq
            [
                "1.4;3g,3f#"
                "0.4;3g,3f"
                "0.5;3g#,3c#"
            ]

    let expectedResult =
        seq
            [
                {|
                    Frac = 1.4
                    Notes =
                        seq
                            [
                                {
                                    Value = "g"
                                    Octave = 3
                                    Appearance = defaultAppearanceAttributes
                                }
                                {
                                    Value = "f#"
                                    Octave = 3
                                    Appearance = defaultAppearanceAttributes
                                }
                            ]
                |}
                {|
                    Frac = 0.4
                    Notes =
                        seq
                            [
                                {
                                    Value = "g"
                                    Octave = 3
                                    Appearance = defaultAppearanceAttributes
                                }
                                {
                                    Value = "f"
                                    Octave = 3
                                    Appearance = defaultAppearanceAttributes
                                }
                            ]
                |}
                {|
                    Frac = 0.5
                    Notes =
                        seq
                            [
                                {
                                    Value = "g#"
                                    Octave = 3
                                    Appearance = defaultAppearanceAttributes
                                }
                                {
                                    Value = "c#"
                                    Octave = 3
                                    Appearance = defaultAppearanceAttributes
                                }
                            ]
                |}
            ]
    
    let isAllTrue ( expected : seq<Note> )
                  ( actual : seq<Note>) = 
        Seq.zip expected actual
        |> Seq.forall (fun (expected, actual) -> expected.Octave = actual.Octave &&
                                                 expected.Value = actual.Value)

    let actualResult =
        testingSequence
        |> Seq.map (fun info -> parseNote info)

    Seq.zip expectedResult actualResult
    |> Seq.forall (fun (expected,actual) -> expected.Frac = actual.NoteFracDuration &&
                                          isAllTrue expected.Notes actual.NotesPushed )
    |> fun x -> Assert.True(x)
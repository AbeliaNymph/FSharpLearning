open System
open System.Threading.Tasks
open System.Diagnostics

[<EntryPoint>]
let main args =
    
    use stream_reader = new IO.StreamReader (IO.File.OpenRead "config.toml")
    let input = stream_reader.ReadToEnd()
    printfn "%A" input

    let input = 
        input.Trim().TrimStart('[').Split('[')
        |> Seq.map (
            fun item ->
                let input = item.Trim().Split(']')
                (
                    input.[0].Trim(), 
                    input.[1].Trim().Split("\r\n")
                    |> Seq.map (
                        fun item ->
                            let input = item.Trim().Split('=')
                            (input.[0].Trim(), input.[1].Trim())
                    )
                    |> Map.ofSeq
                )               
        )
        |> Map.ofSeq

    printfn "%A" input
    
    printfn "%A" input.["java_web"].["output"]

    0
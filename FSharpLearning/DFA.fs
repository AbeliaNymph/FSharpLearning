module DFA

    let rec run (finite_status_set: 'a list when 'a :> System.IEquatable<'a>) (input_symbol_collection: 'b list when 'b :> System.IEquatable<'b>) (convert_function: 'b -> 'a -> 'a) (start_status: 'a) (end_status_set: 'a list) (input_list: 'b list): bool =
        let mutable state = start_status
        match input_list with
        | input :: others ->
            let is_exist = 
                input_symbol_collection
                |> List.exists (fun item -> if item = input then true else false)

            match is_exist with
            | true ->
                state <- convert_function input state
                run finite_status_set input_symbol_collection convert_function state end_status_set others
            | false ->
                false
        | [] -> 
            end_status_set
            |> List.exists (fun item -> if item = state then true else false)

    let test _ =
        let finite_status_set = [0; 1; 2; 3]
        let input_symbol_collection = ["a"; "b"]
        let ok_input = ["b";"b";"a";"b";"b"]
        let erroe_input = ["b";"b";"b";"a";"a"]
        let start_state = 0
        let end_status_set = [3]

        let convert_function input state = 
            let set = [
                [1;0]
                [1;2]
                [1;3]
                [1;0]
            ]

            if input = "a" then
                set.[state].[0]
            else
                set.[state].[1]


        let ok_result = run finite_status_set input_symbol_collection convert_function start_state end_status_set ok_input

        let error_result = run finite_status_set input_symbol_collection convert_function start_state end_status_set erroe_input

        printfn "%A %A" ok_result error_result
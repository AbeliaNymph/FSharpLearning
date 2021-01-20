module LINQTest

let data_sourse = seq {
    for i in 0..10 do
        yield i
}

let select_test _ =
    query {
        for number in data_sourse do
            where (number <= 5)
            select number            
    }
    |> Seq.iter (fun item -> printfn "%A " item)

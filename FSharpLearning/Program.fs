open System



[<EntryPoint>]
let main args = 
    let stack = Stack.create()
    printfn "%A" stack

    let stack = Stack.push stack 2
    printfn "%A" stack

    let number = Stack.peek stack
    printfn "%A" number

    let stack = Stack.pop stack
    printfn "%A" stack

    
    let stack = Stack.pop stack
    printfn "%A" stack

    0
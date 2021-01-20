module ConsoleGUI

    open System
    
    let draw _ = 
        Console.BackgroundColor <- ConsoleColor.White
        printfn "Console.WindowHeight %A" Console.WindowHeight
        Console.ResetColor()
        printfn "Console.WindowWidth %A" Console.WindowWidth

        for i in 0..9 do
            Console.SetCursorPosition(40,i)
            printfn "|"

        for i in 0..39 do
            Console.SetCursorPosition(i,10)
            printfn "-"
        
        while true do 
            
            match Console.ReadKey() with
            | key_info when key_info.Key = ConsoleKey.UpArrow -> 
                Console.SetCursorPosition(0,0)
                Console.BackgroundColor <- ConsoleColor.White
                printfn " Console.WindowHeight %A" Console.WindowHeight
                Console.ResetColor()

                Console.SetCursorPosition(0,1)
                
                printfn " Console.WindowWidth %A" Console.WindowWidth

                Console.SetCursorPosition(0,29)
                
            | key_info when key_info.Key = ConsoleKey.DownArrow ->
                Console.SetCursorPosition(0,1)
                Console.BackgroundColor <- ConsoleColor.White
                printfn " Console.WindowWidth %A" Console.WindowWidth
                Console.ResetColor()
                Console.SetCursorPosition(0,0)
                printfn " Console.WindowHeight %A" Console.WindowHeight

                Console.SetCursorPosition(0,29)
            | _ ->
                exit 0
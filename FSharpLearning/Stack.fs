module Stack
    open System

    type Stack<'a> = 
        {
            instance: 'a list
    
            length: int
                
        }
    
    let create _ =
        {
            instance = []
            length = 0
        }
    

    let push (stack: Stack<'a>) (item : 'a) = 
        {
            instance = item :: stack.instance
            length = stack.length + 1
        }

    /// 当栈为空时，pop函数会直接返回空栈
    let pop (stack: Stack<'a>) = 
        match stack.instance with
        | head :: others ->
            {
                instance = others
                length = stack.length - 1
            }
        | [] ->
            stack

    let peek (stack: Stack<'a>) = 
        match stack.instance with
        | [] ->
            Error "Err:: Empty Stack"
        | _ ->
            Ok stack.instance.[0]
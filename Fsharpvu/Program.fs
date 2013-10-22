// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

let gange b = b * b
let filt x = (x%2 = 1)
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    printfn "%d" (gange 4)
    let ma = System.Console.ReadLine()
    let res = [1..10]
    let filteret = List.filter filt res 
    printfn  "%d" filteret.Length
    let ma = System.Console.ReadLine()
    0 // return an integer exit code

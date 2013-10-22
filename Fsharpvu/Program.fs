// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

let gange b = b * b

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    printfn "%d" (gange 4)
    let ma = System.Console.ReadLine()
    0 // return an integer exit code

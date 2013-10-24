// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System.Linq
open System
open System.Text.RegularExpressions;
let filtering list = 
    List.filter (fun x -> x%2 = 1) list 

let mapping list =
    List.map (fun x -> x*x) list

let rec ConvertToString list =
   match list with
   | [l] -> l.ToString()
   | head :: tail -> head.ToString() + "," + ConvertToString tail
   | [] -> ""

let ma con = 
    match con with 
        | l -> if(Regex.IsMatch(l, "^([1-9]+,)*[1-9]+$")) // ^ betyder at man skal starte med et tal fra 1-9, tallet skal findes minimum 1 gang hvilket + undertreger og efterfulgt af komma 
                                                       // men da man også kan skrive et enkelt tal og derfor ikke kan være efterfulgt af komma indkapsler man det i ()* 
                                                       // * betyder at det som er inden i parentesen matches 0 eller flere gange og derfor skal man ikke nødvendigvis matche,
                                                       // til sidst siger man at den skal ende med et tal hvilket $ symbolet betyder.
               then 
                    let res = List.map (fun x -> x * x ) (List.map (fun x -> int x) (List.ofArray (l.Split(','))))
                    printfn "%A" res
               else printfn "Failed"

let vubash(c:string) = printf "%s" (String.Format("VuBash>{0}",c))

type Mode = Math | Command

let getCommand com = 
    let regex = Regex.Match(com, "^\d+(\.|,\d)*(\+|\*|-|/)+\d+(\.|,\d)*$").Value
    let math str op = regex.Contains(op)
    let operators = ["-";"+";"*";"/"]
    
    let plus (list:string[]) = 
            let va = List.map (fun x-> double x) (List.ofArray(list))
            va.ElementAt(0) + va.ElementAt(1)

    let minus (list:string[]) = 
            let va = List.map (fun x-> double x) (List.ofArray(list))
            va.ElementAt(0) - va.ElementAt(1)

    let subtract (list:string[]) = 
            let va = List.map (fun x-> double x) (List.ofArray(list))
            va.ElementAt(0) * va.ElementAt(1)

    let divide (list:string[]) = 
            let va = List.map (fun x-> double x) (List.ofArray(list))
            va.ElementAt(0) / va.ElementAt(1)

    let rec calculate (command:string) count = 
        if(count < operators.Length) then 
            match (math command (operators.ElementAt(count))) with 
            | true -> match count with
                      | 0 -> printf "%A" (minus (command.Replace(',','.').Split('-')))
                      | 1 -> printfn "%A" (plus (command.Split('+'))) 
                      | 2 -> printfn "%A"  (subtract (command.Split('*'))) 
                      | 3 -> printfn "%A"   (divide (command.Split('/'))) 
                      | _ -> (vubash "no matches")
            | false -> if(count < operators.Length) then calculate command (count+1) else ()
        else vubash "no matches"

    calculate regex 0

let rec readCom(command) = 
    (getCommand command)

[<EntryPoint>]
let main argv = 
    //printfn  "%A" (mapping (filtering  [1..10]))
    //printfn "Write numbers seperated with ,"
    //ma (Console.ReadLine())
    printf "VuBash>"
    let ma = readCom (Console.ReadLine())
    let shi = Console.ReadLine()
    0 // return an integer exit code

open System
open PE

let sumOfSquare =
  let mutable sum = 0
  for i in 1..100 do
    sum <- sum + i * i
  sum

let squareOfSum =
  let mutable sum = 0
  for i in 1..100 do
    sum <- sum + i
  sum * sum

printfn "%A" <| squareOfSum - sumOfSquare

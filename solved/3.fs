open System

let target = 600851475143L
let limit =
  int32 << ceil << sqrt << float <| target
let sqrtLimit =
  int32 << ceil << sqrt << float <| limit
let flags = System.Collections.BitArray(limit + 1, true)
do
  flags.[0] <- false
  flags.[1] <- false

let ans = new Collections.Generic.HashSet<int32>()
do
  for i in 2..sqrtLimit do
    if flags.[i] then
      ans.Add(i) |> ignore
      let mutable j = 2
      while i * j < limit do
        flags.[i * j] <- false
        j <- j + 1
      done
  for i in (sqrtLimit + 1)..limit do
    if flags.[i] then
      ans.Add(i) |> ignore
  ans.RemoveWhere(fun x -> target % int64 x <> 0L) |> ignore
  for e in ans do
    Console.WriteLine(e)
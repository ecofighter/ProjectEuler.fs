namespace PE
open System

module Util =
  let makePrimes n =
    let limit =
      int32 << ceil << sqrt << float <| n
    let flags = System.Collections.BitArray(n + 1, true)
    flags.[0] <- false
    flags.[1] <- false
    let primes = new Collections.Generic.List<int32>()
    for i in 2..limit do
      if flags.[i] then
        primes.Add(i) |> ignore
        let mutable j = 2
        while i * j < n+1 do
          flags.[i * j] <- false
          j <- j + 1
    for i in (limit + 1)..n do
      if flags.[i] then
        primes.Add(i) |> ignore
    primes.ToArray()
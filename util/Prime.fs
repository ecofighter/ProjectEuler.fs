namespace PE
open System

module Util =
  let sieve n =
    let limit =
      int32 << ceil << sqrt << float <| n
    let flags = Collections.BitArray(n + 1, true)
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

  let primes : int seq = seq {
    yield 2

    let multiples = new Collections.Generic.Dictionary<int,int>()

    for n in Seq.initInfinite (fun i -> i*2 + 3) do
      let isPrime = not <| multiples.ContainsKey(n)
      let factor = if isPrime then n*2 else multiples.[n]
      if not isPrime then
        multiples.Remove(n) |> ignore
      let nextKey =
        Seq.initInfinite (fun i -> (i+1)*factor + n)
        |> Seq.find (multiples.ContainsKey >> not)
      multiples.Add(nextKey, factor)
      if isPrime then yield n
  }

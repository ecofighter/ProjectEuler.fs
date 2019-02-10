open System
open PE.Util

let primes = makePrimes 20
let factors = Collections.Generic.Dictionary<int,int>()

do
  for i in 2 .. 20 do
    for p in primes do
      if i >= p && i % p = 0 then
        let mutable now = i
        let mutable count = 0
        while now % p = 0 do
          count <- count + 1
          now <- now / p
        done
        try
          // let v = factors.Item(p)
          let v = factors.[p]
          if count > v then
            factors.[p] <- count
        with
          | :? Collections.Generic.KeyNotFoundException as e ->
            factors.[p] <- count

do
  let mutable ans = 1
  for kvp in factors do
    Console.WriteLine(kvp)
    ans <- ans * (pown kvp.Key kvp.Value)
  Console.WriteLine("ans is {0}", ans)
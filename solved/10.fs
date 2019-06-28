open System
open PE

let a =
  Util.sieve 2_000_000
  |> Array.sumBy bigint

printf "%A" a

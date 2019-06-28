open System
open PE

let rec check a b =
  let c = 1000 - a - b
  if c <= 0 then
    failwith "error"
  elif c <= b then
    check (a+1) (a+2)
  elif a*a + b*b <> c*c then
    check a (b+1)
  else
    (a,b,c,a * b * c)

printfn "%A" <| check 1 2

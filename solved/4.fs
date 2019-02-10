open System

let reverseThree n =
  let ones = n % 10
  let tens = (n % 100) / 10
  let hundreds = n / 100
  ones * 100 + tens * 10 + hundreds

let isProductOfThrees n =
  let mutable now = 999
  let limit = int << floor << sqrt << float <| n
  let mutable flag = false
  while now > limit && not flag do
    if n % now = 0 then
      flag <- true
    now <- now - 1
  flag

let makePelindrome upper =
  let lower = reverseThree upper
  upper * 1000 + lower

[<EntryPoint>]
let main argv =
  let mutable now = 998 // 999 * 999 / 1000
  let mutable ans = 0
  let mutable i = 1
  while now > 99 && ans = 0 do
    let p = makePelindrome now
    Console.WriteLine(p)
    if isProductOfThrees p then
      ans <- p
    now <- now - 1
  Console.WriteLine("is answer.")
  0
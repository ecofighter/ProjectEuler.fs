open System
open PE

let m =
  let inline raw _ =
    Console.ReadLine().Split(' ')
    |> Array.map int
  Matrix<int>(20, 20, Array.init 20 raw)

[<EntryPoint>]
let main args =
  let mutable max = Max.initial
  for row in 0..(m.RowCount-4) do
    for col in 0..(m.ColCount-1) do
      max.Update(m.[row,col] * m.[row+1,col] * m.[row+2,col] * m.[row+3,col])
  for row in 0..(m.RowCount-1) do
    for col in 0..(m.ColCount-4) do
      max.Update(m.[row,col] * m.[row,col+1] * m.[row,col+2] * m.[row,col+3])
  for row in 0..(m.RowCount-4) do
    for col in 0..(m.ColCount-4) do
      max.Update(m.[row,col] * m.[row+1,col+1] * m.[row+2,col+2] * m.[row+3,col+3])
      max.Update(m.[row+3,col] * m.[row+2,col+1] * m.[row+1,col+2] * m.[row,col+3])
  Console.WriteLine(max.Value)
  0

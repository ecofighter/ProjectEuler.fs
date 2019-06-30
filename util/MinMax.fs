namespace PE

open System
open System.Runtime.CompilerServices

[<IsByRefLike;Struct>]
type Max =
  val mutable private value: int
  new (v: int) = { value = v }
  member this.Value
    with get () = this.value
    and private set v = this.value <- v
  member this.Update (v: int) =
    if this.Value < v then
      this.Value <- v
  static member initial = Max(Int32.MinValue)

[<IsByRefLike;Struct>]
type Min =
  val mutable private value: int
  new (v: int) = { value = v }
  member this.Value
    with get () = this.value
    and private set v = this.value <-v
  member this.Update (v: int) =
    if v < this.Value then
      this.Value <- v
  static member initial = Max(Int32.MaxValue)

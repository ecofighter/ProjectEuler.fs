namespace PE

open System

exception MatrixNotMatchDimensionException

[<Struct>]
type Matrix<'T> =
  val RowCount: int
  val ColCount: int
  val private Storage: 'T []

  member this.Item
    with get (row, col) =
      this.Storage.[ row * this.ColCount + col ]
    and set (row, col) v =
      this.Storage.[ row * this.ColCount + col ] <- v

  new (row: int, col: int, source: 'T [] []) =
    { RowCount = row
      ColCount = col
      Storage =
        let source' = Array.collect id source in
        if source'.Length <> row*col then
          raise MatrixNotMatchDimensionException
        else source' }
  new (row: int, col: int, source: 'T []) =
    { RowCount = row
      ColCount = col
      Storage =
        if source.Length <> row*col then
          raise MatrixNotMatchDimensionException
        else Array.copy source }
  new (row: int, col: int) =
    { RowCount = row
      ColCount = col
      Storage = Array.zeroCreate (row*col) }

  member this.Clone() : Matrix<'T> =
    Matrix(this.RowCount, this.ColCount, this.Storage)

  member this.MapInPlace (f: 'T -> 'T) : unit =
    for i in 0..(this.Storage.Length - 1) do
      this.Storage.[i] <- f this.Storage.[i]

  static member Map<'U> (f: 'T -> 'U) (a: Matrix<'T>) : Matrix<'U> =
    Matrix<'U>(a.RowCount, a.ColCount, Array.map f a.Storage)

  static member Map2<'U,'V> (f: 'T -> 'U -> 'V) (a: Matrix<'T>) (b: Matrix<'U>) : Matrix<'V> =
    if a.RowCount <> b.RowCount || a.ColCount <> b.ColCount then
      raise MatrixNotMatchDimensionException
    else
      Matrix<'V>(a.RowCount, a.ColCount, Array.map2 f a.Storage b.Storage)

  static member inline (~-) (a: Matrix< ^U>) : Matrix< ^U>
    when ^U : (static member (~-) : ^U -> ^U) =
      Matrix.Map (~-) a

  static member inline (+) (leftSide: Matrix< ^U>, rightSide: Matrix< ^V>) : Matrix< ^W>
    when (^U or ^V or ^W) : (static member (+) : ^U * ^V -> ^W) =
      if leftSide.RowCount <> rightSide.RowCount || leftSide.ColCount <> rightSide.ColCount then
        raise MatrixNotMatchDimensionException
      else
        Matrix.Map2 (+) leftSide rightSide

  static member inline (-) (leftSide: Matrix< ^U>, rightSide: Matrix< ^V>) : Matrix< ^W>
    when (^U or ^V or ^W) : (static member (-) : ^U * ^V -> ^W) =
      if leftSide.RowCount <> rightSide.RowCount || leftSide.ColCount <> rightSide.ColCount then
        raise MatrixNotMatchDimensionException
      else
        Matrix.Map2 (-) leftSide rightSide

module Matrix =
  let inline map f a = Matrix.Map f a
  let inline map2 f a b = Matrix.Map2 f a b

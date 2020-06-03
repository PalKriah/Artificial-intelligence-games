import { Point } from "./Point";
import { ChessPiece } from "./ChessPiece";

export interface OnePersonMove {
    from: Point;
    to: Point;
    piece: ChessPiece;
}
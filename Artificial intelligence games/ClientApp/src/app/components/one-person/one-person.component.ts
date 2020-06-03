import { Component, OnInit } from '@angular/core';
import { OnePersonMove } from 'src/app/models/OnePersonMove';
import { OnePersonService } from 'src/app/services/one-person.service';
import { ChessPiece } from 'src/app/models/ChessPiece';

@Component({
  selector: 'app-one-person',
  templateUrl: './one-person.component.html',
  styleUrls: ['./one-person.component.css']
})
export class OnePersonComponent implements OnInit {

  board: String[][];
  maxStep: number;
  currentStep: number;
  steps: OnePersonMove[];
  loaded: boolean = false;
  searcher: string;
  constructor(private onePersonService: OnePersonService) { }

  ngOnInit() {
    this.searcher = "optimal";
    this.onChange();
  }

  onChange() {
    this.onePersonService.getSteps(this.searcher).subscribe(steps => {
      this.board = [['King', 'Bishop', 'Bishop'], ['Rook', 'Rook', 'Empty']];
      this.steps = steps;
      this.maxStep = steps.length + 1;
      this.currentStep = 1;
      this.loaded = true;
    });
  }

  step(direction: number) {
    if (direction == 1 && this.currentStep < this.maxStep) {
      var move: OnePersonMove = this.steps[this.currentStep - 1];
      this.board[move.to.x][move.to.y] = this.getPieceName(move.piece as ChessPiece);
      this.board[move.from.x][move.from.y] = 'Empty';
      this.currentStep++;
    }
    else if (direction == -1 && this.currentStep > 1) {
      var move: OnePersonMove = this.steps[this.currentStep - 2];
      this.board[move.to.x][move.to.y] = 'Empty';
      this.board[move.from.x][move.from.y] = this.getPieceName(move.piece as ChessPiece);
      this.currentStep--;
    }
  }

  getPieceName(piece: ChessPiece): string {
    switch (piece) {
      case ChessPiece.King:
        return 'King';
      case ChessPiece.Rook:
        return 'Rook';
      case ChessPiece.Bishop:
        return 'Bishop';
      case ChessPiece.Empty:
        return 'Empty';
      default:
        break;
    }
  }
}
